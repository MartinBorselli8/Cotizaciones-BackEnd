using dominio.infraestructura;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.entidades
{
    public class QuotesProducts : EntidadBase
    {
        public int IdQuote { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
    }
}
