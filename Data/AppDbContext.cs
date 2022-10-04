using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_Inventory.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Inventory.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
            .HasOne(b => b.Book)
            .WithMany(ba => ba.Authors)
            .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
            .HasOne(a => a.Author)
            .WithMany(ba => ba.Books)
            .HasForeignKey(bi => bi.AuthorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}