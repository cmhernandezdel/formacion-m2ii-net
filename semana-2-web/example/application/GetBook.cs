using example.domain;
using example.domain.interfaces;

namespace example.application;

public sealed class GetBook
{
    public readonly record struct GetBookRequest(Guid Id);
    public readonly record struct GetBookResponse(Guid Id, string Name);

    public interface IGetBookHandler
    {
        GetBookResponse Handle(GetBookRequest request);
    }

    public class Handler(IGetBookRepository repository) : IGetBookHandler
    {
        public GetBookResponse Handle(GetBookRequest request)
        {
            var book = repository.Get(request.Id);
            return book == null ? throw new ArgumentException("") : new GetBookResponse(book.Id, book.Name);
        }
    }
}
