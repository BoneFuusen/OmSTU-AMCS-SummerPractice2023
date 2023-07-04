using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        const double eps = 1e-6;

        if (a > -eps && a < eps)
        {
            throw new System.ArgumentException();
        }
        if (double.IsInfinity(a+b+c) ||
        double.IsNaN(a + b + c))
        {
            throw new System.ArgumentException();
        }

        double d = b*b-4*a*c;


        if (d > 0 && d > eps)
        {
            if (b != 0) { 
            double x1 = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2, x2 = c / x1; 
            return new double[2] {x1, x2}; 
            }
            else { 
            double x1 = -(b + Math.Sqrt(d)) / 2, x2 = c / x1; 
            return new double[2] {x1, x2}; 
            }
        }
        if (d <= eps && d > -eps)
        {
            d = 0;
            double[] answer = new double[1];
            double x1 = -(b + Math.Sign(b) * Math.Sqrt(d))/(2*a);
            answer[0] = x1;
            return answer;
        }
        else
        {
            return Array.Empty<double>();
        }
    }
}
