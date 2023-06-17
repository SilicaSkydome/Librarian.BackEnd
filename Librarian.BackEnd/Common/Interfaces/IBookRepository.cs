using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(Guid id);
        bool BookExist(Guid id);
        ICollection<Book> Get10Books(string? order);
        ICollection<Book> GetBooksByAuthor(string author);
        ICollection<Book> SearchBooks(int page, string name, string[]? tags);
        int SearchCount(string name, string[]? tags);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();

    }
}
