namespace ShapeTask;

public class AreaComparer : IComparer<IShape>
{
    public int Compare(IShape? x, IShape? y)
    {
        var xArea = x.GetArea();
        var yArea = y.GetArea();

        if (xArea < yArea)
        {
            return -1;
        }

        if (xArea > yArea)
        {
            return 1;
        }

        return 0;
    }
}