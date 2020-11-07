using System;

public class AIPlayer : IPlayer
{
    public AIPlayer(PieceEnum color)
    {
        this.color = color;
        this.score = 2;
    }
    public int score { get; set; }

    public PieceEnum color { get; set; }
    public int[] currentTurnCoords { get; set; }

    public void UpdateMoves(int[][] validMoves, Board board = null)
    {
        if (validMoves.Length == 0)
        {
            Console.WriteLine("pass");
        }
        else
        {
            int[] goodMove = AI.GetAntiReversiMove(validMoves, board, this.color);
            this.currentTurnCoords = goodMove;

            Console.WriteLine((char)(currentTurnCoords[0] + 65) + "" + (currentTurnCoords[1] + 1));
        }
    }

}

