using BookStore.Models;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthorsAsync();
        Task<List<AuthorWithBookDTO>> GetAuthorsWithBookAsync();
    }
}