namespace ShapeTask;

public class Circle : IShape
{
    private double Radius { get; }

    public Circle(double radius)
    {
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
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return Radius.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}