using AutoMapper;
using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Common.Repository;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto.Book;
using Librarian.BackEnd.Mapper.Dto.UserReading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReadingController : Controller
    {
        private readonly IUserReadingRepository _userReadingRepository;
        private readonly IMapper _mapper;

        public UserReadingController(IUserReadingRepository userReadingRepository, IMapper mapper)
        {
            _userReadingRepository = userReadingRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddToReading([FromBody] UserReadingPostDto userReading)
        {
            if (userReading == null)
                return BadRequest();

            bool isInLibrary = _userReadingRepository.UserReadingExist(userReading.ReaderId, userReading.BookId);

            if (isInLibrary)
            {
                ModelState.AddModelError("", "Book is already in your library.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userReadingMap = _mapper.Map<BookUserReading>(userReading);

            if (!_userReadingRepository.AddToReading(userReadingMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok();

        }

        [HttpGet("id/{id}/reading")]
        [ProducesResponseType(200, Type = typeof(List<BookGetDto>))]
        public IActionResult GetUserReading(Guid id, string? status)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var library = _mapper.Map<List<BookGetDto>>(_userReadingRepository.GetUserReading(id, status));

            if (library != null)
            {
                return Ok(library);
            }

            return NotFound();
        }

        [Authorize]
        [HttpPut("id/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateReadingStatus([FromBody] UserReadingPostDto userReading)
        {
            if (userReading == null)
                return BadRequest();

            bool isInLibrary = _userReadingRepository.UserReadingExist(userReading.ReaderId, userReading.BookId);

            if (isInLibrary)
            {
                ModelState.AddModelError("", "Book is already in your library.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userReadingMap = _mapper.Map<BookUserReading>(userReading);

            if (!_userReadingRepository.ChangeStatus(userReadingMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [Authorize]
        [HttpDelete("id/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult RemoveFromLibrary([FromBody] UserReadingPostDto userReading)
        {
            if (userReading == null)
                return BadRequest();

            if (!_userReadingRepository.UserReadingExist(userReading.ReaderId, userReading.BookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userReadingMap = _mapper.Map<BookUserReading>(userReading);

            if (!_userReadingRepository.RemoveFromReading(userReadingMap))
            {
                ModelState.AddModelError("", "Something went wrong on removing book from library");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

    }
}
