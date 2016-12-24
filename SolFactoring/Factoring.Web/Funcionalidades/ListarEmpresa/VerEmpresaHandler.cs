using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarEmpresa
{
    public class VerEmpresaHandler : IDisposable
    {
        private readonly EmpresaRepositorio repositorio;

        public VerEmpresaHandler()
        {
            repositorio = new EmpresaRepositorio(new FactoringContext());
        }


        public ListarEmpresaViewModel Execute(int NuEmpresa)
        {
            var empresa = repositorio.Empresas.TraerUno(x => x.NuEmpresa == NuEmpresa);
            return new ListarEmpresaViewModel()
            {

                NuEmpresa = empresa.NuEmpresa,
                NuRuc = empresa.NuRuc,
                TxRazonSocial = empresa.TxRazonSocial,
                TxDireccion = empresa.TxDireccion,
                NoDepartamento = empresa.NoDepartamento,
                NoProvincia = empresa.NoProvincia,
                NoDistrito = empresa.NoDistrito,
                TxRubro = empresa.TxRubro,
                CoUser = empresa.CoUser,
                CoUserModif = empresa.CoUserModif,
                FeModif = DateTime.Now
            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }

    }
}