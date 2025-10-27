using BookStore.Data.Entities;

namespace BookStore.Models
{

        public record AuthorDTO(int Id, string FirstName, string LastName, string Address, string City);

        public record AuthorWithBookDTO(int Id, string FirstName, string LastName, string Address, string City, BookDTO[] Books);


    public class PageableRequestDTO
    {
        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 2;
        public string? Sort { get; set; } = "id";
    }

    public class AuthorSearchRequestDTO: PageableRequestDTO{ 
    
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    };

    public static class AuthorDTOExtensions
        {
            public static AuthorDTO ToDTO(this Author author) => new(author.Id, author.FirstName, author.LastName, author.Address, author.City);

        public static AuthorWithBookDTO AuthorWithBookToDTO(this Author author) 
        {
            return new AuthorWithBookDTO(
                author.Id,
                author.FirstName,
                author.LastName,
                author.Address,
                author.City,
                author.Books.Select(b => b.ToDTO()).ToArray()
            );



        }
    }
    

}
