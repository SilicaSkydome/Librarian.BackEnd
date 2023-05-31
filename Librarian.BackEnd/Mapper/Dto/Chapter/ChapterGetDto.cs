namespace Librarian.BackEnd.Mapper.Dto.Chapter
{
    public class ChapterGetDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
