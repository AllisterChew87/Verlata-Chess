using Chess.Core.Interfaces;

namespace Chess.Core.Models;
// Assume this class is fully implemented
// Return value is added to make it compilable, do not represent the actual value
// Minor modification to allow unit test execution
public abstract class ChessPiece
{
    private IPosition _currentPosition;

    public IPosition GetCurrentPosition()
    {
        return _currentPosition;
    }

    // Convert to virtual as moq only able to moq for interface or virtual class
    // Return value is an assumption value, do not represent the actual value
    public virtual bool IsEnemyOf(ChessPiece otherPiece)
    {
        return otherPiece == null ? false : true;
    }

    public void Attack()
    {
    }

    protected IPosition SetCurrentPosition(IPosition newPosition)
    {
        _currentPosition = newPosition;

        return newPosition;
    }

    public abstract bool Move(IPosition to, IBoard board);
}
