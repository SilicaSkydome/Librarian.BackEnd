using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Data;
using Librarian.BackEnd.Entity.Models;
using Microsoft.IdentityModel.Tokens;

namespace Librarian.BackEnd.Common.Repository
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
            return _context.Books.Any(b => b.Id == id);
        }

        public ICollection<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author.Id == _context.Users.Where(u => u.Name.Contains(author)).FirstOrDefault().Id).ToList();
        }

        public Book GetBookById(Guid id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }
        public ICollection<Book> GetMisc()
        {
            return _context.Books.OrderBy(b => Guid.NewGuid()).Take(5).ToList();
        }
        public ICollection<Book> Get10Books(string? order)
        {
            if (order == "popular")
            {
                return _context.Books.OrderBy(b => b.Name).Take(10).ToList();
            }
            if (order == "new")
            {
                return _context.Books.OrderByDescending(b => b.Date).Take(10).ToList();
            }
            if (order == "updates")
            {
                return _context.Books.OrderBy(b => b.Name).Take(10).ToList();
            }
            if (order == "bestsellers")
            {
                return _context.Books.OrderBy(b => b.Name).Take(10).ToList();
            }

            return _context.Books.OrderBy(b => b.Name).Take(10).ToList();
        }
        public ICollection<Book> SearchBooks(int page, string name, string[]? tags)
        {
            if(page == 1)
            {
                if (tags.IsNullOrEmpty())
                {
                    if (name == "null")
                    {
                        return _context.Books.OrderBy(b => b.Name).Take(10).ToList();
                    }
                    else
                    {
                        return _context.Books.Where(b => b.Name.Contains(name)).Take(10).ToList();
                    }
                }
                else
                {
                    if (name == "null")
                    {
                        return _context.Books.AsEnumerable().Where(b => tags.All(t => b.Tags.Contains(t))).Take(10).ToList();
                    }
                    else
                    {
                        return _context.Books.AsEnumerable().Where(b => b.Name.Contains(name) && tags.All(t => b.Tags.Contains(t))).Take(10).ToList();
                    }
                }
            }
            else
            {
                if (tags.IsNullOrEmpty())
                {
                    if (name == "null")
                    {
                        return _context.Books.OrderBy(b => b.Name).Skip((10 * page) - 10).Take(10).ToList();
                    }
                    else
                    {
                        return _context.Books.Where(b => b.Name.Contains(name)).Skip((10 * page) - 10).Take(10).ToList();
                    }
                    
                }
                else
                {
                    if (name == "null")
                    {
                        return _context.Books.AsEnumerable().Where(b => tags.All(t => b.Tags.Contains(t))).Skip((10 * page) - 10).Take(10).ToList();
                    }
                    else
                    {
                        return _context.Books.AsEnumerable().Where(b => b.Name.Contains(name) && tags.All(t => b.Tags.Contains(t))).Skip((10 * page) - 10).Take(10).ToList();
                    }
                }
            }
        }
        public int SearchCount(string name, string[]? tags)
        {
            if (tags.IsNullOrEmpty())
            {
                if(name == "null")
                {
                    return _context.Books.OrderBy(b => b.Name).Count();
                }
                else
                {
                    return _context.Books.Where(b => b.Name.Contains(name)).Count();
                }
            }
            else
            {
                if (name == "null")
                {
                    return _context.Books.AsEnumerable().Where(b => tags.All(t => b.Tags.Contains(t))).Count();
                }
                else
                {
                    return _context.Books.AsEnumerable().Where(b => b.Name.Contains(name) && tags.All(t => b.Tags.Contains(t))).Count();
                }
                
            }
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

        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);

            return Save();
        }

    }
}
