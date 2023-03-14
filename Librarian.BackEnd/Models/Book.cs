using System.ComponentModel.DataAnnotations;

namespace Librarian.BackEnd.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Symbols { get; set; }
        public string? Description { get; set; }
        public ICollection<User> Readers { get; set; }
        public ICollection<string> Tags { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
