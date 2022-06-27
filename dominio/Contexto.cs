using dominio.entidades;
using Microsoft.EntityFrameworkCore;

namespace dominio
{
    public class Contexto : DbContext
    {        
        public Contexto(DbContextOptions<Contexto> opciones) : base(opciones) { }
        public DbSet<User> User {get; set;}
    }
}
