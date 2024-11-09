using Shapes.Abstractions;

namespace Shapes.Client.Factories;

internal interface IShapeCreator
{
    IShape Create(string input);
}
