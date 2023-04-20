using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Mapper.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            if (!_loginRepository.UserExists(userLogin))
            {
                return NotFound();
            }
            var user = _loginRepository.Authenticate(userLogin);

            if(user != null)
            {
                var token = _loginRepository.Generate(user);
                return Ok(token);
            }

            return NotFound();
        }
    }
}
