using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public static class AI
{
    enum Move
    {
        score,
        x,
        y
    }
    public static Board gameBoard;

    static public int[] GetAntiReversiMove(int[][] validMoves, Board board, IPlayer player)
    {
        int[] move = GetMinMaxOptimal(board, validMoves, player, int.MinValue, int.MaxValue);
        return new int[] { move[1], move[2] };
    }

    static public int[] GetMinMaxOptimal(Board board, int[][] validMovesAndDirs, IPlayer player, int alpha, int beta, int depth = 4, bool isMaxPlayer = true)
    {
        if (depth == 0 || validMovesAndDirs.Length == 0)
        {
            return new int[] { heuristic(board, player, isMaxPlayer), 0, 0 };
        }
        if (isMaxPlayer) return GetMinMaxSingle(true, validMovesAndDirs, player, board, alpha, beta, depth);
        else return GetMinMaxSingle(false, validMovesAndDirs, player, board, alpha, beta, depth);
    }

static public int[] GetMinMaxSingle(bool isMaxPlayer, int[][] validMovesAndDirs, IPlayer player, Board board, int alpha, int beta, int depth)
    {
        int[] curMove = new int[] { 0, 0, 0 };
        int[] bestMove = new int[2];
        int[][] possibleMoves = FilterUniqueMoves(validMovesAndDirs);

        if (isMaxPlayer) curMove[(int)Move.score] = int.MinValue;
        else curMove[(int)Move.score] = int.MaxValue;

        for (int i = 0; i < possibleMoves.Length; i++)
        {
            player.currentTurnCoords = possibleMoves[i];
            curMove[1] = player.currentTurnCoords[0];
            curMove[2] = player.currentTurnCoords[1];


            Board tempBoard = board.Clone();
            tempBoard.MakeMoveGetScore(player, validMovesAndDirs);

            // switchPlayer;
            IPlayer tempPlayer = (IPlayer) player.Clone();
            tempPlayer.color = tempPlayer.color.GetOpponent();
            //int[][] v = tempBoard.GetValidMovesList(tempPlayer.color);
            if (isMaxPlayer) curMove[(int)Move.score] = Math.Max(GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(tempPlayer.color), tempPlayer, alpha, beta, depth - 1, false)[(int)Move.score], curMove[(int)Move.score]);
            else curMove[(int)Move.score] = Math.Min(GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(tempPlayer.color), tempPlayer, alpha, beta, depth - 1, true)[(int)Move.score], curMove[(int)Move.score]);

            if (isMaxPlayer)
            {
                if (curMove[(int)Move.score] > alpha)
                {
                    bestMove[0] = curMove[(int)Move.x];
                    bestMove[1] = curMove[(int)Move.y];
                }
                alpha = Math.Max(alpha, curMove[(int)Move.score]);
            }
            else//isMinPlayer
            {
                if (curMove[(int)Move.score] < beta)
                {
                    bestMove[0] = curMove[(int)Move.x];
                    bestMove[1] = curMove[(int)Move.y];
                }
                beta = Math.Min(beta, curMove[(int)Move.score]);
            }
            if (beta <= alpha)
            {
                break;
            }
        }

        curMove[(int)Move.x] = bestMove[0];
        curMove[(int)Move.y] = bestMove[1];
        return curMove;
    }
    static int[][] FilterUniqueMoves(int[][] validMoves)
    {
        List<int[]> filtered = new List<int[]>();
        for (int i = 0; i < validMoves.Length; i++)
        {
            bool exists = false;
            for (int j = 0; j < filtered.Count; j++)
            {
                if (validMoves[i][0] == validMoves[j][0] && validMoves[i][1] == validMoves[j][1])
                {
                    exists = true;
                }
            }
            if (!exists) filtered.Add(new int[] { validMoves[i][0], validMoves[i][1] });
        }
        return filtered.ToArray();
    }

    static int boardHeuristic(Board board, IPlayer player, bool isMax)
    {
        int playerScore = 0;
        int opponentScore = 0;

        //int[,] boardSquareWeights = new int[8, 8] {
        //    {-100,  20, -20, -20, -20, -20, 20,-100},
        //    {  20,  50,  -15,  10,  10,  -15, 50,  20},
        //    { -20, -15,   -4,  4,  4,  -4,-15, -20},
        //    { -20,   10,   4,  0,  0,  4,  10,  -20},
        //    { -20,   10,   4,  0,  0,  4,  10,  -20},
        //    { -20, -15,   -4,   4,   4,   -4,-15, -20},
        //    {  20,  50,  -15,  10,  10,  -15, 50,  20},
        //    {-100,  20, -20, -20, -20, -20, 20,-100}
        //};

        

        //int[,] boardSquareWeights = new int[8, 8] {
        //    { -99,  8, -8,  6,  6, -8,  8,-99},
        //    {   8, 48,-16,  3,  3,-16, 48,  8},
        //    {  -8,-16,  4,  4,  4,  4,-16, -8},
        //    {   6,  3,  4,  0,  0,  4,  3,  6},
        //    {   6,  3,  4,  0,  0,  4,  3,  6},
        //    {  -8,-16,  4,  4,  4,  4,-16, -8},
        //    {   8, 48,-16,  3,  3,-16, 48,  8},
        //    { -99,  8, -8,  6,  6, -8,  8,-99}
        //};

        //int[,] boardSquareWeights = new int[8, 8] {//FROM GREEN SITE
        //    { -99,  48, -8,  6,  6, -8, 48,-99},
        //    {  48,  -8,-16,  3,  3,-16, -8, 48},
        //    {  -8, -16,  4,  4,  4,  4,-16, -8},
        //    {   6,   3,  4,  0,  0,  4,  3,  6},
        //    {   6,   3,  4,  0,  0,  4,  3,  6},
        //    {  -8, -16,  4,  4,  4,  4,-16, -8},
        //    {  48,  -8,-16,  3,  3,-16, -8, 48},
        //    { -99,  48, -8,  6,  6, -8, 48,-99}
        //};


        int[,] boardSquareWeights = new int[8, 8] {
            {100, 4,50,50,50,50, 4,100},
            {  4,50,20,20,20,20,50, 4},
            { 50,20,50, 4, 4,50,20,50},
            { 50,20, 4, 0, 0, 4,20,50},
            { 50,20, 4, 0, 0, 4,20,50},
            { 50,20,50, 4, 4,50,20,50},
            {  4,50,20,20,20,20,50, 4},
            {100, 4,50,50,50,50, 4,100}
        };

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board.board[y, x] == player.color)
                {
                    playerScore += boardSquareWeights[y, x];
                }
                else if (board.board[y, x] == player.color.GetOpponent())
                {
                    opponentScore += boardSquareWeights[y, x];
                }
            }
        }
        int result = opponentScore - playerScore;
        return result;
    }
    enum GamePhase
    {
        Early,
        Mid,
        Late
    }
    static int heuristic(Board board, IPlayer player, bool isMax)
    {
        PieceEnum playerColor = player.color;
        //int result;
        //switch (GetGamePhase(board))
        //{
        //    case GamePhase.Early:
        //        //return -1000 * GetCornerRatio(board, playerColor) + 50 * GetMobility(board, playerColor);
        //        //return 5 * boardHeuristic(board, player) + 50 * GetMobility(board, playerColor);
        //        result = -1000 * GetCornerRatio(board, playerColor) + 10 * boardHeuristic(board, player) + 100 * GetMobility(board, playerColor);
        //        break;
        //    case GamePhase.Mid:
        //        //return -1000 * GetCornerRatio(board, playerColor) + 20 * GetMobility(board, playerColor) - 10 * GetPieceCountRatio(board, playerColor) + 100 * GetParity(board);
        //        //return 5 * boardHeuristic(board, player) + 20 * GetMobility(board, playerColor) - 10 * GetPieceCountRatio(board, playerColor);// + 100 * GetParity(board);
        //        result = -1000 * GetCornerRatio(board, playerColor) + 10 * boardHeuristic(board, player) + 80 * GetMobility(board, playerColor) - 10 * GetPieceCountRatio(board, playerColor);// + 100 * GetParity(board);
        //        break;
        //    case GamePhase.Late:
        //    default:
        //        //return -1000 * GetCornerRatio(board, playerColor) + 100 * GetMobility(board, playerColor) - 500 * GetPieceCountRatio(board, playerColor) + 500 * GetParity(board);
        //        //return 5 * boardHeuristic(board, player) + 100 * GetMobility(board, playerColor) - 500 * GetPieceCountRatio(board, playerColor);// + 500 * GetParity(board);
        //        result = -1000 * GetCornerRatio(board, playerColor) + 10 * boardHeuristic(board, player) + 100 * GetMobility(board, playerColor) - 500 * GetPieceCountRatio(board, playerColor);// + 500 * GetParity(board);
        //        break;
        //}
        ////Console.WriteLine("Total: " + result);
        //return result;
        int boardH = boardHeuristic(board, player, isMax);
        //int mobility = GetMobility(board, playerColor);
        //Console.WriteLine("HH: " + (boardH + 10 * mobility) + " BoardH: " + boardH + ". MobilityH: " + mobility);
        return boardH;// - 5*mobility;
        //return -1000 * GetCornerRatio(board, playerColor) + boardH +  mobility;
        //return GetScore(board, playerColor);
    }
    //LEGACY functions
    public static int GetMobility(Board board, PieceEnum player)
    {
        int currentPlayerMovesLength = board.GetValidMovesList(player).Length;
        int opponentMovesLength = board.GetValidMovesList(player.GetOpponent()).Length;

        int result = currentPlayerMovesLength - opponentMovesLength;
        return result;
    }

    public static int GetPieceCountRatio(Board board, PieceEnum player)
    {
        int[] pieceCounts = GetPieceCount(board, player);
        int result = 100 * (pieceCounts[0] - pieceCounts[1]) / (pieceCounts[0] + pieceCounts[1]);
        return result;
    }

    public static int[] GetPieceCount(Board board, PieceEnum playerColor)
    {
        int playerPieceCount = 0;
        int opponentPieceCount = 0;
        PieceEnum opponentColor = playerColor.GetOpponent();
        for (int i = 0; i < board.boardLength; i++)
        {
            for (int j = 0; j < board.boardLength; j++)
            {
                if (board.board[i, j] == playerColor) playerPieceCount++;
                else if (board.board[i, j] == opponentColor) opponentPieceCount++;
            }
        }
        return new int[] { playerPieceCount, opponentPieceCount };
    }

    private static GamePhase GetGamePhase(Board board)
    {
        if (board.turn < 20) return GamePhase.Early;
        else if (board.turn <= 58) return GamePhase.Mid;
        else return GamePhase.Late;
    }

    public static int GetCornerRatio(Board board, PieceEnum player)
    {
        int myCorners = 0;
        int opCorners = 0;
        PieceEnum opponent = player.GetOpponent();

        if (board.board[0, 0] == player) myCorners++;
        if (board.board[7, 0] == player) myCorners++;
        if (board.board[0, 7] == player) myCorners++;
        if (board.board[7, 7] == player) myCorners++;

        if (board.board[0, 0] == opponent) opCorners++;
        if (board.board[7, 0] == opponent) opCorners++;
        if (board.board[0, 7] == opponent) opCorners++;
        if (board.board[7, 7] == opponent) opCorners++;

        int result = 100 * (myCorners - opCorners) / (myCorners + opCorners + 1);
        return result;
    }

    public static int GetBlackHoleRatio(Board board, PieceEnum player)
    {
        int myPieces = 0;
        int opPieces = 0;
        PieceEnum opponent = player.GetOpponent();
        int blackHoleX = board.blackHoleCoords[0];
        int blackHoleY = board.blackHoleCoords[1];

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (board.board[blackHoleY + i, blackHoleX + j] == player) myPieces++;
                if (board.board[blackHoleY + i, blackHoleX + j] == opponent) opPieces++;
            }
        }

        int result = 100 * (myPieces - opPieces) / (myPieces + opPieces + 1);
        return result;
    }

    public static int GetParity(Board board)
    {
        int remDiscs = 60 - board.turn;
        int result = remDiscs % 2 == 0 ? -1 : 1;
        return result;
    }

}
