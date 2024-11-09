using AutoFixture;
using AutoFixture.Xunit2;

namespace Shapes.Tests.Utils;

internal class DoubleAutoDataAttribute(double multiplier = 100)
    : AutoDataAttribute(() => new Fixture().Customize(new DoubleDataCustomization(multiplier)));