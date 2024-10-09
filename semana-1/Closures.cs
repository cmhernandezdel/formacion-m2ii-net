public class Closures {
    public void RunExample() {
        // closures
        // escribir (a) => (b) => a+b utilizando Func<T>

        // mi intento (está mal)
        // Func<int, int> g = (b) => b;
        // Func<int, int> f = (a) => (a + g(100));
        // Console.WriteLine(f(100));

        // solucion
        // como arg quiero un entero y como resultado quiero una funcion que me devuelva un entero y reciba otro entero
        Func<int, Func<int,int>> closure = (a) => (b) => a+b;
        var x = closure(5);
        var y = x(100);
        Console.WriteLine(y);

        // crear una funcion que imprima por la consola la fecha actual
        Action<DateTime, Action<object>> PrintDate = (a, b) => b(a);
        PrintDate(DateTime.Now, Console.WriteLine);
    }
}

