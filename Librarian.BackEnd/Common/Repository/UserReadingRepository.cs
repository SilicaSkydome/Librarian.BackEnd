using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Data;
using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Repository
{
    public class UserReadingRepository : IUserReadingRepository
    {
        private readonly DataContext _context;

        public UserReadingRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddToReading(BookUserReading UserReading)
        {
            _context.Add(UserReading);
            return Save();
        }

        public bool ChangeStatus(BookUserReading UserReading)
        {
            _context.Update(UserReading);
            return Save();
        }

        public List<Book> GetUserReading(Guid userId, string? status)
        {
            if (status != null || status != "")
            {

                List<Guid> bookIdList = _context.BookUserReadings.Where(b => b.ReaderId == userId && b.Status == status).Select(b => b.BookId).ToList();
                List<Book> books = _context.Books.Where(b => bookIdList.Contains(b.Id)).ToList();
                return books;
            }
            else
            {
                List<Guid> bookIdList = _context.BookUserReadings.Where(b => b.ReaderId == userId).Select(b => b.BookId).ToList();
                List<Book> books = _context.Books.Where(b => bookIdList.Contains(b.Id)) .ToList();
                return books;
            }
        }

        public bool RemoveFromReading(BookUserReading UserReading)
        {
            _context.Remove(UserReading);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserReadingExist(Guid UserID, Guid BookId)
        {
            return _context.BookUserReadings.Any(bu => bu.ReaderId == UserID && bu.BookId == BookId);
        }
    }
}
