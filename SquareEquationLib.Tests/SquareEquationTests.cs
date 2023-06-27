using SquareEquationLib;
using System;

namespace SquareEquations.Tests{

public class SquareEquationTests
{
    const double eps = 1e-9;

    [Theory]
    [InlineData(-eps/2, 1, 1)]
    [InlineData(eps/2, 2, 2)]
    [InlineData(0, 1, 1)]
    public void AisZero(double a, double b, double c)
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }

    [Fact]
    public void Is_A_NaN()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(double.NaN, 1, 1));
    }

    [Fact]
    public void Is_B_NaN()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.NaN, 1));
    }

    [Fact]
    public void Is_C_NaN()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, 1, double.NaN));
    }

    [Fact]
    public void Is_A_Inf()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(double.PositiveInfinity, 1, 1));
    }

    [Fact]
    public void Is_B_Inf()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, double.PositiveInfinity, 1));
    }

    [Fact]
    public void Is_C_Inf()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(1, 1, double.PositiveInfinity));
    }
}
}