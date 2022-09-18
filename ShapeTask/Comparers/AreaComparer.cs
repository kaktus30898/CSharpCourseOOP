using ShapeTask.Shapes;

namespace ShapeTask.Comparers;

public class AreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        return shape1.GetArea().CompareTo(shape2.GetArea());
    }
}