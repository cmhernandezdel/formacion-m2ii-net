// En nuestro sistema tenemos clientes que se pueden: leer, añadir, modificar y eliminar
// los usuarios solo se pueden: leer
// implementar los repositorios

/* Solución propuesta */
// public interface IReadRepository {
//     public void Get();
// }

// public interface IWriteRepository {
//     public void Add();
//     public void Update();
//     public void Delete();
// }

// public sealed class ClientRepository : IReadRepository, IWriteRepository {
//     public void Get() {}
//     public void Add() {}
//     public void Update() {}
//     public void Delete() {}
// }

// public sealed class UserRepository : IReadRepository {
//     public void Get() {}
// } 

/* Solución dada */
public interface IGet<T> {
    public void Get();
}

public interface IAdd<T> {
    public void Add();
}

public interface IUpdate<T> : IGet<T> {
    public void Update();
}

public interface IRemove<T> : IGet<T> {
    public void Delete();
}

public interface IRepository<T> : IAdd<T>, IUpdate<T>, IRemove<T> {

}

public sealed class ClientRepository : IRepository<Client> {
    public void Get() {}
    public void Add() {}
    public void Update() {}
    public void Delete() {}
}

public sealed class UserRepository : IGet<User> {
    public void Get() {}
} 

public class Client {}
public class User {}