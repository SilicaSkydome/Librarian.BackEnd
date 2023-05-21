﻿using Librarian.BackEnd.Common.Interfaces;
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

        public List<Book> GetUserReading(Guid userID, string? status)
        {
            if (status != null || status != "")
            {
                return _context.BookUserReadings.Where(b => b.Reader.Id == userID && b.Status == status).Select(b => b.Book).ToList();
            }
            else
            {
                return _context.BookUserReadings.Where(b => b.Reader.Id == userID).Select(b => b.Book).ToList();
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
