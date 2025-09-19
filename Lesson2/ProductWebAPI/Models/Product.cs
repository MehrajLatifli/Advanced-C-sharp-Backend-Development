using System.ComponentModel.DataAnnotations;

namespace ProductWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Rating is required.")]
        public byte? Rating { get; set; }
    }
}
