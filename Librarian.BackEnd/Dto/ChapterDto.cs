namespace Librarian.BackEnd.Dto
{
    public class ChapterDto
    {
        public Guid BookID { get; set; }
        public string ChapterName { get; set; }
        public string Text { get; set; }
        public int Symbols { get; set; }
    }
}
