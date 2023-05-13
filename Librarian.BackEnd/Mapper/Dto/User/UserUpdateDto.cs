namespace Librarian.BackEnd.Mapper.Dto.User
{
    public class UserUpdateDto
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
    }
}
