namespace Paint.Commands;

public sealed class AddShapeCommand(ICanvas receiver, Shape shape) : ICommand
{
    public void Execute()
    {
        receiver.Add(shape);
    }
}
