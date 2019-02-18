using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Models
{
    public class ReviewCreate
    {
        [DisplayName("Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "please choose a number between 1 and 5")]
        [Required]
        public float Rating { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
