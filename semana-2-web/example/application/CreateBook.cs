using example.domain;
using example.domain.interfaces;

namespace example.application;

public sealed class CreateBook
{
    public readonly record struct CreateBookRequest(string Name);
    public readonly record struct CreateBookResponse(Guid Id, string Name);

    public interface ICreateBookHandler
    {
        CreateBookResponse Handle(CreateBookRequest request);
    }

    public class Handler(IAddBookRepository repository) : ICreateBookHandler
    {
        public CreateBookResponse Handle(CreateBookRequest request)
        {
            var book = Book.Create(request.Name);
            repository.Add(book);
            return new CreateBookResponse(book.Id, book.Name);
        }
    }
}
