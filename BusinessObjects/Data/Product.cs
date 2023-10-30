using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Data
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Category cannot be empty")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Product Name cannot be empty")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Weight cannot be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Weight must be bigger than {1}")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Price cannot be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than {1}")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Stock cannot be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "Stock must be bigger than {1}")]
        public int UnitslnStock { get; set; }
        public Category Category { get; set; }
    }
}
