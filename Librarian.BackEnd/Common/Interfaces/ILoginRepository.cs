using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto.User;

namespace Librarian.BackEnd.Common.Interfaces
{
    public interface ILoginRepository
    {
        User Authenticate(UserLoginDto user);
        string Generate(User user);
        bool UserExists(UserLoginDto user);
    }
}
