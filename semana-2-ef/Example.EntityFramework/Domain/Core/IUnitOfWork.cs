namespace Example.EntityFramework.Domain.Core;

public interface IUnitOfWork
{
    void Commit();
}
