using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public static class PagingHelper
    {
        public static async Task<(bool hasNext, bool hasPrev, List<AuthorDTO> data)> ApplyPagingAsync(IQueryable<Data.Entities.Author> query, int? page, int? pageSize)
        {
            int currentPage = page.GetValueOrDefault(1);
            int currentPageSize = pageSize.GetValueOrDefault(10);


            var authors = await query
                //.OrderBy(a => a.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize + 1) 
                .ToListAsync();

            bool hasPrev = currentPage > 1;
            bool hasNext = authors.Count > currentPageSize;

            var data = authors
                .Take(currentPageSize)
                .Select(a => a.ToDTO())
                .ToList();


            return (hasNext, hasPrev, data);
        }
    }
}
