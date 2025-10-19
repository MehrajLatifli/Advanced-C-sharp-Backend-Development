using BookStore.Data.Entities;

namespace BookStore.Models
{
    public record BookDTO(int Id, string Name, int PageCount);

    public static class BookDTOExtensions
    {
        public static BookDTO ToDTO(this Book book) =>
            new(book.Id, book.Name, book.PageCount);
    }
}
