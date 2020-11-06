using System;

public class HumanPlayer : IPlayer
{
    public HumanPlayer(PlayerEnum color)
    {
        this.color = color;
        this.score = 2;
        this.isHuman = true;
    }
    public bool isHuman { get; set; }
    public int score { get; set; }
    public PlayerEnum color { get; set; }
    public int[] currentTurnCoords { get; set; }
    public void UpdateMoves(int[][] possibleMoveCoords, bool movePassed) {
        //Console.WriteLine("Moves for Human");
        //foreach (int[] movee in possibleMoveCoords)
        //{
        //    Console.WriteLine((char)(movee[0] + 65) + "" + (movee[1] + 1));
        //}
        //Get from console
        string move = Console.ReadLine();
        if (move == "pass")
        {
            this.currentTurnCoords = null;
        } else
        {
            int[] moveArr = ConvertMoveToArray(move);
            //Console.WriteLine("Move: " + moveArr[0] + ":" + moveArr[1]);
            this.currentTurnCoords = moveArr;
        }   
    }
    int[] ConvertMoveToArray(string move)
    {
        int yPos = (int)Char.GetNumericValue(move, 1) - 1;
        int xPos = (int)move[0] - 65;
        return new int[] { xPos, yPos };
    }
}
