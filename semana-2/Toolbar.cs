namespace Paint;

public sealed class Toolbar : IToolbar
{
    public Dictionary<string, Color> Colors { get; set; } = [];
    public Dictionary<string, Func<ShapeColorDto, Shape>> Shapes { get; set; } = [];

    public void RegisterColor(string colorName, Color color) 
    {
        Colors.Add(colorName, color);
    }

    public Color GetColor(string colorName) => Colors[colorName];

    public void RegisterShape(string shapeName, Func<ShapeColorDto, Shape> shape) 
    {
        Shapes.Add(shapeName, shape);
    }

    public Shape GetShape(string shapeName, ShapeDto dto) 
    {
        var color = GetColor(dto.ColorName);
        var dtoSC = new ShapeColorDto(dto.Start, dto.End, color);
        var ctor = Shapes[shapeName];
        return ctor(dtoSC);
    }
}
