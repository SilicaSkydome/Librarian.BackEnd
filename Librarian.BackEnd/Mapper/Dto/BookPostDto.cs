namespace Librarian.BackEnd.Mapper.Dto
{
    public class BookPostDto
    {
        public string Name { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime Date { get; set; }
        public int Symbols { get; set; }
        public ICollection<string> Tags { get; set; } = null!;
        public string? Description { get; set; }
    }
}
