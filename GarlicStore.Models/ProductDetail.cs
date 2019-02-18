using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}
