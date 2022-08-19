using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.entidades
{
    public class Quote
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Price { get; set; }
        public int IdClient { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Condition { get; set; }
    }
}
