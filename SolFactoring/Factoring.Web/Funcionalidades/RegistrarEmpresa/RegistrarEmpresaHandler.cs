using Factoring.Modelo;
using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.RegistrarEmpresa
{
    public class RegistrarEmpresaHandler : IDisposable
    {


        private readonly EmpresaRepositorio repositorio;
        public RegistrarEmpresaHandler()
        {
            repositorio = new EmpresaRepositorio(new FactoringContext());
        }

        public void Ejecutar(RegistrarEmpresaViewModel modelo)
        {

            Empresa empresa = CreaEmpresa(modelo);

            repositorio.Empresas.Agregar(empresa);
            repositorio.Commit();
        }

        private Empresa CreaEmpresa(RegistrarEmpresaViewModel modelo)
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