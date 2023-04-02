using AutoMapper;
using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Author))]
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(authors);
        }

        [HttpGet("authorId/{id}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        public IActionResult GetAuthorByAuthorId(Guid id)
        {
            if (!_authorRepository.AuthorExists(id))
                return NotFound();
            
            var author = _authorRepository.GetAuthorByAuthorId(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(author);
        }

        [HttpGet("userId/{id}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        public IActionResult GetAuthorByUserId(Guid id)
        {
            if (!_authorRepository.AuthorExists(id))
                return NotFound();

            var author = _authorRepository.GetAuthorByUserId(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddAuthor([FromBody] AuthorPostDto addAuthor)
        {
            if (addAuthor == null)
                return BadRequest();

            var authors = _authorRepository.GetAuthors()
                .Where(a => a.User.Id == addAuthor.userId).FirstOrDefault();

            if(authors != null)
            {
                ModelState.AddModelError("", "You already an author.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorMap = _mapper.Map<Author>(addAuthor);

            if (!_authorRepository.AddAuthor(authorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

        [HttpDelete("id/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAuthor(Guid id)
        {
            if (!_authorRepository.AuthorExists(id))
                return NotFound();

            var authorToDelete = _authorRepository.GetAuthorByAuthorId(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_authorRepository.DeleteAuthor(authorToDelete))
            {
                ModelState.AddModelError("", "Something went wrong on deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted Successfully");
        }
    }
}
