using Factoring.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Repositorio.Impl
{
    public class FacturaRepositorio:IDisposable
    {
        private readonly DbContext bd;

        private readonly RepositorioGenerico<Factura> _facturas;

        public FacturaRepositorio(DbContext bd)
        {
            this.bd = bd;
            _facturas = new RepositorioGenerico<Factura>(bd);
        }

        public RepositorioGenerico<Factura> Empresas { get { return _facturas; } }

        public void Commit()
        {
            bd.SaveChanges();
        }

        public void Dispose()
        {
            bd.Dispose();
        }

    }
}
