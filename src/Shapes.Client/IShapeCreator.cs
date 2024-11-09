using Shapes.Abstractions;

internal interface IShapeCreator
{
    IShape Create(string input);
}
