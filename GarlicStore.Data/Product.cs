﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicStore.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}
