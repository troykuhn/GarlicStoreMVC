using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public DateTimeOffset DateOfTransaction { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Product Price")]
        public decimal Price { get; set; }
        public decimal OrderCost { get; set; }
        public string ProductName { get; set; }
    }
}
