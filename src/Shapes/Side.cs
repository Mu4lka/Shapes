namespace Shapes;

public struct Side
{
    private double _length;

    public Side(double length)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        _length = length;
    }

    public double Length
    {
        get => _length;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            _length = value;
        }
    }

    public override string ToString()
        => _length.ToString();
}