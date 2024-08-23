using LibraryAPI.Db.IDb;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Db
{
    public class InMemoryDbContext : DbContext, IDbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UsersBooks> UsersBooks { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<BooksCategories> BooksCategories { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<ReadList> ReadList { get; set; }
    }
}
