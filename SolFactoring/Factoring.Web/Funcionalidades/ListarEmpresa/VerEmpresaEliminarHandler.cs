using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using Factoring.Web.Funcionalidades.EditarEmpresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarEmpresa
{
    public class VerEmpresaEliminarHandler:IDisposable
    {
        private readonly EmpresaRepositorio repositorio;

        public VerEmpresaEliminarHandler()
        {
            repositorio = new EmpresaRepositorio(new FactoringContext());
        }


        public EliminarEmpresaViewModel Execute(int NuEmpresa)
        {
            var empresa = repositorio.Empresas.TraerUno(x => x.NuEmpresa == NuEmpresa);
            return new EliminarEmpresaViewModel()
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
                FeModif = empresa.FeModif
            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}