using Shapes.Tests.Utils;
using Xunit;

namespace Shapes.Tests;

public class CircleTests
{
    [Theory, DoubleAutoData]
    public void Create_Should_ReturnCircle_WhenRadiusIsPositive(double radius)
    {
        //Act
        var circle = Circle.Create(radius);

        //Assert
        Assert.NotNull(circle);
        Assert.True(radius > 0);
        Assert.Equal(radius, circle.Radius);
    }

    [Theory, DoubleAutoData(multiplier: -100)]
    public void Create_Should_ThrowArgumentOutOfRangeException_WhenRadiusIsNegative(double radius)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Circle.Create(radius));
    }

    [Fact]
    public void Create_Should_ThrowArgumentOutOfRangeException_WhenRadiusIsZero()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => Circle.Create(0));
    }

    [Theory, DoubleAutoData]
    public void CalculateArea_Should_ReturnCorrectArea(double radius)
    {
        // Arrange
        var circle = Circle.Create(radius);

        // Act
        var actual = circle.CalculateArea();

        // Assert
        Assert.Equal(Math.PI * radius * radius, actual);
    }

    [Theory, DoubleAutoData(multiplier: -100)]
    public void SetRadius_Should_ThrowArgumentOutOfRangeException_RadiusIsNegative(double newRadius)
    {
        // Arrange
        var circle = Circle.Create(1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => circle.Radius = newRadius);
    }

    [Fact]
    public void SetRadius_Should_ThrowArgumentOutOfRangeException_WhenRadiusIsZero()
    {
        // Arrange
        var circle = Circle.Create(1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => circle.Radius = 0);
    }

    [Theory, DoubleAutoData]
    public void SetRadius_Should_UpdatedRadius_WhenRadiusIsPositive(double newRadius)
    {
        // Arrange
        var circle = Circle.Create(1);

        // Act
        circle.Radius = newRadius;

        // Assert
        Assert.Equal(newRadius, circle.Radius);
    }
}