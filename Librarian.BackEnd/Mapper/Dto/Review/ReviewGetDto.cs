namespace Librarian.BackEnd.Mapper.Dto.Review
{
    public class ReviewGetDto
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public string Text { get; set; }
    }
}
