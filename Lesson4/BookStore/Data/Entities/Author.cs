using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data.Entities
{
    [Table("author")]
    public class Author
    {
        [Key]

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();


    }
}
