﻿namespace ShapeTask;

public class Triangle : IShape
{
    private double X1 { get; set; }
    private double Y1 { get; set; }
    private double X2 { get; set; }
    private double Y2 { get; set; }
    private double X3 { get; set; }
    private double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = x3;
    }

    public double GetWidth()
    {
        return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
    }

    public double GetHeight()
    {
        return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
    }

    private (double SideAB, double SideBC, double SideCA) TriangleSides()
    {
        var sideAB = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        var sideBC = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
        var sideCA = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - X3, 2));
        return (sideAB, sideBC, sideCA);
    }

    public double GetArea()
    {
        var (sideAB, sideBC, sideCA) = TriangleSides();
        var triangleSemiperimeter = (sideAB + sideBC + sideCA) / 2;
        return Math.Sqrt(triangleSemiperimeter * (triangleSemiperimeter - sideAB) * (triangleSemiperimeter - sideBC) *
            (triangleSemiperimeter - sideCA));
    }

    public double GetPerimeter()
    {
        var (sideAB, sideBC, sideCA) = TriangleSides();
        return sideAB + sideBC + sideCA;
    }
}