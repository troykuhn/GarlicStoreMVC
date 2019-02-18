using GarlicStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class TransactionCreate
    {
        [Required]
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required]
        public decimal OrderCost { get; set; }

        public virtual Product Product { get; set; }
    }
}
