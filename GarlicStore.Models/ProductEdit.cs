using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class ProductEdit
    {
        [Required]
        [DisplayName("Product ID")]
        public int ProductId { get; set; }
        
        [DisplayName("Stock Quantity")]
        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
