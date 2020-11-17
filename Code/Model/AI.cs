using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public static class AI
{
    public static int bestMemo = int.MinValue;
    //public static int[] m = new int[2];
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
        //Console.WriteLine("Called Optimal Depth: " + depth);
        if (depth == 0 || validMovesAndDirs.Length == 0)
        {
            return new int[] { heuristic(board, player), 0, 0 };

            //int h;
            //if (isMaxPlayer) h = GetScore(board, player.color)[0];
            //else h = GetScore(board, player.color)[1];
            //Console.WriteLine("SCORE: " + h + " isMax: " + isMaxPlayer);
            //return new int[] { h, 0, 0 };
        }
        if (isMaxPlayer) return GetMinMaxSingle(true, validMovesAndDirs, player, board, alpha, beta, depth);
        else return GetMinMaxSingle(false, validMovesAndDirs, player, board, alpha, beta, depth);
    }

    //static int[] GetTurnCoords(int[][] validMoves, Board board, IPlayer player)
    //{
    //    int[][] possibleMoves = FilterUniqueMoves(validMoves);
    //    int[] evaluations = new int[possibleMoves.Length];
    //    for (int i = 0; i < possibleMoves.Length; i++)
    //    {
    //        player.currentTurnCoords = possibleMoves[i];
    //        evaluations[i] = evaluateTurn(false, player, board.Clone(), int.MinValue, int.MaxValue, 4 - 1);
    //    }
    //      if (main_array[i] < minimum) {
    //          minimum = main_array[i];
    //          index_min = i;
  //}
//}
//static int evaluateTurn(bool isMaxPlayer, IPlayer player, Board board, int alpha, int beta, int depth)
//{
//    int[][] possibleMoves = FilterUniqueMoves(validMovesAndDirs);
//    player.currentTurnCoords = possibleMoves[i];
//    Board tempBoard = board.Clone();
//    tempBoard.MakeMoveGetScore(player, validMovesAndDirs);
//    // switchPlayer;
//    player.color = player.color.GetOpponent();

//}

//static public int[] MinMaxAlphaBeta(bool isMaxPlayer, int[][] validMovesAndDirs, IPlayer player, Board board, int alpha, int beta, int depth)
//{


//    if (isMaxPlayer)
//    {
//        int[] maxEval = new int[] { int.MinValue, 0, 0 };
//        for (int i = 0; i < possibleMoves.Length; i++)
//        {

//            int[] turn = possibleMoves[i];
//            int[] evaluation = GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player.color), player, alpha, beta, depth - 1, false);
//            evaluation[1] = player.currentTurnCoords[0];
//            evaluation[2] = player.currentTurnCoords[1];

//            maxEval[(int)Move.score] = Math.Max(maxEval[(int)Move.score], evaluation[(int)Move.score]);
//            int newMax = Math.Max(alpha, maxEval[(int)Move.score]);
//            if (beta <= newMax)
//            {
//                break;
//            }
//        }
//        return maxEval;
//    }
//    else
//    {
//        int[] minEval = new int[] { int.MaxValue, 0, 0 };
//        for (int i = 0; i < possibleMoves.Length; i++)
//        {
//            player.currentTurnCoords = possibleMoves[i];
//            Board tempBoard = board.Clone();
//            tempBoard.MakeMoveGetScore(player, validMovesAndDirs);
//            // switchPlayer;
//            player.color = player.color.GetOpponent();

//            int[] turn = possibleMoves[i];
//            int[] evaluation = GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player.color), player, alpha, beta, depth - 1, true);
//            evaluation[1] = player.currentTurnCoords[0];
//            evaluation[2] = player.currentTurnCoords[1];

//            minEval[(int)Move.score] = Math.Min(minEval[(int)Move.score], evaluation[(int)Move.score]);
//            int newMin = Math.Min(beta, minEval[(int)Move.score]);
//            if (alpha >= newMin)
//            {
//                break;
//            }
//        }
//        return minEval;
//    }
//}
static public int[] GetMinMaxSingle(bool isMaxPlayer, int[][] validMovesAndDirs, IPlayer player, Board board, int alpha, int beta, int depth)
    {
        int[] move2 = new int[] { 0, 0, 0 };
        int[] m = new int[2];
        int[][] possibleMoves = FilterUniqueMoves(validMovesAndDirs);
        //Console.WriteLine("Possible Moves:");
        //foreach (var oneMove in possibleMoves)
        //{
        //    //Console.Write("[{0}] ", string.Join(", ", oneMove));
        //    Console.Write("[{0}{1}] ", (char)(oneMove[0] + 65), (oneMove[1] + 1));

        //}
        //Console.WriteLine();
        if (isMaxPlayer) move2[(int)Move.score] = int.MinValue;
        else move2[(int)Move.score] = int.MaxValue;

        for (int i = 0; i < possibleMoves.Length; i++)
        {
            //Console.WriteLine("-------For start-----------" + " depth: " + depth + " i: " + i);
            player.currentTurnCoords = possibleMoves[i];
            move2[1] = player.currentTurnCoords[0];
            move2[2] = player.currentTurnCoords[1];

            //board.PrintBoard();
            //Console.WriteLine("Chosen: [{0}{1}] ", (char)(move2[1] + 65), (move2[2] + 1));

            Board tempBoard = board.Clone();
            tempBoard.MakeMoveGetScore(player, validMovesAndDirs);

            // switchPlayer;
            //player.color = player.color.GetOpponent();
            IPlayer tempPlayer = (IPlayer) player.Clone();
            tempPlayer.color = tempPlayer.color.GetOpponent();
                //tempBoard.PrintBoard();
            int[][] v = tempBoard.GetValidMovesList(tempPlayer.color);
            //Console.WriteLine("Valid Moves:");
            //foreach (var oneMove in v)
            //{
            //    Console.Write("[{0}] ", string.Join(", ", oneMove));
            //    //Console.Write("[{0}{1}] ", (char)(oneMove[0] + 65), (oneMove[1] + 1));

            //}
            if (isMaxPlayer) move2[(int)Move.score] = Math.Max(GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(tempPlayer.color), tempPlayer, alpha, beta, depth - 1, false)[(int)Move.score], move2[(int)Move.score]);
            else move2[(int)Move.score] = Math.Min(GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(tempPlayer.color), tempPlayer, alpha, beta, depth - 1, true)[(int)Move.score], move2[(int)Move.score]);

            if (isMaxPlayer)
            {
                if (move2[(int)Move.score] > alpha)
                {
                    m[0] = move2[(int)Move.x];
                    m[1] = move2[(int)Move.y];
                }
                alpha = Math.Max(alpha, move2[(int)Move.score]);
                //move2[(int)Move.x] = move[(int)Move.x];
                //move2[(int)Move.y] = move[(int)Move.y];
            }
            else//isMinPlayer
            {
                if (move2[(int)Move.score] < beta)
                {
                    m[0] = move2[(int)Move.x];
                    m[1] = move2[(int)Move.y];
                }
                beta = Math.Min(beta, move2[(int)Move.score]);
            }
            if (beta <= alpha)
            {
                //Console.WriteLine("A= " + alpha + " B= " + beta + ". Pruning");
                break;
            }
            //Console.WriteLine("Move2 is [" + (char)(move2[1] + 65) + "" + (move2[2] + 1) + "]  score:" + move2[0] + ". MAX - " + isMaxPlayer);
            //Console.WriteLine("-------For end-----------" + " depth: " + depth + " i: " + i);
        }


        move2[(int)Move.x] = m[0];
        move2[(int)Move.y] = m[1];
        //Console.WriteLine("So BestMove22 is [" + (char)(move2[1] + 65) + "" + (move2[2] + 1) + "]  score:" + move2[0] + ". MAX - " + isMaxPlayer);
        return move2;
    }

    //static public int[] GetMinMaxSingle(bool isMaxPlayer, int[][] validMovesAndDirs, IPlayer player, Board board, int alpha, int beta, int depth)
    //{
    //    int[] bestMove = new int[] { 0, 0, 0 };//TODO Sometimes we find no good move at all
    //    int[] move;
    //    int[] move2 = new int[] { 0, 0, 0 }; ;
    //    int[][] possibleMoves = FilterUniqueMoves(validMovesAndDirs);
    //    ////////Console.WriteLine("Possible Moves:");
    //    //foreach (var oneMove in possibleMoves)
    //    //{
    //    //    ////////Console.WriteLine("[{0}]", string.Join(", ", oneMove));

    //    //}

    //    if (isMaxPlayer) move2[(int)Move.score] = int.MinValue;
    //    else move2[(int)Move.score] = int.MaxValue;

    //    //if (isMaxPlayer) bestMove[(int)Move.score] = int.MinValue;
    //    //else bestMove[(int)Move.score] = int.MaxValue;

    //    for (int i = 0; i < possibleMoves.Length; i++)
    //    {
    //        //board.PrintBoard();
    //        //Console.WriteLine("-------For start-----------" + " depth: " + depth + " i: " + i);
    //        //Console.WriteLine("At depth: " + depth + ". Checking: [" + possibleMoves[i][0] + ":" + possibleMoves[i][1] + "] possibleMove i = " + (i + 1) + " out of: " + possibleMoves.Length);
    //        player.currentTurnCoords = possibleMoves[i];
    //        //move = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] };
    //        //move2 = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] };
    //        move2[1] = player.currentTurnCoords[0];
    //        move2[2] = player.currentTurnCoords[1];

    //        Board tempBoard = board.Clone();
    //        tempBoard.MakeMoveGetScore(player, validMovesAndDirs);

    //        // switchPlayer;
    //        player.color = player.color.GetOpponent();

    //        if (isMaxPlayer) move2[(int)Move.score] = Math.Max(GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player.color), player, alpha, beta, depth - 1, false)[(int)Move.score], move2[(int)Move.score]);
    //        else move2[(int)Move.score] = Math.Min(GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player.color), player, alpha, beta, depth - 1, true)[(int)Move.score], move2[(int)Move.score]);

    //        //if (isMaxPlayer) move[(int)Move.score] = GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player.color), player, alpha, beta, depth - 1, false)[(int)Move.score];
    //        //else move[(int)Move.score] = GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player.color), player, alpha, beta, depth - 1, true)[(int)Move.score];
    //        //Console.WriteLine("d=" + depth + ". i=" + i + ". " + "----score: " + move[0]);

    //        if (isMaxPlayer)
    //        {
    //            alpha = Math.Max(alpha, move2[(int)Move.score]);
    //            //if (move[(int)Move.score] > alpha)
    //            //{
    //            //    alpha = move[(int)Move.score];
    //            //    // Save the best move so far
    //            //    bestMove[(int)Move.x] = move[(int)Move.x];
    //            //    bestMove[(int)Move.y] = move[(int)Move.y];
    //            //    bestMove[(int)Move.score] = move[(int)Move.score];
    //            //}
    //        }
    //        else//isMinPlayer
    //        {
    //            beta = Math.Min(beta, move2[(int)Move.score]);
    //            //if (move[(int)Move.score] < beta)
    //            //{
    //            //    beta = move[(int)Move.score];
    //            //    // Save the best move so far
    //            //    bestMove[(int)Move.x] = move[(int)Move.x];
    //            //    bestMove[(int)Move.y] = move[(int)Move.y];
    //            //    bestMove[(int)Move.score] = move[(int)Move.score];
    //            //}
    //        }
    //        if (beta <= alpha)
    //        {
    //            //Console.WriteLine("A= " + alpha + " B= " + beta + ". Pruning");
    //            break;
    //        }
    //        //Console.WriteLine("-------For end-----------" + " depth: " + depth + " i: " + i);
    //    }
    //    //Console.WriteLine("So BestMove is" + (char)(bestMove[1]+65) + ":" + (bestMove[2]+1) + "  score:" + bestMove[0] + ". MAX - " + isMaxPlayer);
    //    //bestMemo = bestMove[(int)Move.score];
    //    //Console.WriteLine("Best MOve: " + bestMove)
    //    //Console.WriteLine("So BestMove22 is" + (char)(move2[1] + 65) + ":" + (move2[2] + 1) + "  score:" + move2[0] + ". MAX - " + isMaxPlayer);

    //    return move2;
    //}
    static int[][] FilterUniqueMoves(int[][] validMoves)
    {
        //bool Has(int[][] validMovess, int[] move)
        //{

        //}
        //validMoves.Where(move => Has(vali))
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

    static int boardHeuristic(Board board, IPlayer player)
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
            { -99,  8, -8,  6,  6, -8,  8,-99},
            {   8, 48,-16,  3,  3,-16, 48,  8},
            {  -8,-16,  4,  4,  4,  4,-16, -8},
            {   6,  3,  4,  0,  0,  4,  3,  6},
            {   6,  3,  4,  0,  0,  4,  3,  6},
            {  -8,-16,  4,  4,  4,  4,-16, -8},
            {   8, 48,-16,  3,  3,-16, 48,  8},
            { -99,  8, -8,  6,  6, -8,  8,-99}
        };

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board.board[y, x] == player.color)
                {
                    ////////Console.WriteLine("Board " + (char)(x+65) + ":" + (y+1) + " belongs to " + player.color + " + " + boardSquareWeights[y, x] + " points");
                    playerScore += boardSquareWeights[y, x];
                }
                else if (board.board[y, x] == player.color.GetOpponent())
                {
                    ////////Console.WriteLine("Op Board " + (char)(x + 65) + ":" + (y+1) + " belongs to " + player.color.GetOpponent() + " + " + boardSquareWeights[y, x] + " points");
                    opponentScore += boardSquareWeights[y, x];
                }
            }
        }
        ////////Console.WriteLine(player.color + " score = " + playerScore + " Opp: " + player.color.GetOpponent() + " score = " + opponentScore);
        ////////Console.WriteLine(player.color + " score sum = " + (playerScore - opponentScore));

        //return playerScore - opponentScore;
        int result = playerScore - opponentScore;
        //Console.WriteLine("BoardWeight: " + result*5);
        return result;
    }



    /// ////////////////////////////////////////////////////////////////////////////////////
    /// 

    enum GamePhase
    {
        Early,
        Mid,
        Late
    }
    static int heuristic2(Board board, IPlayer player)
    {
        return 1;
        //double score = GetScore(board, player.color);
        //Console.WriteLine("Score: " + Convert.ToInt32(score * 10));
        //return Convert.ToInt32(score * 10);
    }
    static int heuristic(Board board, IPlayer player)
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
        int boardH = boardHeuristic(board, player);
        int mobility = GetMobility(board, playerColor);
        //Console.WriteLine("HH: " + (boardH + 10 * mobility) + " BoardH: " + boardH + ". MobilityH: " + mobility);
        return boardH +  mobility;
        //return GetScore(board, playerColor);
    }

    public static int GetMobility(Board board, PieceEnum player)
    {
        int currentPlayerMovesLength = board.GetValidMovesList(player).Length;
        int opponentMovesLength = board.GetValidMovesList(player.GetOpponent()).Length;


        //return currentPlayerMovesLength - opponentMovesLength;
        int result = currentPlayerMovesLength - opponentMovesLength;
        //Console.WriteLine("Mobility: " + result*50);
        return result;
    }

    public static int GetPieceCountRatio(Board board, PieceEnum player)
    {
        int[] pieceCounts = GetPieceCount(board, player);
        int result = 100 * (pieceCounts[0] - pieceCounts[1]) / (pieceCounts[0] + pieceCounts[1]);
        //Console.WriteLine("PieceCountRatio: " + result);
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
        //Console.WriteLine("CornerRatio: " + result);
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
        //Console.WriteLine("CornerRatio: " + result);
        return result;
    }

    public static int GetParity(Board board)
    {
        int remDiscs = 60 - board.turn;
        int result = remDiscs % 2 == 0 ? -1 : 1;
        //Console.WriteLine("Parity: " + result);
        return result;
    }

    private const int C = 6; //6
    private const int B = 3; //4
    private const int G = 1; //1
    private const int R = 2; //2

    private const double BACK_PENALTIES = 0.3; //0.3

    //        private val INSIDE_WIN_PER_THRESHOLD = arrayOf(0, 0, 0, 0, 0, 0, 0, 2, 3)

    static int[,] PENALTIES = new int[,]{
        //            0  1  2  3  4  5  6  7
        /*0*/ {C, B, B, B, B, B, B, C},
        /*1*/ {B, B, R, R, R, R, B, B },
        /*2*/ {B, R, B, G, G, B, R, B},
        /*3*/ {B, R, G, B, B, G, R, B},
        /*4*/ {B, R, G, B, B, G, R, B},
        /*5*/ {B, R, B, G, G, B, R, B},
        /*6*/ {B, B, R, R, R, R, B, B},
        /*7*/ {C, B, B, B, B, B, B, C}
    };

    public static int[] GetScore(Board board, PieceEnum playerColor)
    {
        PieceEnum opponent = playerColor.GetOpponent();
        int b = 0;
        int w = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int score = PENALTIES[i, j];
                if (board.board[i, j] == playerColor)
                {
                    b += score;
                    w -= Convert.ToInt32(BACK_PENALTIES * score);
                }
                if (board.board[i, j] == opponent)
                {
                    w += score;
                    b -= Convert.ToInt32(BACK_PENALTIES * score);
                }
            }
        }
        //return new double[] { b, w };
        //Console.WriteLine("PBScore: " + (w-b));
        return new int[] { Math.Max(w, 0), Math.Max(b, 0) };
        //return b-w;
    }


}
//fun minimax(
//        depth: Byte,
//        state: Board.BoardState,
//        min: Byte,
//        max: Byte,
//        turnsPosition: Byte
//    ): Byte
//{
//    val availableTurns: List<Board.Point> ? = board.getAvailableTurns(state)

//    when {
//        availableTurns == null || depth == 0.toByte()-> {
//            val score = state.getScore()
//                return if ((recDepth - depth) % 2 == 0) score.x.toByte() else score.y.toByte()
//            }
//        (recDepth - depth) % 2 == 0-> {
//            val score = state.getScore()
//                if (score.y - score.x < minValue)
//            {
//                minValue = score.y - score.x
//                    minValuePosition = turnsPosition
//                }

//            var maxEval = Byte.MIN_VALUE
//                for (i in availableTurns.indices)
//            {
//                val turn = availableTurns[i]
//                    val evaluation = evaluateTurn(
//                        turn.x.toByte(),
//                        turn.y.toByte(),
//                        (depth - 1).toByte(),
//                        state = state.copyState(),
//                        min = min,
//                        max = max,
//                        turnsPosition = turnsPosition
//                    )
//                    maxEval = maxOf(maxEval, evaluation)
//                    val newMax = maxOf(max, maxEval)
//                    if (min <= newMax)
//                {
//                    break
//                    }
//            }
//            return maxEval
//            }
//        (recDepth - depth) % 2 == 1-> {
//            val score = state.getScore()
//                if (score.x - score.y < minValue)
//            {
//                minValue = score.x - score.y
//                    minValuePosition = turnsPosition
//                }

//            var minEval = Byte.MAX_VALUE
//                for (i in availableTurns.indices)
//            {
//                val turn = availableTurns[i]
//                    val evaluation = evaluateTurn(
//                        turn.x.toByte(),
//                        turn.y.toByte(),
//                        (depth - 1).toByte(),
//                        state = state.copyState(),
//                        min = min,
//                        max = max,
//                        turnsPosition = turnsPosition
//                    )
//                    minEval = minOf(minEval, evaluation)
//                    val newMin = minOf(min, minEval)
//                    if (max >= newMin)
//                {
//                    break
//                    }
//            }
//            return minEval
//            }
//            else -> throw MinimaxNotMetException()
//        }
//}
//public static int eval(Board board, int player)
//{

//    //terminal
//    if (BoardHelper.isGameFinished(board))
//    {
//        return 1000 * evalDiscDiff(board, player);
//    }

//    //semi-terminal

//}

//public int eval(Board board, player player)
//{
//    int mob = evalMobility(board, player);
//    int sc = evalDiscDiff(board, player);
//    return 2 * mob + sc + 1000 * evalCorner(board, player);
//}


//    #region  Heuristic Functions
//    private static int[,] WeightedBoard = new int[9, 9] {{  0,  0,  0,  0,  0,  0,  0,  0,  0},
//                                                             {  0,-99,  8, -8,  6,  6, -8,  8,-99},
//                                                             {  0,  8, 48,-16,  3,  3,-16, 48,  8},
//                                                             {  0, -8,-16,  4,  4,  4,  4,-16, -8},
//                                                             {  0,  6,  3,  4,  0,  0,  4,  3,  6},
//                                                             {  0,  6,  3,  4,  0,  0,  4,  3,  6},
//                                                             {  0, -8,-16,  4,  4,  4,  4,-16, -8},
//                                                             {  0,  8, 48,-16,  3,  3,-16, 48,  8},
//                                                             {  0,-99,  8, -8,  6,  6, -8,  8,-99}};


//    public static float HeFunc_WeightedBoardValue(SpotEnum[,] Board, SpotEnum Player)
//    {
//        float PlayerScores = 0;
//        float OpponentScores = 0;

//        for (int i = 1; i <= 8; i++)
//        {
//            for (int j = 1; j <= 8; j++)
//            {
//                if (Board[i, j] == Player)
//                {
//                    PlayerScores += WeightedBoard[i, j] / 99F;
//                }
//                else if (Board[i, j] != SpotEnum.Empty)
//                {
//                    OpponentScores += WeightedBoard[i, j] / 99F;
//                }
//            }
//        }

//        //////////Console.WriteLine("WeightedBoardValue=" + ((PlayerScores - OpponentScores) / 64).ToString());
//        return (PlayerScores - OpponentScores);
//    }

//    #endregion
//}