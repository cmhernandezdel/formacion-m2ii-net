// sirven para hacer value objects
// crear una clase que implemente los metodos equals, gethashcode y sobrecargar el operador ==
// para comprobar que dos instancias de esa clase son iguales

public class Records {
    public void RunExample() {
        var foo = new Foo("Pedro");
        var foo1 = new Foo("Pedro");
        Console.WriteLine(foo == foo1);

        var bar = new Bar() { Name = "Pedro" };
        var bar1 = new Bar() { Name = "Pedro" };
        Console.WriteLine(bar == bar1);
    }
}

public readonly record struct Foo(string name);

public class Bar {
    public string Name { get; set; }

    public override bool Equals(object? other) {
        return (other is Bar bar && bar.Name == Name);
    }

    public static bool operator ==(Bar b1, Bar b2) => b1.Equals(b2);
    public static bool operator !=(Bar b1, Bar b2) => !b1.Equals(b2);

    public override int GetHashCode() => Name.GetHashCode(); 
}