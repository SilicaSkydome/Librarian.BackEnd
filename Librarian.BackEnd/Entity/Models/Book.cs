using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.BackEnd.Entity.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? CoverUrl { get; set; }
        public BookUserWriting Author { get; set; }
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Symbols { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public ICollection<string> Tags
        {
            get { return TagsAsString?.Split(',', StringSplitOptions.RemoveEmptyEntries); }
            set { TagsAsString = string.Join(",", value); }
        }
        public string TagsAsString { get; set; }
        public ICollection<Chapter> Chapters { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
    }
}
