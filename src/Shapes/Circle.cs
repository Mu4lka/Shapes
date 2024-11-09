using Shapes.Abstractions;

namespace Shapes;

/// <summary>
/// Круг
/// </summary>
public record Circle : IShape
{
    private double _radius;

    private Circle(double radius)
    {
        _radius = radius;
    }

    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius
    {
        get => _radius;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _radius = value;
        }
    }

    /// <inheritdoc/>
    public double CalculateArea()
        => Math.PI * _radius * _radius;

    /// <summary>
    /// Создать круг
    /// </summary>
    /// <param name="radius">Радиус</param>
    /// <returns><see cref="Circle"/></returns>
    public static Circle Create(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);

        return new(radius);
    }
}