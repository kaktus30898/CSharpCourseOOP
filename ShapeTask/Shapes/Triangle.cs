namespace ShapeTask.Shapes;

public class Triangle : IShape
{
    public const double Epsilon = 1.0e-10;
    
    public double X1 { get; }
    
    public double Y1 { get; }
    
    public double X2 { get; }
    
    public double Y2 { get; }
    
    public double X3 { get; }
    
    public double Y3 { get; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        if (Math.Abs((y3 - y1) * (x2 - x1) - (x3 - x1) * (y2 - y1)) < Epsilon)
        {
            throw new ArgumentException("Triangle does not exist");
        }

        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = y3;
    }

    public double GetWidth()
    {
        return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
    }

    public double GetHeight()
    {
        return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
    }

    private static double CalcSideLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
    }

    private (double SideAB, double SideBC, double SideCA) GetTriangleSides()
    {
        double sideAB = CalcSideLength(X2, Y2, X1, Y1);
        double sideBC = CalcSideLength(X3, Y2, X3, Y1);
        double sideCA = CalcSideLength(X1, Y1, X3, Y3);
        return (sideAB, sideBC, sideCA);
    }

    public double GetArea()
    {
        (double sideAB, double sideBC, double sideCA) = GetTriangleSides();
        double triangleSemiperimeter = (sideAB + sideBC + sideCA) / 2;
        return Math.Sqrt(triangleSemiperimeter * (triangleSemiperimeter - sideAB) * (triangleSemiperimeter - sideBC) *
            (triangleSemiperimeter - sideCA));
    }

    public double GetPerimeter()
    {
        (double sideAB, double sideBC, double sideCA) = GetTriangleSides();
        return sideAB + sideBC + sideCA;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        Triangle t = (Triangle)obj;
        return X1 == t.X1 && Y1 == t.Y1 && X2 == t.X2 && Y2 == t.Y2 && X3 == t.X3 && Y3 == t.Y3;
    }

    public override int GetHashCode()
    {
        int prime = 11;
        int hash = 1;
        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return $"Triangle: ({X1:f2}, {Y1:f2}), ({X2:f2}, {Y2:f2}), ({X3:f2},{Y3:f2}) " +
            $"Width = {GetWidth():f2} | Height = {GetHeight():f2} | Area = {GetArea():f2} | Perimeter = {GetPerimeter():f2}";
    }
}