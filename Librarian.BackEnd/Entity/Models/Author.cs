namespace Librarian.BackEnd.Entity.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public ICollection<Book> Writing { get; set; }
    }
}
