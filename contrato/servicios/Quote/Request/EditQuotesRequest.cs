using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class EditQuotesRequest
    {
        public int IdQuote { get; set; }
        public int IdClient { get; set; }
    }
}
