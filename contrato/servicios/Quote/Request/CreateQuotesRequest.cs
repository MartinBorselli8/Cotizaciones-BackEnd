using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class CreateQuotesRequest
    {
        public bool IsForEdit { get; set; }
        public int IdClient { get; set; }
        public int IdQuote { get; set; }
    }
}
