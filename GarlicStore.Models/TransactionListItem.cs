using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class TransactionListItem
    {
        [DisplayName("Transaction Id")]
        public int TransactionId { get; set; }
        [DisplayName("Date of Transaction")]
        public DateTimeOffset DateOfTransaction { get; set; }
        [DisplayName("Total Cost")]
        public decimal OrderCost { get; set; }
    }
}
