namespace example.domain.interfaces;

public interface IAddBookRepository : IGetBookRepository
{
    void Add(Book book);
}
