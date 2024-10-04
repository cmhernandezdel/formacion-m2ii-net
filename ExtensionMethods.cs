public class ExtensionMethods {
    public void RunExample() {
        var a = new List<int>() {1, 2, 3, 4, 5};
        var c = a.Between(2, 4);
        c.Print();
    }
}

// extension method que saque los enteros entre dos numeros
public static class IntExtensions {
    public static IEnumerable<int> Between(this IEnumerable<int> source, int p1, int p2) {
        return source.Where(x => x >= p1 && x <= p2);
    }

    public static bool IsBetween(this int source, int p1, int p2) {
        return source >= p1 && source <= p2;
    }
}

// extension method que imprima los elementos de un ienumerable
public static class IEnumerableExtensions {
    public static void Print<T>(this IEnumerable<T> source) {
        foreach(var x in source) {
            Console.WriteLine(x);
        }
    }
}