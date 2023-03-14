namespace Librarian.BackEnd.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public User Author { get; set; }
        public Book Book { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
    }
}
