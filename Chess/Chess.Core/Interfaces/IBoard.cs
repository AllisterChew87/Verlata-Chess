using Chess.Core.Models;

namespace Chess.Core.Interfaces;
// Renamed Board to IBoard to align with C# interface naming conventions.
public interface IBoard
{
    // Renamed getPiece to GetPiece to follow C# naming conventions.
    ChessPiece GetPiece(IPosition position);
}