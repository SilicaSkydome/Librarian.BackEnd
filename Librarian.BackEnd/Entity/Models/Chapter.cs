using System.ComponentModel.DataAnnotations;

namespace Librarian.BackEnd.Entity.Models
{
    public class Chapter
    {
        public Guid Id { get; set; }
        [Required]
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int Symbols { get; set; }
        public ICollection<ChapterReview> Reviews { get; set; } = null!;
    }
}
