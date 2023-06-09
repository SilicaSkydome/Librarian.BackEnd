﻿namespace Librarian.BackEnd.Entity.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public ICollection<BookUserWriting>? Writing { get; set; } = null!;
        public ICollection<Review>? Reviews { get; set; } = null;

    }
}
