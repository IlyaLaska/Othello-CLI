using System;
using static Reversi.GameMaster;

public class HumanPlayer : IPlayer
{
    public HumanPlayer(PieceEnum color)
    {
        this.color = color;
        this.score = 2;
    }
    public int score { get; set; }
    public PieceEnum color { get; set; }
    public int[] currentTurnCoords { get; set; }
    public void UpdateMoves(int[][] possibleMoveCoords, Board board = null) {
        string move = Console.ReadLine();
        if (move == "pass")
        {
            this.currentTurnCoords = null;
        } else
        {
            int[] moveArr = ConvertMoveToArray(move);
            this.currentTurnCoords = moveArr;
        }   
    }
}
