using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using Factoring.Web.Funcionalidades.EditarFactura;
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


        public RegistrarFacturaViewModel Execute(int NuEmpresa, string CoUser)
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
                CoUserModif = CoUser,
                FeModif = DateTime.Today
            };
            
        }

        public EditarFacturaViewModel ExecuteEdicion(int IdFactura)
        {
            var factura = repositorio.Facturas.TraerUno(x => x.IdFactura == IdFactura);
            return new EditarFacturaViewModel()
            {

                IdFactura = factura.IdFactura,
                NuFactura = factura.NuFactura,
                FeEmision = factura.FeEmision,
                FeVencimiento = factura.FeVencimiento,
                FeCobro = factura.FeCobro,
                NuEmpresa = factura.NuEmpresa,
                NuRuc = factura.NuRuc,
                TxRazonSocial = factura.TxRazonSocial,
                SsTotFactura = factura.SsTotFactura,
                SsTotImpuestos = factura.SsTotImpuestos,
                CoUserModif = factura.CoUserModif,
                FeModif = DateTime.Today
            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }

    }
}