using Librarian.BackEnd.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Librarian.BackEnd.Entity.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookUser>(bu =>
            {
                bu.HasOne(b => b.Reader).WithMany(b => b.Books);
                bu.HasOne(b => b.Book).WithMany(b => b.Readers);
            });
        }

    }
}
