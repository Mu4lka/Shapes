internal class ShapeCreatorFactory
{
    public static IShapeCreator Create(ConsoleKey key)
        => key switch
        {
            ConsoleKey.D1 => new TriangleCreator(),
            ConsoleKey.D2 => new CircleCreator(),
            _ => throw new ArgumentException(),
        };
}