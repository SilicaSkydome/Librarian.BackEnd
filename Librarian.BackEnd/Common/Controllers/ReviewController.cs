using AutoMapper;
using Librarian.BackEnd.Common.Interfaces;
using Librarian.BackEnd.Entity.Models;
using Librarian.BackEnd.Mapper.Dto.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.BackEnd.Common.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet("bookId/{id:guid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewGetDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviews(int page, Guid id) 
        {
            var reviews = _mapper.Map<List<ReviewGetDto>>(_reviewRepository.GetReviews(page, id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }

        [HttpGet("bookId/{id:guid}/count")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsCount(Guid id)
        {
            int reviews = _reviewRepository.GetReviewsCount(id);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(reviews);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddReview([FromBody] ReviewPostDto addReview)
        {
            if (addReview == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(addReview);

            if (!_reviewRepository.AddReview(reviewMap))
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
        public IActionResult DeleteReview(Guid id)
        {
            if (!_reviewRepository.ReviewExist(id))
                return NotFound();

            var reviewToDelete = _reviewRepository.GetReview(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReview(reviewToDelete))
            {
                ModelState.AddModelError("", "Something went wrong on deleting");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}
