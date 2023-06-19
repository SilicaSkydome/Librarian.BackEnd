using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews(int page, Guid id);
        int GetReviewsCount(Guid id);
        Review GetReview(Guid id);
        bool AddReview(Review review);
        bool DeleteReview(Review review);
        bool ReviewExist(Guid id);
        bool Save();
    }
}
