using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Db.IDb
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<UsersBooks> UsersBooks { get; set; }
        DbSet<BooksAuthors> BooksAuthors { get; }
        DbSet<BooksCategories> BooksCategories { get; set; }
        DbSet<WishList> WishList { get; set; }
        DbSet<ReadList> ReadList { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
