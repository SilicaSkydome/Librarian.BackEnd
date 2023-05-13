using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface IUserReadingRepository
    {
        bool AddToReading(BookUserReading UserReading);
        bool ChangeStatus(BookUserReading UserReading);
        bool RemoveFromReading(BookUserReading UserReading);
        bool UserReadingExist(Guid UserID, Guid BookId);
        bool Save();
    }
}
