using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{
    public class AuthorService(BookStoreContext context) : IAuthorService
    {
        public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
        {
            return await context.Authors
                .Select(x => AuthorDTOExtensions.ToDTO(x))
                .ToListAsync();
        }

        public async Task<List<AuthorWithBookDTO>> GetAuthorsWithBookAsync()
        {
            return await context.Authors
                .Include(a => a.Books)  
                .Select(x => AuthorDTOExtensions.AuthorWithBookToDTO(x))
                .ToListAsync();
        }

    }
}
