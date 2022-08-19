using dominio.infraestructura;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.entidades
{
    public class Products : EntidadBase
    {
        public virtual string Description { get; set; }
        public virtual decimal UnitPrice { get; set; }
        
    }
}
