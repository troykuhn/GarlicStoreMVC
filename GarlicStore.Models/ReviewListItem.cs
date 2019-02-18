using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public float Rating { get; set; }

        public string ProductName { get; set; }
    }
}
