using dominio;
using dominio.infraestructura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace datos.Infraestructura
{
    public class Repositorio<T> : IRepositorio<T> where T : EntidadBase
    {
        private readonly Contexto contexto;

        public Repositorio(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public async Task Actualizar(T entidad)
        {
            entidad.FechaActualiza= DateTime.Now;
            entidad.UsuarioActualiza = 0;
            contexto.Entry(entidad).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public async Task<List<T>> Buscar(Expression<Func<T, bool>> predicado)
        {
            return await contexto.Set<T>().Where(predicado).Where(e => e.FechaElimina == null).ToListAsync();
        }

        public async Task Eliminar(T entidad)
        {
            entidad.FechaElimina = DateTime.Now;
            entidad.UsuarioElimina = 0;
            contexto.Entry(entidad).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }

        public async Task Crear(T entidad)
        {
            entidad.FechaAlta= DateTime.Now;
            entidad.UsuarioAlta = 0;
            contexto.Entry(entidad).State = EntityState.Added;
            await contexto.Set<T>().AddAsync(entidad);
            await contexto.SaveChangesAsync();
        }

        public async Task<T> Obtener(int id)
        {
            return await contexto.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> BuscarTodos()
        {
            return await contexto.Set<T>().Where(e => e.FechaElimina == null).ToListAsync();
        }
    }
}
