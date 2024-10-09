using example.domain;
using example.domain.interfaces;

namespace example.infra;

public class GetBookRepository(List<Book> db) : IGetBookRepository
{
    public Book? Get(Guid id)
    {
        return db.FirstOrDefault(x => x.Id == id);
    }
}
