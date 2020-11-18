using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Board
{
    public int boardLength = 8;
    public PieceEnum[,] board;
    public int turn = 1;
    public int[] lastMove = new int[2];
    public int[] blackHoleCoords;

    public delegate void BoardUpdateEvent();
    public static event BoardUpdateEvent boardUpdateEvent;

    public Board()
    {
        this.board = new PieceEnum[boardLength, boardLength];
    }

    public Board(Board board2)
    {
        this.board = new PieceEnum[boardLength, boardLength];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                this.board[i, j] = board2.board[i,j];
            }
        }
        this.turn = board2.turn;
        this.lastMove = (int[]) board2.lastMove.Clone();
    }
    public Board Clone()
    {
        return new Board(this);
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
                if (this.board[y, x] == PieceEnum.black) Console.Write("B|");
                else if (this.board[y, x] == PieceEnum.white) Console.Write("W|");
                else if (this.board[y, x] == PieceEnum.none) Console.Write("O|");
                else if (this.board[y, x] == PieceEnum.blackHole) Console.Write("H|");
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
                this.board[i, j] = PieceEnum.none;
            }
        }

        //Add starting Pieces
        this.board[3, 3] = PieceEnum.white;
        this.board[4, 4] = PieceEnum.white;

        this.board[3, 4] = PieceEnum.black;
        this.board[4, 3] = PieceEnum.black;

        boardUpdateEvent?.Invoke();
    }

    public int[][] GetValidMovesList(PieceEnum currentPlayer)
    {
        int[][][] movesArray = new int[64][][];
        int pos = 0;
        for (int i = 0; i < boardLength; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                if (board[i, j] == currentPlayer)//have to check possible moves for that piece
                {
                    movesArray[pos++] = GetValidMovesForAPiece(new int[] { j, i }, currentPlayer).ToArray();
                }
            }
        }
        //Using this to increase performance
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
        List<int[]> validMovesList = new List<int[]>();

        int[] array;

        for (int dirX = -1; dirX < 2; dirX++)
        {
            for(int dirY = -1; dirY < 2; dirY++)
            {
                if (dirX == 0 && dirY == 0) continue;
                array = GetSuccesfulMoveInDirection(boardSquareCoordinates, dirX, dirY, currentPlayer);
                if (array[0] == 1) validMovesList.Add(new int[] { array[1], array[2], array[3], array[4] });

            }

        }
        return validMovesList;
    }
    private int[] GetSuccesfulMoveInDirection(int[] boardSquareCoordinates, int dirX, int dirY, PieceEnum currentPlayer)
    {
        PieceEnum opponent = currentPlayer.GetOpponent();
        int hasBeatableEnemies = 0;
        int tempY = boardSquareCoordinates[0];
        int tempX = boardSquareCoordinates[1];

        //move to next checked square
        tempX += dirX;
        tempY += dirY;
        while (IsInRange(tempY) && IsInRange(tempX))//while inside board borders
        {
            if (this.board[tempX, tempY] == opponent)//found opponent
            {
                hasBeatableEnemies = 1;
            }
            else if (hasBeatableEnemies == 1 && this.board[tempX, tempY] == PieceEnum.none)//there are beatable opponents
            {
                return new int[] { 1, tempY, tempX, dirX, dirY };
            }
            else if (this.board[tempX, tempY] != opponent)//found no enemies, reached dead end
            {
                break;
            }
            tempX += dirX;
            tempY += dirY;
        }
        return new int[] { 0, tempY, tempX, dirX, dirY };//no beatable enemies found
    }


    public bool IsInRange(int value)
    {
        return value < boardLength && value >= 0;
    }

    public int UpdateBeatPieces(List<int[]> takenCoordsAndDirs, IPlayer currentPlayer)
    {
        PieceEnum currentTurn = currentPlayer.color;
        int changedPieces = 0;
        foreach (var XYDirection in takenCoordsAndDirs)
        {
            changedPieces = ChangePieces(XYDirection[0], XYDirection[1], XYDirection[2], XYDirection[3], currentTurn);
        }

        boardUpdateEvent?.Invoke();
        return changedPieces;
    }

    public int ChangePieces(int coordX, int coordY, int x, int y, PieceEnum colorCurrent)
    {
        int changed = 0;
        int[] XYDirs = new int[] { coordX, coordY, x, y };
        //Console.WriteLine("{1} [{0}]", string.Join(", ", XYDirs), "XYDirs");
        board[coordY, coordX] = colorCurrent;
        while (board[coordY - x, coordX - y] == colorCurrent.GetOpponent())
        {
            coordX -= y;
            coordY -= x;
            board[coordY, coordX] = colorCurrent;
            changed++;
        }
        return changed;
    }

    public int MakeMoveGetScore(IPlayer currentPlayer, int[][] validMovesAndDirs)
    {
        if (currentPlayer.currentTurnCoords == null) return 0;
        this.lastMove = currentPlayer.currentTurnCoords;
        List<int[]> takenCoordsAndDirections = new List<int[]>();
        int curX = currentPlayer.currentTurnCoords[0];
        int curY = currentPlayer.currentTurnCoords[1];

        //list of taken moves (coordinates same, direction different)
        for (int i = 0; i < validMovesAndDirs.Length; i++)
        {
            if (validMovesAndDirs[i][0] == curX && validMovesAndDirs[i][1] == curY)//one of valids
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

