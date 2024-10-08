namespace Paint;

public static class App
{
    public static IToolbar CreateToolbar()
    {
        var toolbar = new Toolbar();
        toolbar.RegisterColor("black", new Color(0, 0, 0));
        toolbar.RegisterColor("white", new Color(255, 255, 255));
        toolbar.RegisterShape("circle", dto => new Circle(dto.Start, dto.End, dto.Color));
        toolbar.RegisterShape("rectangle", dto => new Rectangle(dto.Start, dto.End, dto.Color));
        return toolbar;
    }

    public static ICanvas CreateCanvas()
    {
        return new Canvas();
    }
}
