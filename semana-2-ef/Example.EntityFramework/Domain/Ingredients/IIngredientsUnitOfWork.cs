using Example.EntityFramework.Domain.Core;

namespace Example.EntityFramework.Domain.Ingredients;

public interface ICreateIngredientsUnitOfWork : IUnitOfWork
{
    public ICreateIngredientsRepository Repository { get; }

    public ICreateOutboxEventRepository EventRepository { get; }
}
