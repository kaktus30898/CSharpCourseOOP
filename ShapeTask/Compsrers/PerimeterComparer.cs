namespace ShapeTask;

public class PerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        double shape1Perimeter = shape1.GetPerimeter();
        double shape2Perimeter = shape2.GetPerimeter();
        return shape1Perimeter.CompareTo(shape2Perimeter);
    }
}