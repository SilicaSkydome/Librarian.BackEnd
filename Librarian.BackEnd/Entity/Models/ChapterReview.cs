namespace Librarian.BackEnd.Entity.Models
{
    public class ChapterReview
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public Guid ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
    }
}
