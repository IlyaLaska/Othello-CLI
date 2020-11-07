using System.Collections.Generic;
using System.Linq;

public class Board
{
    public int boardLength = 8;
    public BoardSquare[,] board;


    public delegate void BoardUpdateEvent();
    public static event BoardUpdateEvent boardUpdateEvent;

    public Board()
    {
        this.board = new BoardSquare[boardLength, boardLength];
    }

    public void InitBoard()
    {
        for (int i = 0; i < boardLength; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                this.board[i, j] = new BoardSquare();
            }
        }

        //Add starting Pieces
        this.board[3, 3].belongsToPlayer = PieceEnum.white;
        this.board[4, 4].belongsToPlayer = PieceEnum.white;

        this.board[3, 4].belongsToPlayer = PieceEnum.black;
        this.board[4, 3].belongsToPlayer = PieceEnum.black;

        boardUpdateEvent?.Invoke();
    }

    public int[][] GetValidMovesList(IPlayer currPlayer)
    {
        PieceEnum currentPlayer = currPlayer.color;

        HashSet<int[]> validMovesList = new HashSet<int[]>();
        for (int i = 0; i < boardLength; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                if (board[i, j].belongsToPlayer == currentPlayer)//have to check possible moves for that piece
                {
                    validMovesList = new HashSet<int[]>(validMovesList.Concat(GetValidMovesForAPiece(new int[] { j, i }, currentPlayer)));
                }
            }
        }
        return validMovesList.ToArray();
    }


    private HashSet<int[]> GetValidMovesForAPiece(int[] boardSquareCoordinates, PieceEnum currentPlayer)
    {
        int[][] dirs = new int[8][];

        dirs[(int)Direction.NW] = new int[] { -1, -1 };
        dirs[(int)Direction.N ] = new int[] { -1, 0 };
        dirs[(int)Direction.NE] = new int[] { 1, -1 };
        dirs[(int)Direction.E ] = new int[] { 0, 1 };
        dirs[(int)Direction.SE] = new int[] { 1, 1 };
        dirs[(int)Direction.S ] = new int[] { 1, 0 };
        dirs[(int)Direction.SW] = new int[] { -1, 1 };
        dirs[(int)Direction.W ] = new int[] { 0, -1 };

        HashSet<int[]> validMovesList = new HashSet<int[]>();

        int[] array;
        for (int i = 0; i < dirs.Length; i++)
        {
            array = GetSuccesfulMoveInDirection(boardSquareCoordinates, dirs[i], currentPlayer);
            if(array[0] == 1) validMovesList.Add(new int[] { array[1], array[2], array[3], array[4] });
        }

        return validMovesList;
    }

    private int[] GetSuccesfulMoveInDirection(int[] boardSquareCoordinates, int[] direction, PieceEnum currentPlayer)
    {
        int hasBeatableEnemies = 0;
        int x = direction[0];
        int y = direction[1];
        int[] tempCoords = (int[])boardSquareCoordinates.Clone();
        
        //move to next checked square
        tempCoords[1] += x;
        tempCoords[0] += y;
        while (IsInRange(tempCoords[0]) && IsInRange(tempCoords[1]))//while inside board borders
        {
            if (board[tempCoords[1], tempCoords[0]].belongsToPlayer == currentPlayer.GetOpponent())//found opponent
            {
                hasBeatableEnemies = 1;
            }
            else if (hasBeatableEnemies == 1 && board[tempCoords[1], tempCoords[0]].belongsToPlayer == PieceEnum.none)//there are beatable opponents
            {
                return new int[] { 1, tempCoords[0], tempCoords[1], x, y };
            }
            else if (board[tempCoords[1], tempCoords[0]].belongsToPlayer != currentPlayer.GetOpponent())//found no enemies, reached dead end
            {
                break;
            }
            tempCoords[1] += x;
            tempCoords[0] += y;
        }
        return new int[] { 0, tempCoords[0], tempCoords[1], x, y };//no beatable enemies found
    }

    public bool IsInRange(int value)
    {
        return value < boardLength && value >= 0;
    }

    public int UpdateBeatPieces(List<int[]> validMoves, IPlayer currentPlayer)
    {
        PieceEnum currentTurn = currentPlayer.color;
        int changedPieces = 0;

        foreach (var XYDirection in validMoves)
        {
            if (currentTurn == PieceEnum.black)
            {
                ChangePieces(XYDirection[0], XYDirection[1], XYDirection[2], XYDirection[3], currentTurn, PieceEnum.white, ref changedPieces);
            }
            else ChangePieces(XYDirection[0], XYDirection[1], XYDirection[2], XYDirection[3], currentTurn, PieceEnum.black, ref changedPieces);
        }

        boardUpdateEvent?.Invoke();
        return changedPieces;
    }

    public void ChangePieces(int coordX, int coordY, int x, int y, PieceEnum colorCurrent, PieceEnum colorEnemy, ref int changed)
    {
        board[coordY, coordX].belongsToPlayer = colorCurrent;
        while (board[coordY - x, coordX - y].belongsToPlayer == colorEnemy)
        {
            coordX -= y;
            coordY -= x;
            board[coordY, coordX].belongsToPlayer = colorCurrent;
            changed++;
        }
    }

    public int MakeMoveGetScore(IPlayer currentPlayer, int[][] validMovesAndDirs)
    {
        List<int[]> takenCoordsAndDirections = new List<int[]>();

        //list of taken moves (coordinates same, direction different)
        for (int i = 0; i < validMovesAndDirs.Length; i++)
        {
            if (validMovesAndDirs[i][0] == currentPlayer.currentTurnCoords[0] && validMovesAndDirs[i][1] == currentPlayer.currentTurnCoords[1])//one of valids
            {
                takenCoordsAndDirections.Add(validMovesAndDirs[i]);
            }
        }
        if (takenCoordsAndDirections.Count == 0)//no allowed moves
        {
            return 0;
        }
        return UpdateBeatPieces(takenCoordsAndDirections, currentPlayer);
    }
}

