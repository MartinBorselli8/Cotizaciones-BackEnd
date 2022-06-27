using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace dominio
{
    /// <summary>
    /// Predicado comun con metodos para crear expresiones regulares
    /// </summary>
    public static class CrearPredicado
    {
        /// <summary>  
        /// Crea un predicado que evalúa en verdadero  
        /// </summary>  
        public static Expression<Func<T, bool>> Verdadero<T>() { return param => true; }

        /// <summary>  
        /// Crea predicado que evalúa en falso
        /// </summary>  
        public static Expression<Func<T, bool>> Falso<T>() { return param => false; }

        /// <summary>  
        /// Crea una predicado a partir de una expresión lambda
        /// </summary>  
        public static Expression<Func<T, bool>> Crear<T>(Expression<Func<T, bool>> predicado) { return predicado; }

        /// <summary>  
        /// Combina el primer predicado con el segundo utilizando una conjunción "Y".  
        /// </summary>  
        public static Expression<Func<T, bool>> Y<T>(this Expression<Func<T, bool>> primero, Expression<Func<T, bool>> segundo)
        {
            return primero.Combinar(segundo, Expression.AndAlso);
        }

        /// <summary>  
        /// Combina el primer predicado con el segundo utilizando una conjunción "O"
        /// </summary>  
        public static Expression<Func<T, bool>> O<T>(this Expression<Func<T, bool>> primero, Expression<Func<T, bool>> segundo)
        {
            return primero.Combinar(segundo, Expression.OrElse);
        }

        /// <summary>  
        /// Niega el predicado
        /// </summary>  
        public static Expression<Func<T, bool>> No<T>(this Expression<Func<T, bool>> expresion)
        {
            var negado = Expression.Not(expresion.Body);
            return Expression.Lambda<Func<T, bool>>(negado, expresion.Parameters);
        }

        /// <summary>  
        /// Combina la primer expresión con la segunda
        /// </summary>  
        private static Expression<T> Combinar<T>(this Expression<T> primera, Expression<T> segunda, Func<Expression, Expression, Expression> mezclar)
        {
            // zip parameters (map from parameters of second to parameters of first)  
            var mapeo = primera.Parameters
                .Select((f, i) => new { f, s = segunda.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first  
            var cuerpoSecundario = ReasignarParametro.ReemplazarParametro(mapeo, segunda.Body);

            // create a merged lambda expression with parameters from the first expression  
            return Expression.Lambda<T>(mezclar(primera.Body, cuerpoSecundario), primera.Parameters);
        }

        private class ReasignarParametro : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, ParameterExpression> _mapeo;

            private ReasignarParametro(Dictionary<ParameterExpression, ParameterExpression> mapeo)
            {
                _mapeo = mapeo ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReemplazarParametro(Dictionary<ParameterExpression, ParameterExpression> mapeo, Expression expresion)
            {
                return new ReasignarParametro(mapeo).Visit(expresion);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (_mapeo.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }
    }
}
