// escribir una copia del metodo de LINQ where
public class Yield {
    public void RunExample() {
        List<int> list = [1, 2, 3, 4, 5];
        var zz = list.Filter(i => i > 3);
        foreach (var t in zz) {
            Console.WriteLine(t);
        }
    }
}

public static class LinqExtensions  {
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> src, Func<T ,bool> predicate) {
        foreach (var element in src) {
            if (predicate(element)) {
                yield return element;
            }
        }
    }
}