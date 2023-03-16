namespace Librarian.BackEnd.Dto
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
    }
}
