using Shapes.Abstractions;

namespace Shapes;

/// <summary>
/// Треугольник с тремя сторонами
/// </summary>
public record Triangle : IShape
{
    private Side _first;
    private Side _second;
    private Side _third;

    private Triangle(Side first, Side second, Side third)
    {
        _first = first;
        _second = second;
        _third = third;
    }

    /// <summary>
    /// Длина первой стороны
    /// </summary>
    public double First
    {
        get => _first.Length;
        set
        {
            var side = new Side(value);
            ThrowExceptionIfNotExist(side, _second, _third);
            _first = side;
        }
    }

    /// <summary>
    /// Длина второй стороны
    /// </summary>
    public double Second
    {
        get => _second.Length;
        set
        {
            var side = new Side(value);
            ThrowExceptionIfNotExist(_first, side, _third);
            _second = side;
        }
    }

    /// <summary>
    /// Длина третьей стороны
    /// </summary>
    public double Third
    {
        get => _third.Length;
        set
        {
            var side = new Side(value);
            ThrowExceptionIfNotExist(_first, _second, side);
            _third = side;
        }
    }

    /// <inheritdoc/>
    public double CalculateArea()
    {
        var semiPerimeter = (First + Second + Third) / 2;
        return Math.Sqrt(
            semiPerimeter 
            * (semiPerimeter - First)
            * (semiPerimeter - Second) 
            * (semiPerimeter - Third));
    }

    /// <summary>
    /// Прямоугольный ли?
    /// </summary>
    /// <returns><see langword="true"/>, если треугольник является прямоугольным, иначе <see langword="false"/></returns>
    public bool IsRight()
    {
        double[] sides = [First, Second, Third];
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-9;
    }

    /// <summary>
    /// Создать <see cref="Triangle"/>
    /// </summary>
    /// <param name="first">Длина первой стороны</param>
    /// <param name="second">Длина второй стороны</param>
    /// <param name="third">Длина третьей стороны</param>
    /// <returns><see cref="Triangle"/></returns>
    public static Triangle Create(double first, double second, double third)
    {
        var firstSide = new Side(first);
        var secondSide = new Side(second);
        var thirdSide = new Side(third);

        ThrowExceptionIfNotExist(firstSide, secondSide, thirdSide);

        return new Triangle(firstSide, secondSide, thirdSide);
    }

    /// <summary>
    /// Сущесвует ли? В качестве входных параметров стороны
    /// </summary>
    /// <param name="first">Длина первой стороны</param>
    /// <param name="second">Длина второй стороны</param>
    /// <param name="third">Длина третьей стороны</param>
    /// <returns></returns>
    private static bool IsExist(double first, double second, double third)
        => first + second > third && first + third > second && second + third > first;

    /// <summary>
    /// Выбосить исключение <see cref="InvalidOperationException"/> если треугольник не существует
    /// </summary>
    /// <param name="first">Первая сторона</param>
    /// <param name="second">Вторая сторона</param>
    /// <param name="third">Третья сторона</param>
    /// <exception cref="InvalidOperationException"></exception>
    private static void ThrowExceptionIfNotExist(Side first, Side second, Side third)
    {
        if (IsExist(first.Length, second.Length, third.Length))
            return;

        throw new InvalidOperationException(
                $"A triangle with sides {first}, {second}, {third} cannot exist."
            );
    }
}