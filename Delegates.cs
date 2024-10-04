// crear un delegado capaz de realizar las operaciones suma, resta, division y multiplicacion
// agregar cada operacion a una lista
public class Delegates
{
    public delegate int Operation(int a, int b);

    public void RunExample() {
        Operation sum = (a, b) => a + b;
        Operation diff = (a, b) => a - b;
        Operation times = (a, b) => a * b;
        Operation division = (a, b) => a / b;

        Console.WriteLine(sum(2,2));
        Console.WriteLine(diff(2,2));
        Console.WriteLine(times(2,2));
        Console.WriteLine(division(2,2));
    }
}
