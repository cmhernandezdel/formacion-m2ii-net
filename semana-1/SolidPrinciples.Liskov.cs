// En el mundo de las aves hay pinguinos que pesan 5kg y aguilas que pesan 10kg y vuelan a 100 kmh
// Crear las clases necesarias
// Crear una funcion capaz de escribir las aves y las aves que vuelan y las que no vuelan
public static class BirdPrinter {
    public static void PrintBird(Bird bird) {
        Console.WriteLine($"PrintBird: {bird.Weight} kg");
    }

    public static void PrintFlyingBird(FlyingBird bird) {
        Console.WriteLine($"PrintFlyingBird: {bird.Weight} kg");
        Console.WriteLine($"PrintFlyingBird: {bird.Speed} kmh");
    }

    public static void PrintNonFlyingBird(NonFlyingBird bird) {
        Console.WriteLine($"PrintNonFlyingBird: {bird.Weight} kg");
    }
}

/* Solución propuesta */
// public abstract class Bird {
//     public double Weight { get; set; }
//     public abstract bool CanFly();
// }

// public abstract class FlyingBird : Bird {
//     public override bool CanFly() => true;
//     public double FlyingSpeed { get; set; }
// }

// public sealed class Penguin : Bird {
//     public Penguin() {
//         Weight = 5.0;
//     }

//     public override bool CanFly() => false;
// }

// public sealed class Eagle : FlyingBird {
//     public Eagle() {
//         Weight = 10.0;
//         FlyingSpeed = 100.0;
//     }
// }

/* Solucion dada */
public abstract class Bird {
    public double Weight { get; init; }

    public Bird(double weight) {
        Weight = weight;
    }
}

public abstract class FlyingBird : Bird {
    public double Speed { get; init; }

    public FlyingBird(double speed, double weight) : base(weight) {
        Speed = speed;
    }
}

public abstract class NonFlyingBird : Bird {
    public NonFlyingBird(double weight) : base(weight) { }
}

public sealed class Penguin : NonFlyingBird {
    public Penguin() : base(5) { }

}

public sealed class Eagle : FlyingBird {
    public Eagle() : base(100, 10) { }
}