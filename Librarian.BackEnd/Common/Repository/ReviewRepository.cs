using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Data;
using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddReview(Review review)
        {
            _context.Add(review);

            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);

            return Save();
        }

        public Review GetReview(Guid id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews(int page, Guid id)
        {
            if(page == 1)
            {
                return _context.Reviews.Where(r => r.BookId == id).Take(20).ToList();
            }
            else
            {
                return _context.Reviews.Where(r => r.BookId == id).Skip((20*2)-20).Take(20).ToList();
            }
        }
        public int GetReviewsCount(Guid id)
        {
            return _context.Reviews.Where(r => r.BookId == id).Count();
        }

        public bool ReviewExist(Guid id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
