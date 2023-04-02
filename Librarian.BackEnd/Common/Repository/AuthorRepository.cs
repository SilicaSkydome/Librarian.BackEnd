using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Data;
using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddAuthor(Author author)
        {
            _context.Add(author);

            return Save();
        }

        public bool AuthorExists(Guid id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }

        public bool DeleteAuthor(Author author)
        {
            _context.Remove(author);

            return Save();
        }

        public Author GetAuthorByAuthorId(Guid id)
        {
            return _context.Authors.Where(a => a.Id == id).FirstOrDefault();
        }

        public Author GetAuthorByUserId(Guid id)
        {
            return _context.Authors.Where(a => a.User.Id == id).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.OrderBy(a => a.User.Name).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
