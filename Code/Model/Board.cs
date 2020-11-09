using System;
using System.Collections.Generic;
using System.Globalization;
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
    public Board(BoardSquare[,] board2)
    {
        //this.board = board;
        this.board = new BoardSquare[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                this.board[i, j] = new BoardSquare();
                this.board[i, j].belongsToPlayer = board2[i,j].belongsToPlayer;
            }
        }
    }
    public Board Clone()
    {
        return new Board(this.board);
    }

    public void PrintBoard()
    {
        Console.WriteLine("===============GameBoard:===============");
        Console.WriteLine("  |A|B|C|D|E|F|G|H|");
        for (int y = 0; y < 8; y++)
        {
            Console.Write(y+1 + " |");
            for (int x = 0; x < 8; x++)
            {
                if (this.board[y, x].belongsToPlayer == PieceEnum.black) Console.Write("B|");
                else if (this.board[y, x].belongsToPlayer == PieceEnum.white) Console.Write("W|");
                else if (this.board[y, x].belongsToPlayer == PieceEnum.none) Console.Write("O|");
                else if (this.board[y, x].belongsToPlayer == PieceEnum.blackHole) Console.Write("H|");
            }
            Console.WriteLine();
        }
        Console.WriteLine("=================================================");
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

        //List<int[]> validMovesList = new List<int[]>();
        int[][][] movesArray = new int[64][][];
        int pos = 0;
        for (int i = 0; i < boardLength; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                if (board[i, j].belongsToPlayer == currentPlayer)//have to check possible moves for that piece
                {
                    movesArray[pos++] = GetValidMovesForAPiece(new int[] { j, i }, currentPlayer).ToArray();
                    //validMovesList = validMovesList.Concat(GetValidMovesForAPiece(new int[] { j, i }, currentPlayer)).ToList();
                }
            }
        }
        List<int[]> validMovesList = new List<int[]>();
        for (int i = 0; i < pos; i++)
        {
            for (int j = 0; j < movesArray[i].Length; j++)
            {
                validMovesList.Add(movesArray[i][j]);
            }
        }
        return validMovesList.ToArray();
    }


    private List<int[]> GetValidMovesForAPiece(int[] boardSquareCoordinates, PieceEnum currentPlayer)
    {
        //int[][] dirs = new int[8][];

        //dirs[(int)Direction.NW] = new int[] { -1, -1 };
        //dirs[(int)Direction.N ] = new int[] { -1, 0 };
        //dirs[(int)Direction.NE] = new int[] { 1, -1 };
        //dirs[(int)Direction.E ] = new int[] { 0, 1 };
        //dirs[(int)Direction.SE] = new int[] { 1, 1 };
        //dirs[(int)Direction.S ] = new int[] { 1, 0 };
        //dirs[(int)Direction.SW] = new int[] { -1, 1 };
        //dirs[(int)Direction.W ] = new int[] { 0, -1 };

        List<int[]> validMovesList = new List<int[]>();

        int[] array;
        //for (int i = 0; i < dirs.Length; i++)
        //{
        //    array = GetSuccesfulMoveInDirection(boardSquareCoordinates, dirs[i], currentPlayer);
        //    if(array[0] == 1) validMovesList.Add(new int[] { array[1], array[2], array[3], array[4] });
        //}

        for (int dirX = -1; dirX < 2; dirX++)
        {
            for(int dirY = -1; dirY < 2; dirY++)
            {
                if(dirX != 0 && dirY != 0)
                {
                    array = GetSuccesfulMoveInDirection(boardSquareCoordinates, dirX, dirY, currentPlayer);
                    if (array[0] == 1) validMovesList.Add(new int[] { array[1], array[2], array[3], array[4] });
                }

            }

        }

        return validMovesList;
    }
    private int[] GetSuccesfulMoveInDirection(int[] boardSquareCoordinates, int dirX, int dirY, PieceEnum currentPlayer)
    {
        PieceEnum opponent = currentPlayer.GetOpponent();
        int hasBeatableEnemies = 0;
        //int[] tempCoords = (int[])boardSquareCoordinates.Clone();
        int tempY = boardSquareCoordinates[0];
        int tempX = boardSquareCoordinates[1];

        //move to next checked square
        //tempCoords[1] += x;
        //tempCoords[0] += y;
        tempX += dirX;
        tempY += dirY;

        while (IsInRange(tempY) && IsInRange(tempX))//while inside board borders
        {
            if (board[tempX, tempY].belongsToPlayer == opponent)//found opponent
            {
                hasBeatableEnemies = 1;
            }
            else if (hasBeatableEnemies == 1 && board[tempX, tempY].belongsToPlayer == PieceEnum.none)//there are beatable opponents
            {
                return new int[] { 1, tempY, tempX, dirX, dirY };
            }
            else if (board[tempX, tempY].belongsToPlayer != opponent)//found no enemies, reached dead end
            {
                break;
            }
            tempX += dirX;
            tempY += dirY;
        }
        return new int[] { 0, tempY, tempX, dirX, dirY };//no beatable enemies found
    }
    //private int[] GetSuccesfulMoveInDirection(int[] boardSquareCoordinates, int[] direction, PieceEnum currentPlayer)
    //{
    //    PieceEnum opponent = currentPlayer.GetOpponent();
    //    int hasBeatableEnemies = 0;
    //    int x = direction[0];
    //    int y = direction[1];
    //    //int[] tempCoords = (int[])boardSquareCoordinates.Clone();
    //    int tempY = boardSquareCoordinates[0];
    //    int tempX = boardSquareCoordinates[1];

    //    //move to next checked square
    //    //tempCoords[1] += x;
    //    //tempCoords[0] += y;
    //    tempX += x;
    //    tempY += y;

    //    while (IsInRange(tempY) && IsInRange(tempX))//while inside board borders
    //    {
    //        if (board[tempX, tempY].belongsToPlayer == opponent)//found opponent
    //        {
    //            hasBeatableEnemies = 1;
    //        }
    //        else if (hasBeatableEnemies == 1 && board[tempX, tempY].belongsToPlayer == PieceEnum.none)//there are beatable opponents
    //        {
    //            return new int[] { 1, tempY, tempX, x, y };
    //        }
    //        else if (board[tempX, tempY].belongsToPlayer != opponent)//found no enemies, reached dead end
    //        {
    //            break;
    //        }
    //        tempX += x;
    //        tempY += y;
    //    }
    //    return new int[] { 0, tempY, tempX, x, y };//no beatable enemies found
    //}

    public bool IsInRange(int value)
    {
        return value < boardLength && value >= 0;
    }

    public int UpdateBeatPieces(List<int[]> takenCoordsAndDirs, IPlayer currentPlayer)
    {
        //Console.WriteLine("TakenCoordsDirs: ");
        //foreach (var oneMove in takenCoordsAndDirs)
        //{
        //    Console.WriteLine("[{0}]", string.Join(", ", oneMove));

        //}
        PieceEnum currentTurn = currentPlayer.color;
        int changedPieces = 0;
        foreach (var XYDirection in takenCoordsAndDirs)
        {
            changedPieces = ChangePieces(XYDirection[0], XYDirection[1], XYDirection[2], XYDirection[3], currentTurn);
            //if (currentTurn == PieceEnum.black)
            //{
            //    ChangePieces(XYDirection[0], XYDirection[1], XYDirection[2], XYDirection[3], currentTurn, PieceEnum.white, ref changedPieces);
            //}
            //else ChangePieces(XYDirection[0], XYDirection[1], XYDirection[2], XYDirection[3], currentTurn, PieceEnum.black, ref changedPieces);
        }

        boardUpdateEvent?.Invoke();
        return changedPieces;
    }

    public int ChangePieces(int coordX, int coordY, int x, int y, PieceEnum colorCurrent)
    {
        int changed = 0;
        int[] XYDirs = new int[] { coordX, coordY, x, y };
        //Console.WriteLine("{1} [{0}]", string.Join(", ", XYDirs), "XYDirs");
        board[coordY, coordX].belongsToPlayer = colorCurrent;
        while (board[coordY - x, coordX - y].belongsToPlayer == colorCurrent.GetOpponent())
        {
            coordX -= y;
            coordY -= x;
            board[coordY, coordX].belongsToPlayer = colorCurrent;
            changed++;
        }
        return changed;
    }

    public int MakeMoveGetScore(IPlayer currentPlayer, int[][] validMovesAndDirs)
    {
        //Console.WriteLine("IN MAKEMOVEGetSCORE. ValidMoves len = " + validMovesAndDirs.Length);
        //Console.WriteLine("ValidMovesDirs: ");
        //foreach (var oneMove in validMovesAndDirs)
        //{
        //    Console.WriteLine("[{0}]", string.Join(", ", oneMove));

        //}
        List<int[]> takenCoordsAndDirections = new List<int[]>();

        //list of taken moves (coordinates same, direction different)
        for (int i = 0; i < validMovesAndDirs.Length; i++)
        {
            if (validMovesAndDirs[i][0] == currentPlayer.currentTurnCoords[0] && validMovesAndDirs[i][1] == currentPlayer.currentTurnCoords[1])//one of valids
            {
                takenCoordsAndDirections.Add(validMovesAndDirs[i]);
            }
        }
        //System.Console.WriteLine("TakenCoordsAndDirs (in MakeMoveGetScore):");
        //foreach (var oneMove in takenCoordsAndDirections)
        //{
        //    System.Console.WriteLine("[{0}]", string.Join(", ", oneMove));

        //}
        if (takenCoordsAndDirections.Count == 0)//no allowed moves
        {
            return 0;
        }
        return UpdateBeatPieces(takenCoordsAndDirections, currentPlayer);
    }
}

