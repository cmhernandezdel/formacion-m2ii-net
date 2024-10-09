namespace example.domain.interfaces;

public interface IGetBookRepository
{
    Book? Get(Guid id);
}
