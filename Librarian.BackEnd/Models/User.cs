namespace Librarian.BackEnd.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public ICollection<Book>? Reading { get; set; } = null!;
        //public ICollection<Book>? Writing { get; set; } = null!;
    }
}
