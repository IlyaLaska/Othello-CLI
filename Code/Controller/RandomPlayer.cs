using System;

public class CPUPlayer : IPlayer
{
    public CPUPlayer(PlayerEnum color)
    {
        this.color = color;
        this.score = 2;
        this.isHuman = false;
    }
    public int score { get; set; }

    public bool isHuman { get; set; }
    public PlayerEnum color { get; set; }
    public int[] currentTurnCoords { get; set; }

    public void UpdateMoves(int[][] validMoves, bool skipped)
    {
        //Console.WriteLine("Moves for CPU");
        //foreach (int[] movee in validMoves)
        //{
        //    Console.WriteLine((char)(movee[0] + 65) +""+ (movee[1] + 1));
        //}
        if (skipped)
        {
            Console.WriteLine("pass");
            return;
        }
        System.Random random = new System.Random();
        int move = random.Next(0, validMoves.Length);
        this.currentTurnCoords = new int[] { validMoves[move][0], validMoves[move][1] };
        Console.WriteLine((char)(currentTurnCoords[0] + 65) + "" + (currentTurnCoords[1] + 1));
    }

}
