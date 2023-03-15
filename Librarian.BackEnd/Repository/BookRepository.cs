using Librarian.BackEnd.Data;
using Librarian.BackEnd.Interfaces;
using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public bool BookExist(Guid id)
        {
            return _context.Books.Any(b => b.ID == id);
        }

        public ICollection<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.AuthorID == _context.Users.Where(u => u.Name.Contains(author)).FirstOrDefault().Id).ToList();
        }

        public Book GetBookById(Guid id)
        {
            return _context.Books.Where(b => b.ID == id).FirstOrDefault();
        }

        public ICollection<Book> GetBooksByName(string name)
        {
            return _context.Books.Where(b => b.Name.Contains(name)).ToList();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Name).ToList();
        }

        public bool CreateBook(Book book)
        {
            _context.Add(book);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
