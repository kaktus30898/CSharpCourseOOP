namespace ShapeTask;

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be less than 0");
        }

        Radius = radius;
    }

    public double GetWidth()
    {
        return Radius * 2;
    }

    public double GetHeight()
    {
        return Radius * 2;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
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

        Circle c = (Circle)obj;
        return Radius == c.Radius;
    }

    public override int GetHashCode()
    {
        int prime = 11;
        int hash = 1;
        hash = prime * hash + Radius.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return $"Circle: Radius = {Radius:f2} | Diameter = {GetHeight():f2} | Area = {GetArea():f2} | Perimeter = {GetPerimeter():f2}";
    }
}