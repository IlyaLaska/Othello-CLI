using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Board
{
    public int boardLength = 8;
    //public BoardSquare[,] board;
    public PieceEnum[,] board;
    public int turn = 1;
    public int[] lastMove = new int[2];
    public int[] blackHoleCoords;

    public delegate void BoardUpdateEvent();
    public static event BoardUpdateEvent boardUpdateEvent;

    public Board()
    {
        this.board = new PieceEnum[boardLength, boardLength]; //new BoardSquare[boardLength, boardLength];
    }

    public Board(Board board2)
    {
        //this.board = board;
        this.board = new PieceEnum[boardLength, boardLength];//new BoardSquare[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                //this.board[i, j] = new // BoardSquare();
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

        //List<int[]> validMovesList = new List<int[]>();
        int[][][] movesArray = new int[64][][];
        int pos = 0;
        for (int i = 0; i < boardLength; i++)
        {
            for (int j = 0; j < boardLength; j++)
            {
                if (board[i, j] == currentPlayer)//have to check possible moves for that piece
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
        //Console.WriteLine("validMoves:");
        //foreach (var oneMove in validMovesList)
        //{
        //    if(oneMove[0] == 0 && oneMove[1] == 0) Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        //    Console.WriteLine("[{0}]" + " == [" + (char)(oneMove[0]+65)+ "" + (oneMove[1]+1) + "]", string.Join(", ", oneMove));

        //}
        //Console.WriteLine("--------------------------");
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
                if (dirX == 0 && dirY == 0) continue;
                array = GetSuccesfulMoveInDirection(boardSquareCoordinates, dirX, dirY, currentPlayer);
                //Console.WriteLine("Sucessful Move in Dir: [{0}]", string.Join(", ", array));
                if (array[0] == 1) validMovesList.Add(new int[] { array[1], array[2], array[3], array[4] });

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
        //this.PrintBoard();
        while (IsInRange(tempY) && IsInRange(tempX))//while inside board borders
        {

            //Console.WriteLine("Board at " + tempX + ":" + tempY + " " + this.board[tempX, tempY]);
            //Console.WriteLine("Opponent " + opponent);
            if (this.board[tempX, tempY] == opponent)//found opponent
            {
                //Console.WriteLine("Found Opponent" + tempX + ":" + tempY  + " "+ this.board[tempX, tempY]);
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
        //Console.WriteLine("IN MAKEMOVEGetSCORE. ValidMoves len = " + validMovesAndDirs.Length);
        //Console.WriteLine("ValidMovesDirs: ");
        //foreach (var oneMove in validMovesAndDirs)
        //{
        //    Console.WriteLine("[{0}]", string.Join(", ", oneMove));

        //}
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

    //public static Boolean CheckValidMove(SpotEnum[,] Board, SpotEnum Player, int i, int j)
    //{
    //    // check if this empty spt is a valid move
    //    //    -1
    //    // -1  x  +1
    //    //    +1
    //    for (int direction_i = -1; direction_i < 2; direction_i++)      // UP / none / DOWN     (-1,0,1)
    //    {
    //        for (int direction_j = -1; direction_j < 2; direction_j++)  // LEFT/ none / RIGHT   (-1,0,1)
    //        {
    //            if (!(direction_i == 0 && direction_j == 0))         // NOT the same spot! (i,j)
    //            {
    //                // get potential killed enemy soldiers list
    //                List<Point> tmp_lst_pts =
    //                    GetKillCountInMove(Board, Player, i, j, direction_i, direction_j);

    //                if (tmp_lst_pts.Count() > 0)    //Check if there is enemy soldiers to kill (valid move!)
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //    }
    //    return false;
    //}


    //public static List<Point> GetAvailibleMovesSpots(SpotEnum[,] Board, SpotEnum Player)
    //{
    //    List<Point> move_pts = new List<Point>();

    //    for (int j = 1; j <= 8; j++)
    //    {
    //        for (int i = 1; i <= 8; i++)
    //        {
    //            // check if spot is empty for the next move
    //            if (Board[i, j] == SpotEnum.Empty)
    //            {
    //                if (CheckValidMove(Board, Player, i, j))
    //                {
    //                    move_pts.Add(new Point(i, j));
    //                }
    //            }
    //        }

    //    }

    //    return move_pts;
    //}

    //public static List<Point> GetKillList(SpotEnum[,] Board, SpotEnum Player, int i, int j)
    //{
    //    Dictionary<Point, Boolean> KillDic = new Dictionary<Point, Boolean>(); // count all spots that we can kill enemy in this i,j move

    //    for (int direction_i = -1; direction_i < 2; direction_i++)      // UP / none / DOWN     (-1,0,1)
    //    {
    //        for (int direction_j = -1; direction_j < 2; direction_j++)  // LEFT/ none / RIGHT   (-1,0,1)
    //        {
    //            if (!(direction_i == 0 && direction_j == 0))         // NOT the same spot! (i,j)
    //            {
    //                // get potential killed enemy soldiers list
    //                List<Point> tmp_lst_pts =
    //                    GetKillCountInMove(Board, Player, i, j, direction_i, direction_j);

    //                // insert those points in the Points Dictionary
    //                foreach (var item in tmp_lst_pts)
    //                {
    //                    if (!KillDic.ContainsKey(item))
    //                    {
    //                        KillDic.Add(item, true);
    //                    }
    //                }

    //            }
    //        }
    //    }
    //    return KillDic.Keys.ToList();   //retun the points list (from the dictionary)
    //}

    //public static void MakeMove(SpotEnum[,] Board, SpotEnum Player, int i, int j)
    //{
    //    List<Point> KillList = GameModel.GetKillList(Board, Player, i, j);
    //    Board[i, j] = Player;
    //    foreach (var item in KillList)
    //    {
    //        Board[item.X, item.Y] = Player;
    //    }
    //}
}

