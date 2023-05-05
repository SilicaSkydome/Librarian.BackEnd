using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Data;
using Librarian.BackEnd.Entity.Models;

namespace Librarian.BackEnd.Common.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);

            return Save();
        }

        public User GetUserByUserId(Guid id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Name).ToList();
        }

        public ICollection<User> GetUsersByName(string name)
        {
            return _context.Users.Where(u => u.Name.Contains(name)).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);

            return Save();
        }

        public bool UserExists(Guid id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
