namespace ShapeTask;

class Program
{
    static void Main()
    {
        var shapes = new IShape[]
        {
            new Circle(5),
            new Square(7),
            new Triangle(1, 1, 7, 5, 9, 4),
            new Rectangle(2, 5),
            new Circle(6),
            new Rectangle(9, 6),
            new Square(2),
            new Triangle(2, 6, 5, 7, 4, 3)
        };

        PrintShapeInfo(GetMaxAreaShape(shapes), "Max area");
        PrintShapeInfo(GetMaxPerimeterShape(shapes), "2-nd max perimeter");
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

    private static void PrintShapeInfo(IShape shape, string name)
    {
        Console.WriteLine($"{name}:");
        Console.WriteLine($"{shape} Width {shape.GetWidth():f2} Height {shape.GetHeight():f2}");
        Console.WriteLine($"Area {shape.GetArea():f2} Perimeter {shape.GetPerimeter():f2}");
        Console.WriteLine();
    }
}