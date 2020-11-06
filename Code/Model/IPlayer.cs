using System;

public interface IPlayer
{
    int score { get; set; }
    bool isHuman { get; set; }
    PlayerEnum color { get; set; }
    int[] currentTurnCoords { get; set; }

    void UpdateMoves(int[][] possibleMoveCoords);
}
