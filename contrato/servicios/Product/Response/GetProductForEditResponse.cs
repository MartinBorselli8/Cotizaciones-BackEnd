using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Product.Response
{
    public class GetProductForEditResponse
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
