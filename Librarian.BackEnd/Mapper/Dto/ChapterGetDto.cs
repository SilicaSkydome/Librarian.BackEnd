namespace Librarian.BackEnd.Mapper.Dto
{
    public class ChapterGetDto
    {
        public Guid ID { get; set; }
        public Guid BookID { get; set; }
        public string ChapterName { get; set; }
        public string Text { get; set; }
        public int Symbols { get; set; }
    }
}
