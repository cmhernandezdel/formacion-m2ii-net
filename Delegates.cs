// crear un delegado capaz de realizar las operaciones suma, resta, division y multiplicacion
// agregar cada operacion a una lista
public class Delegates
{
    public delegate int Operation(int a, int b);

    public void RunExample() {
        List<Operation> operations = [
            (a, b) => a + b,
            (a, b) => a - b,
            (a, b) => a * b,
            (a, b) => a / b
        ];

        foreach(var op in operations) {
            Console.WriteLine(op(2,2));
        }
    }
}
