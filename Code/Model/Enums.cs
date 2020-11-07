public enum PieceEnum
{
	none,
	black,
	white,
	blackHole
}


public enum Direction
{
    NW,
    N,
	NE,
	E,
	SE,
	S,
	SW,
	W
}

public static class PieceEnumExtensions
{
    public static PieceEnum GetOpponent(this PieceEnum colour)
    {
        if (colour == PieceEnum.black) return PieceEnum.white;
        else if (colour == PieceEnum.white) return PieceEnum.black;
        else return PieceEnum.none;
    }
}
