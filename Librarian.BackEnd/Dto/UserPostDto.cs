﻿namespace Librarian.BackEnd.Dto
{
    public class UserPostDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
    }
}
