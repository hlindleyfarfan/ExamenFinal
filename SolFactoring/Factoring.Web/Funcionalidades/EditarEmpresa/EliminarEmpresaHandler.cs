using Factoring.Modelo;
using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.EditarEmpresa
{
    public class EliminarEmpresaHandler:IDisposable
    {
        private readonly EmpresaRepositorio repositorio;
        public EliminarEmpresaHandler()
        {
            repositorio = new EmpresaRepositorio(new FactoringContext());
        }

        public void Ejecutar(EliminarEmpresaViewModel modelo)
        {
            Empresa empresa = CreaEmpresa(modelo);
            repositorio.Empresas.Eliminar(empresa);
            repositorio.Commit();
        }
        private Empresa CreaEmpresa(EliminarEmpresaViewModel modelo)
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
                CoUserModif = modelo.CoUserModif,
                FeModif = DateTime.Now
            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}