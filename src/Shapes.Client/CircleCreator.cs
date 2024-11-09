using Shapes;
using Shapes.Abstractions;
using System.Globalization;

internal class CircleCreator : IShapeCreator
{
    public IShape Create(string input)
    {
        var radius = double.Parse(input, CultureInfo.InvariantCulture);
        return Circle.Create(radius);
    }
}
