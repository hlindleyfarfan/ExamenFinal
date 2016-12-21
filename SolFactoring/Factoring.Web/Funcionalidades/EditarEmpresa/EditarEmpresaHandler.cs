using Factoring.Modelo;
using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.EditarEmpresa
{
    public class EditarEmpresaHandler : IDisposable
    {
        private readonly EmpresaRepositorio repositorio;
        public EditarEmpresaHandler()
        {
            repositorio = new EmpresaRepositorio(new FactoringContext());
        }

        public void Ejecutar(EditarEmpresaViewModel modelo)
        {
            
            Empresa empresa = CreaEmpresa(modelo);
           
            repositorio.Empresas.Actualizar(empresa);
            repositorio.Commit();
        }

        private Empresa CreaEmpresa(EditarEmpresaViewModel modelo)
        {
            return new Empresa()
            {
                NuEmpresa = modelo.NuEmpresa,
                NuRuc = modelo.NuRuc,
                TxRazonSocial = modelo.TxRazonSocial,
                TxDireccion = modelo.TxDireccion,
                NoDepartamento = modelo.NoDepartamento,
                NoProvincia = modelo.NoProvincia,
                NoDistrito = modelo.NoDistrito,
                TxRubro = modelo.TxRubro,
                CoUser = modelo.CoUser,
                CoUserModif=modelo.CoUserModif,
                FeModif=modelo.FeModif
            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}