using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Data;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Librarian.BackEnd.Common.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public LoginRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public User Authenticate(UserLoginDto user)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Login.ToLower() == user.Login.ToLower() && u.Password == user.Password);

            return currentUser;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Login),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool UserExists(UserLoginDto user)
        {
            return _context.Users.Any(u => u.Login.ToLower() == user.Login.ToLower());
        }
    }
}
