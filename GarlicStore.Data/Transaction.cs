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
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal OrderCost { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
