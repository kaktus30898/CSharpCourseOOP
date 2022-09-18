namespace ShapeTask.Shapes;

public class Square : IShape
{
    public double SideLength { get; }

    public Square(double sideLength)
    {
        if (sideLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sideLength), sideLength, "Side length cannot be less than or equal to 0");
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
        return SideLength * SideLength;
    }

    public double GetPerimeter()
    {
        return SideLength * 4;
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
        return $"Square: Side Length = {SideLength:f2} | Area = {GetArea():f2} | Perimeter = {GetPerimeter():f2}";
    }
}