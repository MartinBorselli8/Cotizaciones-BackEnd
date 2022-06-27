using System;

namespace dominio.infraestructura
{
    /// <summary>
    /// Entidad base
    /// </summary>
    public class EntidadBase
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Identificador que nos indica el usuario que creo la entidad
        /// </summary>
        public virtual int? UsuarioAlta { get; set; }

        /// <summary>
        /// Identificador que nos indica la fecha de creacion de la entidad
        /// </summary>
        public virtual DateTime? FechaAlta { get; set; }

        /// <summary>
        /// Identificador que nos indica el ultimo usuario que actualizo la entidad
        /// </summary>
        public virtual int? UsuarioActualiza { get; set; }

        /// <summary>
        /// Identificador que nos indica la ultima fecha de actualizacion de la entidad
        /// </summary>
        public virtual DateTime? FechaActualiza { get; set; }

        /// <summary>
        /// Identificador que nos indica el usuario que borro la entidad
        /// </summary>
        public virtual int? UsuarioElimina { get; set; }

        /// <summary>
        /// Identificador que nos indica la fecha de borrado de la entidad
        /// </summary>
        public virtual DateTime? FechaElimina { get; set; }
    }
}
