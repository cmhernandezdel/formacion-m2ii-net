using Paint.Commands;

namespace Paint;

public static class App
{
    private static readonly IToolbar _toolbar = CreateToolbar();
    private static readonly ICanvas _canvas = CreateCanvas();

    private static IToolbar CreateToolbar()
    {
        var toolbar = new Toolbar();
        toolbar.RegisterColor("black", new Color(0, 0, 0));
        toolbar.RegisterColor("white", new Color(255, 255, 255));
        toolbar.RegisterShape("circle", dto => new Circle(dto.Start, dto.End, dto.Color));
        toolbar.RegisterShape("rectangle", dto => new Rectangle(dto.Start, dto.End, dto.Color));
        toolbar.RegisterCommand("add", (shapeName, dto) => new AddShapeCommand(_canvas, _toolbar.GetShape(shapeName, dto)));
        return toolbar;
    }

    private static ICanvas CreateCanvas()
    {
        return new Canvas();
    }

    public static void Run(string shapeName, ShapeDto dto)
    {
        var shape = _toolbar.GetShape(shapeName, dto);
        var command = new AddShapeCommand(_canvas, shape);
        command.Execute();
    }
}
