namespace RangeTask;

public class Range
{
    private double From { get; set; }
    private double To { get; set; }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public double GetLength()
    {
        return To - From;
    }

    public bool IsInside(double number)
    {
        return number >= From && number <= To;
    }

    public bool IsCrossing(Range b)
    {
        return From <= b.To || To >= b.From;
    }

    public Range CrossIntervals(Range b)
    {
        if (IsCrossing(b))
        {
            return new Range(b.From, To);
        }

        return null;
    }

    public Range[] CombineIntervals(Range b)
    {
        if (IsCrossing(b))
        {
            return new[] { new Range(From, b.To) };
        }

        return new[] { this, b };
    }

    public Range[] SubtractIntervals(Range b)
    {
        if (From >= b.From && To <= b.To)
        {
            return Array.Empty<Range>();
        }

        if (From >= b.From && To > b.To && IsCrossing(b))
        {
            return new[] { new Range(b.To, To) };
        }

        if (From < b.From && To <= b.To && IsCrossing(b))
        {
            return new[] { new Range(From, b.From) };
        }

        if (From < b.From && To > b.To)
        {
            return new[] { new Range(From, b.From), new Range(b.To, To) };
        }

        return new[] { this };
    }

}