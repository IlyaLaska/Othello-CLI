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
        return GetMinMaxOptimal(board, validMoves, player, int.MinValue, int.MaxValue);
    }

    static public int[] GetMinMaxOptimal(Board board, int[][] validMoves, IPlayer player, int alpha, int beta, int depth = 10, bool isMaxPlayer = true)
    {
        //return null;

        if (depth == 0 || validMoves.Length == 0) return new int[] { heuristic(board, player), 0, 0 };
        int[] bestMove = new int[] { 0, 0, 0 };

        //int alpha1 = int.MinValue;
        //int beta1 = int.MaxValue;
        int[] move;
        int[] possibleMoves = FilterUniqueMoves(validMoves);
        if (isMaxPlayer)
        {
            bestMove[(int)Move.score] = int.MinValue;

            for (int i = 0; i < validMoves.Length; i++)
            {
                move = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] };
                board.MakeMoveGetScore(player, validMoves);
                move[(int)Move.score] = GetMinMaxOptimal(board, validMoves, player, alpha, beta, depth - 1, false)[(int)Move.score];
                if (move[(int)Move.score] > alpha)
                {
                    alpha = move[(int)Move.score];
                    // Save the best move so far
                    bestMove[(int)Move.x] = move[(int)Move.x];
                    bestMove[(int)Move.y] = move[(int)Move.y];
                    bestMove[(int)Move.score] = move[(int)Move.score];
                }

                if (beta <= alpha)
                {
                    break;
                }

            }

        }
        else
        {
            bestMove[(int)Move.score] = int.MaxValue;

            move = new int[] { 0, player.currentTurnCoords[0], player.currentTurnCoords[1] }; ;
            for (int i = 0; i < validMoves.Length; i++)
            {
                board.MakeMoveGetScore(player, validMoves);
                move[(int)Move.score] = GetMinMaxOptimal(board, validMoves, player, alpha, beta, depth - 1, true)[(int)Move.score];
                if (move[(int)Move.score] < beta)
                {
                    beta = move[(int)Move.score];
                    // Save the best move so far
                    bestMove[(int)Move.x] = move[(int)Move.x];
                    bestMove[(int)Move.y] = move[(int)Move.y];
                    bestMove[(int)Move.score] = move[(int)Move.score];
                }

                if (beta <= alpha)
                {
                    break;
                }

            }

        }

        //if is_player_minimizer:
        //    value = -math.inf
        //    for move in state.possible_moves():
        //        evaluation = minimax(move, max_depth - 1, False, alpha, beta)
        //        min = min(value, evaluation)
        //        beta = min(beta, evaluation)
        //        if beta <= alpha:
        //            break
        //        return value

        //value = math.inf
        //for move in state.possible_moves(){
        //        evaluation = minimax(move, max_depth - 1, True, alpha, beta)
        //    max = max(value, evaluation)
        //    alpha = max(alpha, evaluation)
        //    if beta <= alpha:
        //        break
        //    return value
        //    }

    }
    static int[] FilterUniqueMoves(int[] validMoves)
    {
        validMoves
    }
    static int heuristic(Board board, IPlayer player)
    {
        return 0;
    }

    #region  Heuristic Functions
    private static int[,] WeightedBoard = new int[9, 9] {{  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                                             {  0,-99,  8, -8,  6,  6, -8,  8,-99},
                                                             {  0,  8, 48,-16,  3,  3,-16, 48,  8},
                                                             {  0, -8,-16,  4,  4,  4,  4,-16, -8},
                                                             {  0,  6,  3,  4,  0,  0,  4,  3,  6},
                                                             {  0,  6,  3,  4,  0,  0,  4,  3,  6},
                                                             {  0, -8,-16,  4,  4,  4,  4,-16, -8},
                                                             {  0,  8, 48,-16,  3,  3,-16, 48,  8},
                                                             {  0,-99,  8, -8,  6,  6, -8,  8,-99}};


    public static float HeFunc_WeightedBoardValue(SpotEnum[,] Board, SpotEnum Player)
    {
        float PlayerScores = 0;
        float OpponentScores = 0;

        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                if (Board[i, j] == Player)
                {
                    PlayerScores += WeightedBoard[i, j] / 99F;
                }
                else if (Board[i, j] != SpotEnum.Empty)
                {
                    OpponentScores += WeightedBoard[i, j] / 99F;
                }
            }
        }

        //Console.WriteLine("WeightedBoardValue=" + ((PlayerScores - OpponentScores) / 64).ToString());
        return (PlayerScores - OpponentScores);
    }

    #endregion
}