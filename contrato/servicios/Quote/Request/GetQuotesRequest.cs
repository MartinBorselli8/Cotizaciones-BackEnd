using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class GetQuotesRequest
    {
        public int? Id { get; set; }
        public string DateTo { get; set; }
        public int? IdClient { get; set; }
        public string DateFrom { get; set; }
        public string Condition { get; set; }
    }
}
