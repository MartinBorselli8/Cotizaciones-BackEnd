using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Quote.Response
{
    public class GetQuotesResponse
    {
        public List<contrato.entidades.Quote> Quotes { get; set; }
    }
}
