namespace Shapes.Abstractions;

/// <summary>
/// Фигура
/// </summary>
public interface IShape
{
    /// <summary>
    /// Рассчитать площадь
    /// </summary>
    /// <returns>Площадь</returns>
    double CalculateArea();
}
