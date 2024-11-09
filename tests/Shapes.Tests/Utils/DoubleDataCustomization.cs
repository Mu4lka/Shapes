using AutoFixture;

namespace Shapes.Tests.Utils;

internal class DoubleDataCustomization(double _multiplier = 100) : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<double>(c => c.FromFactory(() => Random.Shared.NextDouble() * _multiplier + 0.01));
    }
}
