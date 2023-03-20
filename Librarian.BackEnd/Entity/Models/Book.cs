using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.BackEnd.Entity.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public User Author { get; set; }
        //public Guid AuthorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Symbols { get; set; }
        public string? Description { get; set; }
        public ICollection<BookUser> Readers { get; set; } = null!;
        [NotMapped]
        public ICollection<string> Tags { get; set; } = null!;
        public ICollection<Chapter> Chapters { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
    }
}
