using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Statitics
{
    public class GetDataForStatiticsResponse
    {
        public List<string> ProductNames { get; set; }
        public List<int> ProductCounts { get; set; }

        public List<string> QuoteStates { get; set; }
        public List<int> QuoteCounts { get; set; }
    }
}
