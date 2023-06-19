namespace Librarian.BackEnd.Mapper.Dto.Review
{
    public class ReviewPostDto
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public string Text { get; set; }
    }
}
