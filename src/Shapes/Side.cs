namespace Shapes;

/// <summary>
/// Сторона
/// </summary>
public struct Side
{
    private double _length;

    public Side(double length)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        _length = length;
    }

    /// <summary>
    /// Длина
    /// </summary>
    public double Length
    {
        get => _length;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _length = value;
        }
    }
}