using dominio.infraestructura;

namespace dominio.entidades
{
    public class User : EntidadBase
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

    }
}