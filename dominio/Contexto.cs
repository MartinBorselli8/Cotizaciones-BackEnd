using dominio.entidades;
using Microsoft.EntityFrameworkCore;

namespace dominio
{
    public class Contexto : DbContext
    {        
        public Contexto(DbContextOptions<Contexto> opciones) : base(opciones) { }
        public DbSet<Users> Users {get; set;}
        public DbSet<Clients> Clients {get; set;}
    }
}
