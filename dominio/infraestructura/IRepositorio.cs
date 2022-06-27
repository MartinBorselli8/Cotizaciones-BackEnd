using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace dominio.infraestructura
{
    /// <summary>
    /// Repositorio encargado de las transacciones mas comunes sobre la session de NH
    /// </summary>
    public interface IRepositorio<T> where T : EntidadBase
    {
        /// <summary>
        /// Busca todos las entidades de la tabla correspondiente filtradas por el predicado en la base de datos.
        /// </summary>
        Task<List<T>> Buscar(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Busca todos las entidades de la tabla correspondiente filtradas por el predicado en la base de datos.
        /// </summary>
        Task<List<T>> BuscarTodos();

        /// <summary>
        /// Obtiene la entidad filtrada por el identificador en la base de datos
        /// </summary>
        Task<T> Obtener(int id);

        /// <summary>
        /// Metodo que efectua la creacion de la entidad en la base de datos.
        /// </summary>
        Task Crear(T entidad);

        /// <summary>
        /// Metodo que efectua la actualizacion de la entidad en la base de datos.
        /// </summary>
        Task Actualizar(T entidad);
        //Task Insert(object modelDomain);

        /// <summary>
        /// Metodo que efectua el borrado de la entidad en la base de datos.
        /// </summary>
        Task Eliminar(T entidad);
    }
}
