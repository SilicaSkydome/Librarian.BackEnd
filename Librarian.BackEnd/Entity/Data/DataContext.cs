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
        public DbSet<BookUserReading> BookUserReadings { get; set; } = null!;
        public DbSet<BookUserWriting> BookUserWritings { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Chapter> Chapters { get; set; } = null!;
        public DbSet<ChapterReview> chapterReviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.Property(u => u.Name)
                .HasDefaultValue("username");
                u.Property(u => u.Role)
                .HasDefaultValue("user");

            });
            modelBuilder.Entity<Book>(b =>
            {
                b.HasOne(b => b.Author)
                .WithOne(b => b.Book)
                .HasForeignKey<BookUserWriting>(b => b.BookId);
            });
            modelBuilder.Entity<BookUserReading>(bu =>
            {
                bu.HasOne(b => b.Reader).WithMany(b => b.Reading)
                .HasForeignKey(b => b.ReaderId).OnDelete(DeleteBehavior.Restrict);
                bu.HasOne(b => b.Book).WithMany(b => b.Readers)
                .HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<BookUserWriting>(b =>
            {
                b.HasOne(b => b.Author)
                .WithMany(b => b.Writing)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

                b.HasOne(b => b.Book)
                 .WithOne(b => b.Author)
                 .OnDelete(DeleteBehavior.Restrict);
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
