using dominio.infraestructura;
using System;
using System.Collections.Generic;
using System.Text;

namespace dominio.entidades
{
    public class Clients : EntidadBase
    {
        public virtual string Name { get; set; }
        public virtual string  LastName { get; set; }
        public virtual int Dni { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

    }
}
