using Factoring.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Repositorio.Impl
{
    public class EmpresaRepositorio : IDisposable
    {

        private readonly DbContext bd;

        private readonly RepositorioGenerico<Empresa> _empresas;

        public EmpresaRepositorio(DbContext bd)
        {
            this.bd = bd;
            _empresas = new RepositorioGenerico<Empresa>(bd);
        }

        public RepositorioGenerico<Empresa> Empresas { get { return _empresas; } }

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
