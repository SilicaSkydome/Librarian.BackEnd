namespace Librarian.BackEnd.Mapper.Dto.UserReading
{
    public class UserReadingPostDto
    {
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
        public string Status { get; set; }
    }
}
