namespace Chess.Core.Interfaces;
// Renamed Position to IPosition to align with C# interface naming conventions.
public interface IPosition
{
    int GetX();
    int GetY();
    int GetDistance(IPosition otherPosition);
    bool IsDiagonalOf(IPosition otherPosition);
    bool IsForwardOf(IPosition otherPosition);
    bool IsBackwardOf(IPosition otherPosition);
    bool IsLateralTo(IPosition otherPosition);
}