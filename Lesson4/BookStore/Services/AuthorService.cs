using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<(bool hasNext, bool hasPrev, List<AuthorDTO> data)> SearchAuthors2(AuthorSearchRequestDTO authorSearchRequestDTO)
        {

            var query = context.Authors.AsQueryable();

            if (authorSearchRequestDTO.Id.HasValue)
                query = query.Where(a => a.Id == authorSearchRequestDTO.Id.Value);

            if (!string.IsNullOrEmpty(authorSearchRequestDTO.FirstName))
                query = query.Where(a => a.FirstName.Contains(authorSearchRequestDTO.FirstName));

            if (!string.IsNullOrEmpty(authorSearchRequestDTO.LastName))
                query = query.Where(a => a.LastName.Contains(authorSearchRequestDTO.LastName));

            if (!string.IsNullOrEmpty(authorSearchRequestDTO.Address))
                query = query.Where(a => a.Address.Contains(authorSearchRequestDTO.Address));

            if (!string.IsNullOrEmpty(authorSearchRequestDTO.City))
                query = query.Where(a => a.City.Contains(authorSearchRequestDTO.City));


            //if (authorSearchRequestDTO.Sort == "name")
            //{
            //    query = query.OrderBy(a => a.FirstName);
            //}
            //else if (authorSearchRequestDTO.Sort == "-name")
            //{
            //    query = query.OrderByDescending(a => a.FirstName);
            //}


            if (!string.IsNullOrEmpty(authorSearchRequestDTO.Sort))
            {

                bool descending = authorSearchRequestDTO.Sort.StartsWith("-");
                
                string propertyName = descending
                    ? authorSearchRequestDTO.Sort.Substring(1)
                    : authorSearchRequestDTO.Sort;

                propertyName = char.ToUpper(propertyName[0]) + propertyName.Substring(1);


                if (typeof(Author).GetProperty(propertyName) == null)
                {
                    propertyName = "Id";
                }


                query = descending
                    ? query.OrderByDescending(a => EF.Property<object>(a, propertyName))
                    : query.OrderBy(a => EF.Property<object>(a, propertyName));


            }
            else
            {
                query = query.OrderBy(a => a.Id);

              
            }

            var (hasNext, hasPrev, data) = await PagingHelper.ApplyPagingAsync(query, authorSearchRequestDTO.Page, authorSearchRequestDTO.PageSize);

            return (hasNext, hasPrev, data);
        }


    }
}
