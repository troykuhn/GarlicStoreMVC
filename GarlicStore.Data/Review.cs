using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "please choose a number between 1 and 5")]
        public float Rating { get; set; }

        public virtual Product Product { get; set; }

    }
}
