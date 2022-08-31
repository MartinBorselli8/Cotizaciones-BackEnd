using dominio.infraestructura;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.entidades
{
    public class Quotes : EntidadBase
    {
        public DateTime CreateDate { get; set; }
        public decimal Price { get; set; }
        public int IdClient { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Condition { get; set; }
    }
}
