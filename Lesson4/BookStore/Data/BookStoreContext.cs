using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext(DbContextOptions<BookStoreContext> options): DbContext(options)
    {
        public DbSet<Entities.Book> Books { get; set; }

    }
}
