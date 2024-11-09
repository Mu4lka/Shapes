namespace Shapes.Abstractions;

/// <summary>
/// Фигура
/// </summary>
public interface IShape
{
    /// <summary>
    /// Расчитать площадь
    /// </summary>
    /// <returns>Площадь</returns>
    double CalculateArea();
}
