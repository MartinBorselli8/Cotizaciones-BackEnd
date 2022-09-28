using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace contrato.servicios.Product.Request
{
    public class AddProductRequest
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
