using AutoMapper;
using Librarian.BackEnd.Dto;
using Librarian.BackEnd.Interfaces;
using Librarian.BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : Controller
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public ChapterController(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Chapter>))]
        public IActionResult GetChapters(Guid bookId)
        {
            var chapters = _mapper.Map<List<ChapterDto>>(_chapterRepository.GetChapters(bookId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(chapters);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Chapter))]
        public IActionResult GetChapter(Guid id)
        {
            if (!_chapterRepository.ChapterExist(id))
                return NotFound();

            var chapter = _mapper.Map<ChapterDto>(_chapterRepository.GetChapter(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(chapter);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateChapter([FromBody] ChapterDto chapterCreate)
        {
            if(chapterCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var chapterMap = _mapper.Map<Chapter>(chapterCreate);

            if (!_chapterRepository.CreateChapter(chapterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
