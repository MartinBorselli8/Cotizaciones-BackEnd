using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Product.Request
{
    public class PutProductRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
