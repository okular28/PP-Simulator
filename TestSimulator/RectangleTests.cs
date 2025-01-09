using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectCoordinates()
    {
        // Arrange
        int x1 = 2, y1 = 3, x2 = 5, y2 = 7;

        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(7, rectangle.Y2);
    }

    [Fact]
    public void Constructor_ShouldReorderCoordinatesIfNecessary()
    {
        // Arrange
        int x1 = 5, y1 = 7, x2 = 2, y2 = 3;

        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(7, rectangle.Y2);
    }

    [Fact]
    public void Constructor_ShouldThrowExceptionForThinRectangle()
    {
        // Arrange
        int x1 = 2, y1 = 3, x2 = 2, y2 = 7;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        Assert.Equal("nie chcemy 'chudych' prostokątów", exception.Message);
    }

    [Fact]
    public void Constructor_ShouldThrowExceptionForThinRectangle2()
    {
        // Arrange
        var p1 = new Point(2, 3);
        var p2 = new Point(2, 9);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Rectangle(p1, p2));
    Assert.Equal("nie chcemy 'chudych' prostokątów", exception.Message);
    }

    [Fact]
    public void Constructor_WithPoints_ShouldInitializeCorrectCoordinates()
    {
        // Arrange
        var p1 = new Point(2, 3);
        var p2 = new Point(5, 7);

        // Act
        var rectangle = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(7, rectangle.Y2);
    }

    [Theory]
    [InlineData(3, 4, true)]
    [InlineData(2, 3, true)]
    [InlineData(5, 7, true)]
    [InlineData(6, 8, false)]
    [InlineData(1, 2, false)]
    public void Contains_ShouldReturnCorrectResult(int px, int py, bool expectedResult)
    {
        // Arrange
        var rectangle = new Rectangle(2, 3, 5, 7);
        var point = new Point(px, py);

        // Act
        var result = rectangle.Contains(point);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Arrange
        var rectangle = new Rectangle(2, 3, 5, 7);

        // Act
        var result = rectangle.ToString();

        // Assert
        Assert.Equal("(2, 3):(5, 7)", result);
    }
}
