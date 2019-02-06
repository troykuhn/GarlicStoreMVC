using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class ProductCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        [DisplayName("Stock Quantity")]
        public int StockQuantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
