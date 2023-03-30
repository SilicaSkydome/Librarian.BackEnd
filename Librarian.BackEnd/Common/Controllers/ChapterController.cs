using AutoMapper;
using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public ChapterController(IChapterRepository chapterRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _chapterRepository = chapterRepository;
            _mapper = mapper;

        }

        [HttpGet("bookId/{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChapterGetDto>))]
        public IActionResult GetChapters(Guid bookId)
        {
            var chapters = _mapper.Map<List<ChapterGetDto>>(_chapterRepository.GetChapters(bookId));
            chapters.ForEach(c => c.BookID = bookId);
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(chapters);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(200, Type = typeof(ChapterGetDto))]
        public IActionResult GetChapter(Guid id)
        {
            if (!_chapterRepository.ChapterExist(id))
                return NotFound();

            var chapter = _mapper.Map<ChapterGetDto>(_chapterRepository.GetChapter(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(chapter);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateChapter([FromBody] ChapterPostDto chapterCreate)
        {
            if (chapterCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var chapterMap = _mapper.Map<Chapter>(chapterCreate);
            chapterMap.Book = _bookRepository.GetBookById(chapterCreate.BookID);
            if (!_chapterRepository.CreateChapter(chapterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("id/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateChapter(Guid id, [FromBody] ChapterGetDto updatedChapter)
        {
            if (updatedChapter == null)
                return BadRequest(ModelState);

            if (!_chapterRepository.ChapterExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var chapterMap = _mapper.Map<Chapter>(updatedChapter);

            if (!_chapterRepository.UpdateChapter(chapterMap))
            {
                ModelState.AddModelError("", "Something went wrong on updating chapter");
                return StatusCode(500, ModelState);
            }

            return Ok("Updated successfully");
        }

        [HttpDelete("id/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteChapter(Guid id)
        {
            if (!_chapterRepository.ChapterExist(id))
                return NotFound();

            var chapterToDelete = _chapterRepository.GetChapter(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_chapterRepository.DeleteChapter(chapterToDelete))
            {
                ModelState.AddModelError("", "Something went wrong on deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted Successfully");
        }
    }
}
