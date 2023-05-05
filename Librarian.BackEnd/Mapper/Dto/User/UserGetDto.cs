namespace Librarian.BackEnd.Mapper.Dto.User
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
    }
}
