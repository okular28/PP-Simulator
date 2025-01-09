using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

    public class PointTests
    {
        [Fact]
        public void Constructor_ShouldInitializeCoordinates()
        {
            // Arrange
            int x = 5;
            int y = 10;

            // Act
            var point = new Point(x, y);

            // Assert
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var point = new Point(3, 4);

            // Act
            var result = point.ToString();

            // Assert
            Assert.Equal("(3, 4)", result);
        }

        [Theory]
        [InlineData(Direction.Left, 4, 5, 3, 5)]
        [InlineData(Direction.Right, 4, 5, 5, 5)]
        [InlineData(Direction.Up, 4, 5, 4, 6)]
        [InlineData(Direction.Down, 4, 5, 4, 4)]
        public void Next_ShouldReturnCorrectPoint(Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var nextPoint = point.Next(direction);

            // Assert
            Assert.Equal(expectedX, nextPoint.X);
            Assert.Equal(expectedY, nextPoint.Y);
        }

        [Theory]
        [InlineData(Direction.Left, 4, 5, 3, 6)]
        [InlineData(Direction.Right, 4, 5, 5, 4)]
        [InlineData(Direction.Up, 4, 5, 5, 6)]
        [InlineData(Direction.Down, 4, 5, 3, 4)]
        public void NextDiagonal_ShouldReturnCorrectPoint(Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var nextPoint = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(expectedX, nextPoint.X); 
            Assert.Equal(expectedY, nextPoint.Y);
        }

        [Fact]
        public void Next_WithInvalidDirection_ShouldReturnSamePoint()
        {
            // Arrange
            var point = new Point(4, 5);
            var invalidDirection = (Direction)999;

            // Act
            var nextPoint = point.Next(invalidDirection);

            // Assert
            Assert.Equal(point.X, nextPoint.X);
            Assert.Equal(point.Y, nextPoint.Y);
        }

        [Fact]
        public void NextDiagonal_WithInvalidDirection_ShouldReturnSamePoint()
        {
            // Arrange
            var point = new Point(4, 5);
            var invalidDirection = (Direction)999;

            // Act
            var nextPoint = point.NextDiagonal(invalidDirection);

            // Assert
            Assert.Equal(point.X, nextPoint.X);
            Assert.Equal(point.Y, nextPoint.Y);
        }
    }