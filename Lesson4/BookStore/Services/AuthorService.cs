using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            //return await context.Authors
            //    .Include(a => a.Books)  
            //    .Select(x => AuthorDTOExtensions.AuthorWithBookToDTO(x))
            //    .ToListAsync();



            var authors = await context.Authors.ToListAsync();

            var result = new List<AuthorWithBookDTO>();

            foreach (var author in authors)
            {

                var dto = new AuthorWithBookDTO(
                    author.Id,
                    author.FirstName,
                    author.LastName,
                    author.Address,
                    author.City,
                    author.Books
                        .Select(b => BookDTOExtensions.ToDTO(b))
                        .ToArray()
                );

                result.Add(dto);
            }

            return result;
        }

        public async Task<(int count, List<AuthorDTO> data)> SearchAuthors(int? id,string? name, string? surname,string? address, string? city,int? page,int? pageSize)
        {
            var query = context.Authors.AsQueryable();

            if (id.HasValue)
                query = query.Where(a => a.Id == id.Value);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.FirstName.Contains(name));

            if (!string.IsNullOrEmpty(surname))
                query = query.Where(a => a.LastName.Contains(surname));

            if (!string.IsNullOrEmpty(address))
                query = query.Where(a => a.Address.Contains(address));

            if (!string.IsNullOrEmpty(city))
                query = query.Where(a => a.City.Contains(city));

            int count = await query.CountAsync();


            query = query
                .OrderBy(a => a.Id)
                .Skip((int)((page - 1) * pageSize))
                .Take((int)pageSize);

            var authors = await query.ToListAsync();

            return (count, authors.Select(a => AuthorDTOExtensions.ToDTO(a)).ToList());
        }

        public async Task<(bool hasNext, bool hasPrev, List<AuthorDTO> data)> SearchAuthors2(
      int? id, string? name, string? surname, string? address, string? city, int? page, int? pageSize)
        {
            int currentPage = page ?? 1;
            int currentPageSize = pageSize ?? 10;

            var query = context.Authors.AsQueryable();

            if (id.HasValue)
                query = query.Where(a => a.Id == id.Value);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.FirstName.Contains(name));

            if (!string.IsNullOrEmpty(surname))
                query = query.Where(a => a.LastName.Contains(surname));

            if (!string.IsNullOrEmpty(address))
                query = query.Where(a => a.Address.Contains(address));

            if (!string.IsNullOrEmpty(city))
                query = query.Where(a => a.City.Contains(city));

            // OrderBy əvvəl gəlməlidir
            query = query.OrderBy(a => a.Id)
                         .Skip((currentPage - 1) * currentPageSize)
                         .Take(currentPageSize + 1); // 1 əlavə götür

            var authors = await query.ToListAsync();

            bool hasPrev = currentPage > 1;
            bool hasNext = authors.Count > currentPageSize;

            var data = authors.Take(currentPageSize)
                              .Select(a => AuthorDTOExtensions.ToDTO(a))
                              .ToList();

            return (hasNext, hasPrev, data);
        }


    }
}
