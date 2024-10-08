using Paint.Commands;

namespace Paint;

public sealed class Toolbar : IToolbar
{
    public Dictionary<string, Color> Colors { get; set; } = [];
    public Dictionary<string, Func<ShapeColorDto, Shape>> Shapes { get; set; } = [];
    public Dictionary<string, Func<string, ShapeDto, ICommand>> Commands { get; set; } = [];

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

    public void RegisterCommand(string commandName, Func<string, ShapeDto, ICommand> cmd) 
    {
        Commands.Add(commandName, cmd);
    }

    public ICommand GetCommand(string commandName, string shapeName, ShapeDto dto) 
    {
        var ctor = Commands[commandName];
        return ctor(shapeName, dto);
    }
}
