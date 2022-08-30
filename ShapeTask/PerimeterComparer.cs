namespace ShapeTask;

public class PerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape? x, IShape? y)
    {
        var xPerimeter = x.GetPerimeter();
        var yPerimeter = y.GetPerimeter();
        
        if (xPerimeter < yPerimeter)
        {
            return -1;
        }

        if (xPerimeter > yPerimeter)
        {
            return 1;
        }

        return 0;
    }
}