using AutoMapper;
using Librarian.BackEnd.Dto;
using Librarian.BackEnd.Interfaces;
using Librarian.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookGetDto>))]
        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookGetDto>>(_bookRepository.GetBooks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpGet("id={id:guid}")]
        [ProducesResponseType(200, Type = typeof(BookGetDto))]
        [ProducesResponseType(400)]
        public IActionResult GetBookById(Guid id)
        {
            if (!_bookRepository.BookExist(id))
                return NotFound();

            var book = _mapper.Map<BookGetDto>(_bookRepository.GetBookById(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(book);
        }

        [HttpGet("name={name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookGetDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByName(string name)
        {
            var books = _mapper.Map<List<BookGetDto>>(_bookRepository.GetBooksByName(name));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(books);
        }

        [HttpGet("author={author}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookGetDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBookByAuthor(string author)
        {
            var books = _mapper.Map<List<BookGetDto>>(_bookRepository.GetBooksByAuthor(author));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] BookPostDto bookCreate)
        {
            if (bookCreate == null)
                return BadRequest(ModelState);

            var book = _bookRepository.GetBooks()
                .Where(b => b.Name.Trim().ToUpper() == bookCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (book != null)
            {
                ModelState.AddModelError("", "Book with such title already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookMap = _mapper.Map<Book>(bookCreate);

            if (!_bookRepository.CreateBook(bookMap))
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
        public IActionResult UpdateBook(Guid id, [FromBody] BookPostDto updatedBook)
        {
            if (updatedBook == null)
                return BadRequest(ModelState);

            if (!_bookRepository.BookExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var bookMap = _mapper.Map<Book>(updatedBook);

            if (!_bookRepository.UpdateBook(bookMap))
            {
                ModelState.AddModelError("", "Something went wrong on updating book");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated successfully");
        }

        [HttpDelete("id={id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(Guid id)
        {
            if (!_bookRepository.BookExist(id))
                return NotFound();

            var bookToDelete = _bookRepository.GetBookById(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_bookRepository.DeleteBook(bookToDelete))
            {
                ModelState.AddModelError("","Something went wrong on deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted Successfully");
        }
                
    }
}
