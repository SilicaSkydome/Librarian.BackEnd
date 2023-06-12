using Microsoft.EntityFrameworkCore;

namespace Librarian.BackEnd.Entity.Models
{
    public class BookUserReading
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ReaderId { get; set; }
        public string Status { get; set; }

    }
}
