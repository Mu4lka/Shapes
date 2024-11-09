using Shapes;
using Shapes.Abstractions;
using System.Globalization;

namespace Shapes.Client.Factories;

internal class TriangleCreator : IShapeCreator
{
    public IShape Create(string input)
    {
        var sides = input
            .Split(", ", 3, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToList();
        return Triangle.Create(sides[0], sides[1], sides[2]);
    }
}
