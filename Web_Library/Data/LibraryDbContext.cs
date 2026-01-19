using Microsoft.EntityFrameworkCore;
using Web_Library.Models;

namespace Web_Library.Data
{
    
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        :base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Book> Books { get; set; } = null!;

        public virtual DbSet<UserBook> UsersBooks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>().HasKey(ub => new { ub.UserId, ub.BookId });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

        }

    }
}
