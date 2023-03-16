using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(Guid id);
        bool UserExists(Guid id);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
        ICollection<User> GetUsers();
        ICollection<User> GetUsersByName(string name);
    }
}
