using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface IAuthorRepository
    {
        Author GetAuthorByAuthorId(Guid id);
        Author GetAuthorByUserId(Guid id);
        bool AuthorExists(Guid id);
        bool AddAuthor(Author author);
        bool DeleteAuthor(Author author);
        bool Save();
        ICollection<Author> GetAuthors();

    }
}
