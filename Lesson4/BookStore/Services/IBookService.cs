using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();
    }
}
