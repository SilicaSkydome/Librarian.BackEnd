using Librarian.BackEnd.Data;
using Librarian.BackEnd.Interfaces;
using Librarian.BackEnd.Models;

namespace Librarian.BackEnd.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly DataContext _context;

        public ChapterRepository(DataContext context)
        {
            _context = context;
        }

        public bool ChapterExist(Guid id)
        {
            return _context.Chapters.Any(c => c.ID == id);
        }

        public Chapter GetChapter(Guid id)
        {
            return _context.Chapters.Where(c => c.ID == id).FirstOrDefault();
        }

        public ICollection<Chapter> GetChapters(Guid bookId)
        {
            return _context.Chapters.Where(c => c.Book.ID == bookId).ToList();
        }

        public bool CreateChapter(Chapter chapter)
        {
            _context.Add(chapter);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateChapter(Chapter chapter)
        {
            _context.Update(chapter);

            return Save();
        }

        public bool DeleteChapter(Chapter chapter)
        {
            _context.Remove(chapter);

            return Save();
        }
    }
}
