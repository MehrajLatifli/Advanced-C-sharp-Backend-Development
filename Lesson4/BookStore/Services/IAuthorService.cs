using BookStore.Models;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthorsAsync();
        Task<List<AuthorWithBookDTO>> GetAuthorsWithBookAsync();

        Task<(int count, List<AuthorDTO> data)> SearchAuthors(int? id, string? name, string surname, string address, string city, int? page, int? pageSize);

        Task<(bool hasNext, bool hasPrev, List<AuthorDTO> data)> SearchAuthors2(AuthorSearchRequestDTO authorSearchRequestDTO);
    }
}