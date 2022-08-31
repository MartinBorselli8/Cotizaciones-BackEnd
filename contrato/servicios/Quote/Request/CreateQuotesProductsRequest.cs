using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace contrato.servicios.Quote.Request
{
    public class CreateQuotesProductsRequest
    {
        public bool IsForEdit { get; set; }
        public int?  IdQuote { get; set; }
        public int IdProduct { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage ="Debe seleccionar una cantidad.")]
        public int Amount { get; set; }
    }
}
