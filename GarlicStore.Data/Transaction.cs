using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int ProductId { get; set; }
        public decimal OrderCost { get; set; }
        public virtual Product Product { get; set; }
        public int MyProperty { get; set; }
    }
}
