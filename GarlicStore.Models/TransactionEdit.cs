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
    public class TransactionEdit
    {
        
        [DisplayName("Transaction Id")]
        public int TransactionId { get; set; }

        
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        
        public DateTimeOffset UpdatedTransactionTime { get; set; }

        public virtual Product Product{ get; set; }
    }
}
