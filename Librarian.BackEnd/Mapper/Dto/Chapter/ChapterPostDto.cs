namespace Librarian.BackEnd.Mapper.Dto.Chapter
{
    public class ChapterPostDto
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
