namespace Librarian.BackEnd.Entity.Models
{
    public class BookUser
    {
        public Guid Id { get; set; }
        public Guid ReaderId { get; set; }
        public Guid BookId { get; set; }
        public User Reader { get; set; }
        public Book Book { get; set; }
    }
}
