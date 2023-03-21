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
                bu.HasOne(b => b.Reader).WithMany(b => b.Books)
                .HasForeignKey(b => b.ReaderId).OnDelete(DeleteBehavior.Restrict);
                bu.HasOne(b => b.Book).WithMany(b => b.Readers)
                .HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Review>(r =>
            {
                r.HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

                r.HasOne(r => r.Author)
                .WithMany()
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<ChapterReview>(cr =>
            {
                cr.HasOne(r => r.Chapter)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

                cr.HasOne(r => r.Author)
                .WithMany()
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
