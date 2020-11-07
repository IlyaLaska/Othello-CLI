using System;

public interface IPlayer
{
    int score { get; set; }
    PieceEnum color { get; set; }
    int[] currentTurnCoords { get; set; }

    void UpdateMoves(int[][] possibleMoveCoords, Board board = null);
}
