using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUserId(Guid id);
        User GetUserByAuthorId(Guid id);
        bool UserExists(Guid id);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
        ICollection<User> GetUsers();
        ICollection<User> GetUsersByName(string name);
    }
}
