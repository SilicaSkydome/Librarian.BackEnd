namespace Librarian.BackEnd.Entity.Models
{
    public class BookUserWriting
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
    }
}
