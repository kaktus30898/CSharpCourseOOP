namespace ShapeTask;

public class AreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        double shape1Area = shape1.GetArea();
        double shape2Area = shape2.GetArea();
        return shape1Area.CompareTo(shape2Area);
    }
}