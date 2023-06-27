﻿using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        const double eps = 1e-9;

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
            double[] answer = new double[2];

            double x1 = -(b + Math.Sign(b) * Math.Sqrt(d))/(2*a);
            double x2 = c/x1;

            answer[0] = x1; answer[1] = x2;
            
            return answer;
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
