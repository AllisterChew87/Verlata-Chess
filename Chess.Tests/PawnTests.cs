using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Models.Enum;
using Chess.Core.Pieces;
using Moq;

namespace Chess.Tests
{
    // Tests case is based on the assumption of board.GetPiece(IPosition) returning null for empty squares
    public class PawnTests
    {
        private Pawn CreatePawn(int startX, int startY, PieceColor color)
        {
            return new Pawn(new PositionImpl(startX, startY), color);
        }

        [Fact]
        public void PawnMove_OutOfBoardBounds_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(0, 1, PieceColor.White);
            var to = new PositionImpl(0, -1);

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            var result = pawn.Move(to, mockBoard.Object);

            // assert
            Assert.False(result);
        }

        #region white pawn tests
        [Fact]
        public void WhitePawnMove_Backward_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(0, 1, PieceColor.White);
            var to = new PositionImpl(0, 0);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void WhitePawnMove_OneSquareForward_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 1, PieceColor.White);
            var to = new PositionImpl(0, 2);

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            var result = pawn.Move(to, mockBoard.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void WhitePawnMove_TwoSquaresForwardFromInitialPosition_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 1, PieceColor.White);
            var to = new PositionImpl(0, 3);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void WhitePawnMove_DiagonalWithoutEnemy_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(1, 1, PieceColor.White);
            var to = new PositionImpl(2, 2);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void WhitePawnMove_DiagonalWithEnemy_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(1, 1, PieceColor.White);
            var to = new PositionImpl(2, 2);

            var enemyMock = new Mock<ChessPiece>();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns(enemyMock.Object);

            var pawnMock = new Mock<ChessPiece>();
            pawnMock.Setup(p => p.IsEnemyOf(enemyMock.Object)).Returns(true);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void WhitePawnMove_Horizontally_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(1, 1, PieceColor.White);
            var to = new PositionImpl(2, 2);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }
        #endregion

        #region black pawn tests
        [Fact]
        public void BlackPawnMove_Backward_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(0, 6, PieceColor.Black);
            var to = new PositionImpl(0, 7);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void BlackPawnMove_OneSquareForward_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 6, PieceColor.Black);
            var to = new PositionImpl(0, 5);

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            var result = pawn.Move(to, mockBoard.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void BlackPawnMove_TwoSquaresForwardFromInitialPosition_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 6, PieceColor.Black);
            var to = new PositionImpl(0, 4);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void BlackPawnMove_DiagonalWithoutEnemy_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(5, 5, PieceColor.Black);
            var to = new PositionImpl(4, 4);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void BlackPawnMove_DiagonalWithEnemy_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(5, 5, PieceColor.Black);
            var to = new PositionImpl(4, 4);

            var enemyMock = new Mock<ChessPiece>();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns(enemyMock.Object);

            var pawnMock = new Mock<ChessPiece>();
            pawnMock.Setup(p => p.IsEnemyOf(enemyMock.Object)).Returns(true);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void BlackPawnMove_Horizontally_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(5, 5, PieceColor.White);
            var to = new PositionImpl(4, 4);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }
        #endregion
    }
}