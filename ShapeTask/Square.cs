namespace ShapeTask;

public class Square : IShape
{
    private double SideLength { get; set; }

    public Square(double sideLength)
    {
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
}