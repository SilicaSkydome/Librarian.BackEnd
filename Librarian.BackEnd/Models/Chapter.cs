using System.ComponentModel.DataAnnotations;

namespace Librarian.BackEnd.Models
{
    public class Chapter
    {
        public int ID { get; set; }
        [Required]
        public Book Book { get; set; }
        public string ChapterName { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int Symbols { get; set; }
        public ICollection<ChapterReview> ChapterReviews { get; set; }
    }
}
