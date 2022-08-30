namespace ShapeTask;

public class Rectangle : IShape
{
    private double Width { get; set; }
    private double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public double GetWidth()
    {
        return Width;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return (Height + Width) * 2;
    }
}