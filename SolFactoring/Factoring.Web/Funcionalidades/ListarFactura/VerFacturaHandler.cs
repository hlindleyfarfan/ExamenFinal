using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using Factoring.Web.Funcionalidades.RegistrarFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarFactura
{
    public class VerFacturaHandler:IDisposable
    {
        private readonly FacturaRepositorio repositorio;

        public VerFacturaHandler()
        {
            repositorio = new FacturaRepositorio(new FactoringContext());
        }


        public RegistrarFacturaViewModel Execute(int NuEmpresa)
        {

            return new RegistrarFacturaViewModel()
            {
                IdFactura=0,
                NuFactura = String.Empty,
                FeEmision = DateTime.Today,
                FeVencimiento = DateTime.Today,
                FeCobro = DateTime.Today,
                NuEmpresa = NuEmpresa,
                NuRuc = String.Empty,
                TxRazonSocial = String.Empty,
                SsTotFactura = 0,
                SsTotImpuestos = 0,
                CoUserModif = String.Empty,
                FeModif = DateTime.Today
            };
            
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }

    }
}