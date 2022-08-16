using dominio.infraestructura;

namespace dominio.entidades
{
    public class Users : EntidadBase
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

    }
}