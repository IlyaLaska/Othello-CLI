using System;

public class AIPlayer : IPlayer
{
    public AIPlayer(PieceEnum color)
    {
        this.color = color;
        this.score = 2;
    }

    public AIPlayer(IPlayer player)
    {
        this.color = player.color;
        this.score = player.score;
        this.currentTurnCoords = player.currentTurnCoords;
    }
    public int score { get; set; }

    public PieceEnum color { get; set; }
    public int[] currentTurnCoords { get; set; }

    public void UpdateMoves(int[][] validMoves, Board board)
    {
        //Console.WriteLine("AIPlayer, Your availible moves: ");
        //foreach (var oneMove in validMoves)
        //{
        //    Console.WriteLine(((char)(oneMove[0] + 65)) + "" + (oneMove[1] + 1));
        //    //Console.WriteLine("[{0}]", string.Join(", ", oneMove));

        //}
        if (validMoves.Length == 0)
        {
            Console.WriteLine("pass");
        }
        else
        {
            //board.PrintBoard();
            int[] goodMove = AI.GetAntiReversiMove(validMoves, board.Clone(), this.Clone());
            this.currentTurnCoords = goodMove;
            //Console.WriteLine("AI move: " + currentTurnCoords[0] + " " + currentTurnCoords[1]);
            Console.WriteLine((char)(currentTurnCoords[0] + 65) + "" + (currentTurnCoords[1] + 1));
            //board.PrintBoard();
        }
    }

    public AIPlayer Clone() {
        return new AIPlayer(this);
    }

}

