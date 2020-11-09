using System;

public class RandomPlayer : IPlayer
{
    public RandomPlayer(PieceEnum color)
    {
        this.color = color;
        this.score = 2;
    }
    public int score { get; set; }

    public PieceEnum color { get; set; }
    public int[] currentTurnCoords { get; set; }

    public void UpdateMoves(int[][] validMoves, Board board)
    {
        if (validMoves.Length == 0)
        {
            Console.WriteLine("pass");
        } else
        {
            System.Random random = new System.Random();
            int move = random.Next(0, validMoves.Length);
            this.currentTurnCoords = new int[] { validMoves[move][0], validMoves[move][1] };

            Console.WriteLine((char)(currentTurnCoords[0] + 65) + "" + (currentTurnCoords[1] + 1));
        }
    }
}
