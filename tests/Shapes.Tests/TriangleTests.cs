using Shapes.Tests.Utils;
using Xunit;

namespace Shapes.Tests;

public class TriangleTests
{
    [Theory, DoubleAutoData]
    public void Create_Should_ReturnTriangle_WhenExistTriangle(double side1, double side2)
    {
        double side3 = (side1 + side2) - 1;

        // Act
        var triangle = Triangle.Create(side1, side2, side3);

        // Assert
        Assert.NotNull(triangle);
        Assert.Equal(side1, triangle.First);
        Assert.Equal(side2, triangle.Second);
        Assert.Equal(side3, triangle.Third);
    }

    [Theory, DoubleAutoData]
    public void Create_Should_ThrowInvalidOperationException_WhenNotExistTriangle(
        double firstSide,
        double secondSide,
        double thirdSide)
    {
        // Arrange
        double[] sides = [firstSide, secondSide, thirdSide];
        var maxIndex = Array.IndexOf(sides, sides.Max());
        sides[maxIndex] = sides.Where((_, i) => i != maxIndex).Sum() + 1;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => Triangle.Create(sides[0], sides[1], sides[2]));
    }

    [Theory]
    [InlineData(3.0, 4.0, 5.0, 6.0)]
    [InlineData(12.0, 12.0, 12.0, 62.353829)]
    [InlineData(54.0, 32.0, 80.0, 606.85336)]
    public void CalculateArea_Should_ReturnCorrectArea(double side1, double side2, double side3, double expected)
    {
        var triangle = Triangle.Create(side1, side2, side3);

        // Act
        double area = triangle.CalculateArea();

        // Assert
        Assert.Equal(expected, area, 5);
    }

    [Theory]
    [InlineData(3.0, 4.0, 5.0)]
    [InlineData(16.0, 14, 21.26029162549)]
    [InlineData(12.0, 2.0, 12.1655250606)]
    public void IsRight_Should_ReturnTrue_WhenRigthTriangle(double side1, double side2, double side3)
    {
        // Arrange
        var triangle = Triangle.Create(side1, side2, side3);

        // Act
        bool isRight = triangle.IsRight();

        // Assert
        Assert.True(isRight);
    }

    [Theory]
    [InlineData(2.0, 2.0, 3.0)]
    [InlineData(12.0, 12.0, 12.0)]
    [InlineData(54.0, 32.0, 80.0)]
    public void IsRight_Should_ReturnFalse_WhenNotRightTriangle(double side1, double side2, double side3)
    {
        // Arrange
        var triangle = Triangle.Create(side1, side2, side3);

        // Act
        bool isRight = triangle.IsRight();

        // Assert
        Assert.False(isRight);
    }

    [Theory]
    [InlineData(2.0, 3.1, 3.0)]
    [InlineData(3.0, 4.0, 5.0)]
    [InlineData(6.0, 2.0, 5.0)]
    public void SetSides_Should_UpdatesSides(double side1, double side2, double side3)
    {
        // Arrange
        var triangle = Triangle.Create(3, 4, 5);

        // Act
        triangle.First = side1;
        triangle.Second = side2;
        triangle.Third = side3;

        // Assert
        Assert.Equal(side1, triangle.First);
        Assert.Equal(side2, triangle.Second);
        Assert.Equal(side3, triangle.Third);
    }

    [Fact]
    public void SetSides_Should_ThrowInvalidOperationException_WhenNotExistTriangle()
    {
        // Arrange
        var triangle = Triangle.Create(3, 4, 5);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => triangle.First = 1);
    }

    [Theory]
    [InlineData(-1000.0)]
    [InlineData(-2.0)]
    [InlineData(0)]
    public void SetSides_Should_ThrowArgumentOutOfRangeException_WhenSideIfNegativeOrZero(double side)
    {
        // Arrange
        var validTriangle = Triangle.Create(3, 4, 5);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => validTriangle.First = side);
        Assert.Throws<ArgumentOutOfRangeException>(() => validTriangle.Second = side);
        Assert.Throws<ArgumentOutOfRangeException>(() => validTriangle.Third = side);

        Assert.Throws<ArgumentOutOfRangeException>(() => Triangle.Create(side, side, side));
    }
}