using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Product.Request
{
    public class AddProductRequest
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
