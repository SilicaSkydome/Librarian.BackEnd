using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Dto
{
    public class BookDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid AuthorID { get; set; }
        public DateTime Date { get; set; }
        public int Symbols { get; set; }
        public string? Description { get; set; }
    }
}
