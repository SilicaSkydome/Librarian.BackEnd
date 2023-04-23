using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(Guid id);
        bool BookExist(Guid id);
        ICollection<Book> GetBooks(string? order);
        ICollection<Book> GetBooksByName(string name);
        ICollection<Book> GetBooksByAuthor(string author);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();

    }
}
