using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class EditQuotesProductsRequest
    {
        public int Id { get; set; }
        public int NewAmount { get; set; }
    }
}
