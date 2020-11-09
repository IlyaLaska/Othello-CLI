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
    public static Board gameBoard;// { get; set; }

    static public int[] GetAntiReversiMove(int[][] validMoves, Board board, IPlayer player)
    {
        int[] move = GetMinMaxOptimal(board, validMoves, player, int.MinValue, int.MaxValue);
        return new int[] { move[1], move[2] };
    }

    //static public int[] GetMinMaxOptimal(Board board, int[][] validMovesAndDirs, IPlayer player, int alpha, int beta, int depth = 10, bool isMaxPlayer = true)
    //{
    //    if (depth == 0 || validMovesAndDirs.Length == 0) return new int[] { heuristic(board, player), 0, 0 };
    //    int[] bestMove = new int[] { 0, 0, 0 };

    //    //int alpha1 = int.MinValue;
    //    //int beta1 = int.MaxValue;
    //    int[] move;
    //    int[][] possibleMoves = FilterUniqueMoves(validMovesAndDirs);
    //    if (isMaxPlayer)
    //    {
    //        bestMove[(int)Move.score] = int.MinValue;

    //        for (int i = 0; i < possibleMoves.Length; i++)
    //        {
    //            player.currentTurnCoords = possibleMoves[i];
    //            move = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] };

    //            System.////////Console.WriteLine("Valid Moves (in AI - max):");
    //            foreach (var oneMove in validMovesAndDirs)
    //            {
    //                System.////////Console.WriteLine("[{0}]", string.Join(", ", oneMove));

    //            }

    //            board.MakeMoveGetScore(player, validMovesAndDirs);
    //            validMovesAndDirs = board.GetValidMovesList(player);
    //            move[(int)Move.score] = GetMinMaxOptimal(board, validMovesAndDirs, player, alpha, beta, depth - 1, false)[(int)Move.score];
    //            if (move[(int)Move.score] > alpha)
    //            {
    //                alpha = move[(int)Move.score];
    //                // Save the best move so far
    //                bestMove[(int)Move.x] = move[(int)Move.x];
    //                bestMove[(int)Move.y] = move[(int)Move.y];
    //                bestMove[(int)Move.score] = move[(int)Move.score];
    //            }

    //            if (beta <= alpha)
    //            {
    //                break;
    //            }

    //        }
    //        return bestMove;

    //    }
    //    else
    //    {
    //        bestMove[(int)Move.score] = int.MaxValue;

    //        for (int i = 0; i < possibleMoves.Length; i++)
    //        {
    //            player.currentTurnCoords = possibleMoves[i];
    //            move = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] }; ;

    //            System.////////Console.WriteLine("Valid Moves (in AI - min):");
    //            foreach (var oneMove in validMovesAndDirs)
    //            {
    //                System.////////Console.WriteLine("[{0}]", string.Join(", ", oneMove));

    //            }

    //            board.MakeMoveGetScore(player, validMovesAndDirs);
    //            validMovesAndDirs = board.GetValidMovesList(player);
    //            move[(int)Move.score] = GetMinMaxOptimal(board, validMovesAndDirs, player, alpha, beta, depth - 1, true)[(int)Move.score];
    //            if (move[(int)Move.score] < beta)
    //            {
    //                beta = move[(int)Move.score];
    //                // Save the best move so far
    //                bestMove[(int)Move.x] = move[(int)Move.x];
    //                bestMove[(int)Move.y] = move[(int)Move.y];
    //                bestMove[(int)Move.score] = move[(int)Move.score];
    //            }

    //            if (beta <= alpha)
    //            {
    //                break;
    //            }

    //        }
    //        return bestMove;

    //    }

    //    //if is_player_minimizer:
    //    //    value = -math.inf
    //    //    for move in state.possible_moves():
    //    //        evaluation = minimax(move, max_depth - 1, False, alpha, beta)
    //    //        min = min(value, evaluation)
    //    //        beta = min(beta, evaluation)
    //    //        if beta <= alpha:
    //    //            break
    //    //        return value

    //    //value = math.inf
    //    //for move in state.possible_moves(){
    //    //        evaluation = minimax(move, max_depth - 1, True, alpha, beta)
    //    //    max = max(value, evaluation)
    //    //    alpha = max(alpha, evaluation)
    //    //    if beta <= alpha:
    //    //        break
    //    //    return value
    //    //    }

    //}
    static public int[] GetMinMaxOptimal(Board board, int[][] validMovesAndDirs, IPlayer player, int alpha, int beta, int depth = 4, bool isMaxPlayer = true)
    {
        ////////Console.WriteLine("==========================");
        if (depth == 0 || validMovesAndDirs.Length == 0) return new int[] { heuristic(board, player), 0, 0 };
        if (isMaxPlayer) return GetMinMaxSingle(true, validMovesAndDirs, player, board, alpha, beta, depth);
        else return GetMinMaxSingle(false, validMovesAndDirs, player, board, alpha, beta, depth);
    }

    static public int[] GetMinMaxSingle(bool isMaxPlayer, int[][] validMovesAndDirs, IPlayer player, Board board, int alpha, int beta, int depth)
    {
        int[] bestMove = new int[] { 0, 0, 0 };
        int[] move;
        int[][] possibleMoves = FilterUniqueMoves(validMovesAndDirs);
        ////////Console.WriteLine("Possible Moves:");
        foreach (var oneMove in possibleMoves)
        {
            ////////Console.WriteLine("[{0}]", string.Join(", ", oneMove));

        }

        if (isMaxPlayer) bestMove[(int)Move.score] = int.MinValue;
        else bestMove[(int)Move.score] = int.MaxValue;

        for (int i = 0; i < possibleMoves.Length; i++)
        {
            //board.PrintBoard();
            //Console.WriteLine("-------For start-----------" + " depth: " + depth + " i: " + i);
            //Console.WriteLine("At depth: " + depth + ". Checking: [" + possibleMoves[i][0] + ":" + possibleMoves[i][1] + "] possibleMove i = " + (i + 1) + " out of: " + possibleMoves.Length);
            player.currentTurnCoords = possibleMoves[i];
            move = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] };

            if (isMaxPlayer) ////////Console.WriteLine("Valid Moves (in AI - max):");
            ////////Console.WriteLine("Valid Moves (in AI - min):");
            foreach (var oneMove in validMovesAndDirs)
            {
                ////////Console.WriteLine("[{0}]", string.Join(", ", oneMove));

            }
            Board tempBoard = board.Clone();
            tempBoard.MakeMoveGetScore(player, validMovesAndDirs);//dies here
            // switchPlayerlone();

            player.color = player.color.GetOpponent();
            //validMovesAndDirs = tempBoard.GetValidMovesList(player);

            if (isMaxPlayer) move[(int)Move.score] = GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player), player, alpha, beta, depth - 1, false)[(int)Move.score];
            else move[(int)Move.score] = GetMinMaxOptimal(tempBoard, tempBoard.GetValidMovesList(player), player, alpha, beta, depth - 1, true)[(int)Move.score];

            if (isMaxPlayer)
            {
                if (move[(int)Move.score] > alpha)
                {
                    alpha = move[(int)Move.score];
                    // Save the best move so far
                    bestMove[(int)Move.x] = move[(int)Move.x];
                    bestMove[(int)Move.y] = move[(int)Move.y];
                    bestMove[(int)Move.score] = move[(int)Move.score];
                }
            }
            else//isMinPlayer
            {
                if (move[(int)Move.score] < beta)
                {
                    beta = move[(int)Move.score];
                    // Save the best move so far
                    bestMove[(int)Move.x] = move[(int)Move.x];
                    bestMove[(int)Move.y] = move[(int)Move.y];
                    bestMove[(int)Move.score] = move[(int)Move.score];
                }
            }
            if (beta <= alpha)
            {
                //////Console.WriteLine("A= " + alpha + " B= " + beta + ". Pruning");
                break;
            }
            //Console.WriteLine("-------For end-----------" + " depth: " + depth + " i: " + i);
        }
        //////Console.WriteLine("So BestMove is" + bestMove[1] + ":" + bestMove[2] + "  score:" + bestMove[0]);
        return bestMove;
    }
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
            if(!exists) filtered.Add(new int[] { validMoves[i][0], validMoves[i][1] });
        }

        //for (int i = 0; i < validMoves.Length; i++)
        //{
        //    for (int j = 0; j < filtered.Count; j++)
        //    {
        //        if(validMoves[i][0] == filtered[j][0] && validMoves[i][1] == filtered[j][1])//
        //        {
        //            //break;
        //            goto END;
        //        }
            
        //    }
        //    filtered.Add(new int[] { validMoves[i][0], validMoves[i][1] });
        //END:
        //    continue;
        //}
        return filtered.ToArray();
        //return validMoves.Select(move => new int[] { move[0], move[1]}).Distinct().ToArray();
        //HashSet<int[]> uniqueMoveCoords = new HashSet<int[]>();
        //foreach (int[] move in validMoves)
        //{
        //    uniqueMoveCoords.Add(new int[] { move[0], move[1] });
        //}
        //return uniqueMoveCoords.ToArray();
    }
    static int heuristic(Board board, IPlayer player)
    {
        int playerScore = 0;
        int opponentScore = 0;
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
                if (board.board[y, x].belongsToPlayer == player.color)
                {
                    ////////Console.WriteLine("Board " + (char)(x+65) + ":" + (y+1) + " belongs to " + player.color + " + " + boardSquareWeights[y, x] + " points");
                    playerScore += boardSquareWeights[y, x];
                }
                else if (board.board[y, x].belongsToPlayer == player.color.GetOpponent())
                {
                    ////////Console.WriteLine("Op Board " + (char)(x + 65) + ":" + (y+1) + " belongs to " + player.color.GetOpponent() + " + " + boardSquareWeights[y, x] + " points");
                    opponentScore += boardSquareWeights[y, x];
                }
            }
        }
        ////////Console.WriteLine(player.color + " score = " + playerScore + " Opp: " + player.color.GetOpponent() + " score = " + opponentScore);
        ////////Console.WriteLine(player.color + " score sum = " + (playerScore - opponentScore));
        return playerScore - opponentScore;
    }
}

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