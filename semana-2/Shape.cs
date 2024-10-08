namespace Paint;

public abstract class Shape(Point start, Point end, Color color)
{
    public Point Start { get; set; } = start;

    public Point End { get; set; } = end;

    public Color Color { get; set; } = color;
} 