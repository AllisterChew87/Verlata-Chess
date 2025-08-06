using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Enum;
using System.Drawing;

namespace Chess.Core.Pieces;

public class Pawn : ChessPiece
{
    private readonly PieceColor _color;

    // Initialize the Pawn with a starting position
    public Pawn(IPosition startPosition, PieceColor color)
    {
        SetCurrentPosition(startPosition);
        _color = color;
    }

    private bool IsWithinBoardBounds(int x, int y)
    {
        return x >= 0 && x <= 7 && y >= 0 && y <= 7;
    }

    public override bool Move(IPosition to, IBoard board)
    {
        // Retrieve x and y coordinates of the target position
        var targetX = to.GetX();
        var targetY = to.GetY();
        if (!IsWithinBoardBounds(targetX, targetY))
        {
            return false;
        }

        // Identify the current position
        // Retrieve x and y coordinates of the current position
        var currentPosition = GetCurrentPosition();
        var fromX = currentPosition.GetX();
        var fromY = currentPosition.GetY();

        // Prevent backward movement
        var verticalMovement = targetY - fromY;
        var direction = (_color == PieceColor.White) ? 1 : -1;
        if (direction * verticalMovement <= 0)
        {
            return false;
        }

        // Identify if it's a first move
        // Assuming the board is 8x8 and the pawns start at row 1 for white and row 6 for black
        var isFirstMove = fromY == 1 || fromY == 6;

        // Identify if it's in the same x coordinate
        var horizontalDirection = targetX - fromX == 0;

        // Retrieve the target board position
        var targetPosition = board.GetPiece(to);

        // Ensure it is in horizontal direction and the target position is empty
        if (horizontalDirection && targetPosition == null)
        {
            // pawn can only move one square forward if it is not the first move
            // Math.Abs will return the absolute value of the vertical movement
            // eg if verticalMovement is -1 or 1, it will return 1
            if (Math.Abs(verticalMovement) == 1)
            {
                SetCurrentPosition(to);
                return true;
            }

            // pawn can only move two squares forward if it is the first move
            // Math.Abs will return the absolute value of the vertical movement
            // eg if verticalMovement is -2 or 2, it will return 2
            if (isFirstMove && Math.Abs(verticalMovement) == 2)
            {
                SetCurrentPosition(to);
                return true;
            }

            // Other than the above move, the rest is invalid
            return false;
        }

        // Pawn able to to move diagonally to capture an enemy piece
        // Check if target position is not null and it is an enemy piece
        if (!horizontalDirection && targetPosition != null && IsEnemyOf(targetPosition))
        {
            // pawn can only move one square horizontal
            // Math.Abs will return the absolute value of the vertical movement
            // eg if verticalMovement is -1 or 1, it will return 1
            if (Math.Abs(verticalMovement) == 1)
            {
                Attack();
                SetCurrentPosition(to);
                return true;
            }
        }

        return false;
    }
}