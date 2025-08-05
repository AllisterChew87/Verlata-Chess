using Chess.Core.Interfaces;

namespace Chess.Core.Models;
// Assume this class is fully implemented
// Return value is added to make it compilable, do not represent the actual value
// Minor modification to allow unit test execution
public class PositionImpl : IPosition
{
    private int _x;
    private int _y;

    public PositionImpl(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int GetDistance(IPosition otherPosition)
    {
        throw new NotImplementedException();
    }

    public int GetX()
    {
        return _x;
    }

    public int GetY()
    {
        return _y;
    }

    public bool IsBackwardOf(IPosition otherPosition)
    {
        throw new NotImplementedException();
    }

    public bool IsDiagonalOf(IPosition otherPosition)
    {
        throw new NotImplementedException();
    }

    public bool IsForwardOf(IPosition otherPosition)
    {
        throw new NotImplementedException();
    }

    public bool IsLateralTo(IPosition otherPosition)
    {
        throw new NotImplementedException();
    }
}