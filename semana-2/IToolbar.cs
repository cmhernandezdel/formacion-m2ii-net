using Paint.Commands;

namespace Paint;

public interface IToolbar 
{
    public void RegisterColor(string colorName, Color color);
    public Color GetColor(string colorName);
    public void RegisterShape(string shapeName, Func<ShapeColorDto, Shape> shape);
    public Shape GetShape(string shapeName, ShapeDto dto);
    public void RegisterCommand(string commandName, Func<string, ShapeDto, ICommand> cmd);
    public ICommand GetCommand(string commandName, string shapeName, ShapeDto dto);
}