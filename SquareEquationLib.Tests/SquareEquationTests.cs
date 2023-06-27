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

    [Fact]
    public void D_is_zero()
    {
        var res = SquareEquation.Solve(16, -40, 25);
        Type resType = res.GetType();
        Assert.True(resType.IsArray && res.Length == 1);
    }

    [Fact]
    public void D_lessthan_zero()
    {
        var res = SquareEquation.Solve(2, 5, 16);
        Assert.True(res == Array.Empty<double>());
    }

    [Fact]
    public void D_morethan_zero()
    {
        var res = SquareEquation.Solve(2, 15, 16);
        Type resType = res.GetType();
        Assert.True(resType.IsArray && res.Length == 2);        
    }

    [Fact]
    public void D_is_eps()
    {
        var res = SquareEquation.Solve(1, Math.Sqrt(eps), 0);

        Type resType = res.GetType();
        Assert.True(resType.IsArray && res.Length == 1);
    }
}
}