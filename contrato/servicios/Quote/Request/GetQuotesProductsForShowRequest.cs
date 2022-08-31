using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class GetQuotesProductsForShowRequest
    {
        public int IdQuote { get; set; }
        public bool IsForEdit { get; set; }
    }
}
