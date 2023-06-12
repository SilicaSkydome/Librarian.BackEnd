namespace Librarian.BackEnd.Mapper.Dto.Book
{
    public class BookPostDto
    {
        public string Name { get; set; }
        public string? CoverUrl { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime Date { get; set; }
        public int Symbols { get; set; }
        public ICollection<string> Tags { get; set; }
        public string? Description { get; set; }
    }
}
