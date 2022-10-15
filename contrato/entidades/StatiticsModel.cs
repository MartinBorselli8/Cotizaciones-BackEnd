using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.entidades
{
    public class StatiticsModel
    {
        public class Product
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public class Quote
        {
            public string State { get; set; }
            public int Count { get; set; }
        }
    }
}
