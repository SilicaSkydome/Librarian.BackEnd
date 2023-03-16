using AutoMapper;
using Librarian.BackEnd.Dto;
using Librarian.BackEnd.Interfaces;
using Librarian.BackEnd.Models;
using Librarian.BackEnd.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserGetDto))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserGetDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(users);
        }

        [HttpGet("id={id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserById(Guid id)
        {
            if (!_userRepository.UserExists(id))
                return NotFound();

            var user = _mapper.Map<UserGetDto>(_userRepository.GetUserById(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(user);
        }

        [HttpGet("name={name}")]
        [ProducesResponseType(200, Type = typeof(UserGetDto))]
        public IActionResult GetUsersByName(string name)
        {
            var users = _mapper.Map<List<UserGetDto>>(_userRepository.GetUsersByName(name));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddUser([FromBody] UserPostDto addUser)
        {
            if (addUser == null)
                return BadRequest();

            var users = _userRepository.GetUsers()
                .Where(u => u.Login.Trim().ToUpper() == addUser.Login.Trim().ToUpper())
                .FirstOrDefault();

            if (users != null)
            {
                ModelState.AddModelError("", "User with such login already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(addUser);

            if (!_userRepository.AddUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("id={id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(Guid id, [FromBody] UserPostDto updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);

            if (!_userRepository.UserExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<User>(updatedUser);

            if (!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong on updating user");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated successfully");
        }

        [HttpDelete("id={id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(Guid id)
        {
            if (!_userRepository.UserExists(id))
                return NotFound();

            var userToDelete = _userRepository.GetUserById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong on deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted Successfully");
        }
    }
}
