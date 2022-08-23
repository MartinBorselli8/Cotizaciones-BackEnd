using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Response
{
    public class GetQuotesResponse
    {
        public List<contrato.entidades.QuoteForShow> Quotes { get; set; }
    }
}
