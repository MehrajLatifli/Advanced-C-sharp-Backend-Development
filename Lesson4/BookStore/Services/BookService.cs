using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{


    public class BookService(BookStoreContext context): IBookService
    {
        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            return await context.Books
                .Select(x =>BookDTOExtensions.ToDTO(x))
                .ToListAsync();
        }

    }
}
