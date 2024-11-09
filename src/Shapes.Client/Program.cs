using Shapes.Client.Factories;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Выберите фигуру чтобы вычислить ее площадь:");
Console.WriteLine("Клавиша 1 - Треугольник");
Console.WriteLine("Клавиша 2 - Круг");

Console.ForegroundColor = ConsoleColor.Cyan;

var key = Console.ReadKey();

Console.Clear();

try
{
    var text = key.Key switch
    {
        ConsoleKey.D1 => "Введите для создания треугольника три стороны\nПример: 4.0, 5.0, 3.0",
        ConsoleKey.D2 => "Введите для создания круга радиус\nПример: 4.0",
        _ => throw new ArgumentException("Не известная клавиша")
    };
    Console.WriteLine(text);

    var shapeCreator = ShapeCreatorFactory.Create(key.Key);

    var input = Console.ReadLine();

    var shape = shapeCreator.Create(input!);
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Площадь выбранной фигуры: {shape.CalculateArea()}");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
}

Console.ReadKey();
