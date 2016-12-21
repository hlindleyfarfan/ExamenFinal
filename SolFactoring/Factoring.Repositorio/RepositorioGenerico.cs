using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.Repositorio
{
    public class RepositorioGenerico<TEntidad> where TEntidad : class
    {
        private readonly DbContext bd;
        public RepositorioGenerico(DbContext baseDatos)
        {
            this.bd = baseDatos;
        }
        public TEntidad TraerUno(Expression<Func<TEntidad, bool>> predicado)
        {
            return bd.Set<TEntidad>().SingleOrDefault(predicado);
        }

        public IQueryable<TEntidad> TraeVarios(Expression<Func<TEntidad, bool>> predicado)
        {
            return bd.Set<TEntidad>().Where(predicado);

        }

        public IQueryable<TEntidad> TrerTodos()
        {
            return bd.Set<TEntidad>();
        }

        public void Agregar(TEntidad entidad)
        {
            bd.Set<TEntidad>().Add(entidad);
        }

        public void Eliminar(TEntidad entidad)
        {
            if (bd.Entry<TEntidad>(entidad).State == System.Data.Entity.EntityState.Detached)
                bd.Set<TEntidad>().Attach(entidad);
            bd.Set<TEntidad>().Remove(entidad);

            //bd.Entry<TEntidad>(entidad).State = System.Data.Entity.EntityState.Deleted;
            //bd.SaveChanges();
        }

        public void Actualizar(TEntidad entidad)
        {
            if (bd.Entry<TEntidad>(entidad).State == System.Data.Entity.EntityState.Detached)
                bd.Set<TEntidad>().Attach(entidad);

            bd.Entry<TEntidad>(entidad).State = System.Data.Entity.EntityState.Modified;
        }

        public void ActualizaMaestroDetalle<TMaestro, TDetalle>(
                                        TMaestro modificado, string coleccionDetalle,
                                        Expression<Func<TMaestro, bool>> expressionMaestro,
                                        Func<TDetalle, TDetalle> mapeo
                                        )
                where TMaestro : class
                where TDetalle : class
        {
            TMaestro original = bd.Set<TMaestro>().Include(coleccionDetalle).Single(expressionMaestro);

            bd.Entry(original).CurrentValues.SetValues(modificado); // actualizando maestro

            var detalleOriginal = ObtieneDetalle<TMaestro, TDetalle>(original, coleccionDetalle);
            var detalleModificado = ObtieneDetalle<TMaestro, TDetalle>(modificado, coleccionDetalle);

            foreach (TDetalle trackAEliminar in detalleOriginal.ToList())
            {
                // Func<TDetalle ,bool>  m => m.TrackId == trackAEliminar.TrackId)
                if (!detalleModificado.Any(CreaFuncion<TDetalle>(trackAEliminar)))
                    bd.Set<TDetalle>().Remove(trackAEliminar);
            }

            foreach (TDetalle trackModificado in detalleModificado.ToList())
            {
                TDetalle trackOriginal = detalleOriginal.SingleOrDefault(CreaFuncion<TDetalle>(trackModificado));

                if (trackOriginal == null)
                {
                    TDetalle nuevo = mapeo(trackModificado);
                    detalleOriginal.Add(nuevo);
                }
                else
                {
                    bd.Entry(trackOriginal).CurrentValues.SetValues(trackModificado);
                }
            }
            bd.SaveChanges();
        }

        private Func<TDetalle, bool> CreaFuncion<TDetalle>(TDetalle entidad) where TDetalle : class
        {
            // CreaFuncion F(x)   => 
            var propiedad = ObtienePropiedadId<TDetalle>();   // obtiene el nombre de la propiedad  => TrackId
            var valor = ObtieneValorPropiedad<TDetalle>(entidad, propiedad);  // el valor que contiene la propiedad

            var parametro = Expression.Parameter(typeof(TDetalle)); // la x de mi funcion

            var izquierda = MemberExpression.Property(parametro, propiedad);

            var tipoPropiedad = typeof(TDetalle).GetProperty(propiedad).PropertyType;

            var derecha = Expression.Constant(Convert.ChangeType(valor, tipoPropiedad)); // conversin necesara para que compile la expression
                                                                                         //=               TrackId   obj.TrackId
                                                                                         // se contruye la expresion
            Expression expression = Expression.MakeBinary(ExpressionType.Equal, izquierda, derecha);

            // compilo expresion
            return Expression.Lambda<Func<TDetalle, bool>>(expression, parametro).Compile();

        }

        private int ObtieneValorPropiedad<TDetalle>(TDetalle entidad, string propiedad) where TDetalle : class
        {
            // esta implementacion es para objetos que estan amrrados a un ORM como EF o NHibernate

            return (int)entidad.GetType().GetProperty(propiedad).GetValue(entidad, null);
        }

        private string ObtienePropiedadId<TDetalle>() where TDetalle : class
        {
            // esta basado enla convension PropedadId = NombreTipo+Id => AlbumId
            return typeof(TDetalle).Name + "Id";
        }

        private ICollection<TDetalle> ObtieneDetalle<TMaestro, TDetalle>(TMaestro entidad, string coleccionDetalle)
            where TMaestro : class
            where TDetalle : class
        {
            return (ICollection<TDetalle>)entidad.GetType().GetProperty(coleccionDetalle).GetValue(entidad, null);
        }


    }
}
