using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Entities
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
