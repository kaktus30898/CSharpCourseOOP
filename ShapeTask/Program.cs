namespace ShapeTask;

class Program
{
    public const double Epsilon = 1.0e-10;
    static void Main()
    {
        IShape[] shapes = new IShape[]
        {
            new Circle(5),
            new Square(7),
            new Triangle(1, 1, 20, 20, 1, 40),
            new Rectangle(2, 5),
            new Circle(2),
            new Rectangle(5, 6),
            new Square(2),
            new Triangle(2, 6, 8, 1, 4, 3)
        };

        Console.WriteLine($"Max area {GetMaxAreaShape(shapes)?.ToString() ?? "not found"}");
        Console.WriteLine($"2-nd max perimeter {GetSecondPerimeterShape(shapes)?.ToString() ?? "not found"}");
    }

    private static IShape GetMaxAreaShape(IShape[] shapes)
    {
        if (shapes is null || shapes.Length == 0)
        {
            return null;
        }

        Array.Sort(shapes, new AreaComparer());
        return shapes[^1];
    }

    private static IShape GetSecondPerimeterShape(IShape[] shapes)
    {
        if (shapes is null || shapes.Length < 2)
        {
            return null;
        }

        Array.Sort(shapes, new AreaComparer());
        return shapes[^2];
    }
}