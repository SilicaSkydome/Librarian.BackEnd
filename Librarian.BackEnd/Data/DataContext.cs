using Librarian.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Librarian.BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Chapter> Chapters { get; set; } = null!;
        public DbSet<ChapterReview> chapterReviews { get; set; } = null!;

    }
}
