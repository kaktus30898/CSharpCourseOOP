namespace ShapeTask;

class Program
{
    static void Main()
    {
        var shapes = new IShape[]
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

        Console.WriteLine($"Max area {GetMaxAreaShape(shapes)}");
        Console.WriteLine($"2-nd max perimeter {GetMaxPerimeterShape(shapes)}");
    }

    private static IShape GetMaxAreaShape(IShape[] shapes)
    {
        Array.Sort(shapes, new AreaComparer());
        return shapes[^1];
    }

    private static IShape GetMaxPerimeterShape(IShape[] shapes)
    {
        Array.Sort(shapes, new AreaComparer());
        return shapes[^2];
    }
}