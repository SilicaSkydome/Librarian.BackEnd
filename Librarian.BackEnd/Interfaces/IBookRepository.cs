using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(Guid id);
        bool BookExist(Guid id);
        ICollection<Book> GetBooks();
        ICollection<Book> GetBooksByName(string name);
        ICollection<Book> GetBooksByAuthor(string author);
        bool CreateBook(Book book);
        bool Save();

    }
}
