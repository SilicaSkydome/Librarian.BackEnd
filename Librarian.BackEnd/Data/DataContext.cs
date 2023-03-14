using Librarian.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Librarian.BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChapterReview> chapterReviews { get; set; }
        
    }
}
