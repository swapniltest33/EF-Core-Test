using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Structure.Core.Models
{
    public partial class Product
    {
        public long ProductId { get; set; }
        [ConcurrencyCheck]
        public string? ProductName { get; set; }
        public Category Category { get; set; }  
    }
}
