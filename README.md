# Shapes

Библиотека, которая содержит различные геометрические фигуры.

## Быстрый старт
* Просто клонируйте репозиторий:

```
git clone https://github.com/Mu4lka/Shapes.git
```

## Доступные фигуры
* Triangle - треугольник с тремя сторонами.
* Circle - круг.

## Валидация

При создании и изменении фигур используется валидация, чтобы, например, треугольник оставался треугольником. Это относится и к другим фигурам :)

## Интерфейс IShape

Интерфейс содержит метод `CalculateArea` для вычисления площади фигур, что позволяет добавлять новые фигуры с поддержкой вычисления площади.

## Пример создания фигуры и вычисления площади с последующим выводом в консоль:

```csharp
var triangle = Triangle.Create(1, 1, 1);
var area = triangle.CalculateArea();
Console.WriteLine(area);
```

## Фигуры покрыты Unit-тестами с помощью библиотек `xUnit` и `AutoFixture.Xunit2`