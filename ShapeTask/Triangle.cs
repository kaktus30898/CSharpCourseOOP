namespace ShapeTask;

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
        if (Math.Abs((y3 - y1) * (x2 - x1) - (x3 - x1) * (y2- y1)) < 1.0e-10)
        {
            throw new IOException(" Triangle does not exist");
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

    private (double SideAB, double SideBC, double SideCA) TriangleSides()
    {
        var sideAB = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        var sideBC = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
        var sideCA = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
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

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
        {
            return false;
        }

        Triangle t  = (Triangle)obj;
        return (X1 == t.X1 && Y1 == t.Y1 && X2 == t.X2 && Y2 == t.Y2 && X3 == t.X3 && Y3 == t.Y3);
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
        return $"Triangle: X1Y1 ({X1:f2},{Y1:f2}) X2Y2 ({X2:f2},{Y2:f2}) X3Y3 ({X3:f2},{Y3:f2}) " +
            $"Width {GetWidth():f2} Height {GetHeight():f2} Area {GetArea():f2} Perimeter {GetPerimeter():f2}";
    }
}