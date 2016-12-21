using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarEmpresa
{
    public class ListarEmpresaHandler : IDisposable
    {
        private readonly EmpresaRepositorio repositorio;
        public ListarEmpresaHandler()
        {
            repositorio = new EmpresaRepositorio(
                            new FactoringContext()
                );
        }

        public void Dispose()
        {
            repositorio.Dispose();
        }

        public IEnumerable<ListarEmpresaViewModel> Ejecutar(string filtroCoUser)
        {
            var consulta = repositorio.Empresas.TrerTodos();


            consulta = consulta
                .Where(x =>
                x.CoUser.Equals(filtroCoUser)
                );

            return consulta.Select(e =>
                         new ListarEmpresaViewModel()
                         {
                             NuRuc = e.NuRuc,
                             TxRazonSocial = e.TxRazonSocial,
                             TxDireccion = e.TxDireccion,
                             NoDepartamento = e.NoDepartamento,
                             NoProvincia = e.NoProvincia,
                             NoDistrito=e.NoDistrito,
                             TxRubro=e.TxRubro,
                             CoUser=e.CoUser
                         }
                     ).ToList();
        }
    }
}