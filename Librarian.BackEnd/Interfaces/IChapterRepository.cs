using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Interfaces
{
    public interface IChapterRepository
    {
        Chapter GetChapter(Guid id);
        bool ChapterExist(Guid id);
        ICollection<Chapter> GetChapters(Guid bookId);
        bool CreateChapter(Chapter chapter);
        bool UpdateChapter(Chapter chapter);
        bool DeleteChapter(Chapter chapter);
        bool Save();
    }
}
