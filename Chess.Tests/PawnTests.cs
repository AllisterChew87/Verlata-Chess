using Chess.Core.Interfaces;
using Chess.Core.Models;
using Chess.Core.Pieces;
using Moq;

namespace Chess.Tests
{
    public class PawnTests
    {
        private Pawn CreatePawn(int startX, int startY)
        {
            var pawn = new Pawn(new PositionImpl(startX, startY));

            return pawn;
        }

        [Fact]
        public void White_Move_OneStepForward_EmptySquare_ReturnTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 1);
            var to = new PositionImpl(0, 2);

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.GetPiece(to)).Returns((ChessPiece) null);

            // action
            var result = pawn.Move(to, mockBoard.Object);

            // assert
            Assert.True(result);
            Assert.Equal(to.GetX(), pawn.GetCurrentPosition().GetX());
            Assert.Equal(to.GetY(), pawn.GetCurrentPosition().GetY());
        }

        [Fact]
        public void White_Move_InvalidForward_EmptySquare_ReturnFalse()
        {
            // arrange
            var pawn = CreatePawn(0, 1);
            var to = new PositionImpl(0, 4);

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            var result = pawn.Move(to, mockBoard.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void White_Move_TwoStepsForward_FirstMove_EmptySquare_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 1);
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
        public void White_Move_TwoStepsForward_NotFirstMove_EmptySquare_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(0, 2);
            var to = new PositionImpl(0, 4);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void White_Move_DiagonalAttack_ValidEnemyPiece_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(1, 1);
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
        public void White_Move_DiagonalAttack_InvalidValidEnemyPiece_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(1, 1);
            var to = new PositionImpl(2, 2);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void Black_Move_OneStepForward_EmptySquare_ReturnTrue()
        {
            // arrange
            var pawn = CreatePawn(0, 6);
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
        public void Black_Move_InvalidForward_EmptySquare_ReturnFalse()
        {
            // arrange
            var pawn = CreatePawn(0, 6);
            var to = new PositionImpl(0, 3);

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            var result = pawn.Move(to, mockBoard.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void Black_Move_TwoStepsForward_FirstMove_EmptySquare_ReturnsTrue()
        {
            // arrange
            // declaring x = 1 to indicate first move
            var pawn = CreatePawn(0, 6);
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
        public void Black_Move_TwoStepsForward_NotFirstMove_EmptySquare_ReturnsFalse()
        {
            // arrange
            // declaring x = 1 to indicate first move
            var pawn = CreatePawn(0, 5);
            var to = new PositionImpl(0, 3);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void Black_Move_DiagonalAttack_ValidEnemyPiece_ReturnsTrue()
        {
            // arrange
            var pawn = CreatePawn(5, 5);
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
        public void Black_Move_DiagonalAttack_InvalidValidEnemyPiece_ReturnsFalse()
        {
            // arrange
            var pawn = CreatePawn(5, 5);
            var to = new PositionImpl(4, 4);

            var boardMock = new Mock<IBoard>();
            boardMock.Setup(b => b.GetPiece(to)).Returns((ChessPiece)null);

            // action
            bool result = pawn.Move(to, boardMock.Object);

            // assert
            Assert.False(result);
        }
    }
}