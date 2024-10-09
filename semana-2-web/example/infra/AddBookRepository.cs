using example.domain;
using example.domain.interfaces;

namespace example.infra;

public class AddBookRepository(List<Book> db) : IAddBookRepository
{
    public void Add(Book book)
    {
        db.Add(book);
    }

    public Book? Get(Guid id)
    {
        return db.FirstOrDefault(x => x.Id == id);
    }
}
