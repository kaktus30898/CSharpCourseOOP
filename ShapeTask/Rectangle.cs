namespace ShapeTask;

public class Rectangle : IShape
{
    private double Width { get; set; }
    private double Height { get; set; }

    public Rectangle(double width, double height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width));
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height));
        }

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

    public override bool Equals(object? obj)
    {
        if(ReferenceEquals(obj, this))
        {
            return true;
        }

        if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
        {
            return false;
        }

        Rectangle r = (Rectangle)obj;
        return (Width == r.Width && Height == r.Height);
    }

    public override int GetHashCode()
    {
        int prime = 11;
        int hash = 1;
        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return $"Rectangle: Width {Width:f2} Height {Height:f2} Area {GetArea():f2} Perimeter {GetPerimeter():f2}";
    }
}