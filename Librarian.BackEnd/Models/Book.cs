using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.BackEnd.Models
{
    public class Book
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Symbols { get; set; }
        public string? Description { get; set; }
        public ICollection<User> Readers { get; set; } = null!;
        [NotMapped]
        public ICollection<string> Tags { get; set; } = null!;
        public ICollection<Chapter> Chapters { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
    }
}
