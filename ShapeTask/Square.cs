namespace ShapeTask;

public class Square : IShape
{
    private double SideLength { get; set; }

    public Square(double sideLength)
    {
        if (sideLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sideLength));
        }
        SideLength = sideLength;
    }

    public double GetWidth()
    {
        return SideLength;
    }

    public double GetHeight()
    {
        return SideLength;
    }

    public double GetArea()
    {
        return SideLength * 4;
    }

    public double GetPerimeter()
    {
        return SideLength * SideLength;
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

        Square s = (Square)obj;
        return SideLength == s.SideLength; 
    }

    public override int GetHashCode()
    {
        int prime = 11;
        int hash = 1;
        hash = prime * hash + SideLength.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return $"Square: Side Length {SideLength:f2} Area {GetArea():f2} Perimeter {GetPerimeter():f2}";
    }
}