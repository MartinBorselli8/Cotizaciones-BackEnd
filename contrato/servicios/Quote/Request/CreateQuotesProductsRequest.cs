using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class CreateQuotesProductsRequest
    {
        public int IdQuote { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
    }
}
