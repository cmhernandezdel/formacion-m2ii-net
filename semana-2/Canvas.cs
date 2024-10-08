namespace Paint;

public sealed class Canvas : ICanvas
{
    private readonly List<Shape> _shapes = [];

    public void Add(Shape shape) {
        _shapes.Add(shape);
    }
}
