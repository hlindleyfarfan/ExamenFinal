using Factoring.Modelo;
using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.EditarFactura
{
    public class EditarFacturaHandler:IDisposable
    {
        private readonly FacturaRepositorio repositorio;
        public EditarFacturaHandler()
        {
            repositorio = new FacturaRepositorio(new FactoringContext());
        }

        public void Ejecutar(EditarFacturaViewModel modelo)
        {

            Factura factura = CreaFactura(modelo);

            repositorio.Facturas.Actualizar(factura);
            repositorio.Commit();
        }

        private Factura CreaFactura(EditarFacturaViewModel e)
        {
            return new Factura()
            {
                IdFactura = e.IdFactura,
                NuFactura = e.NuFactura,
                FeEmision = e.FeEmision,
                FeVencimiento = e.FeVencimiento,
                FeCobro = e.FeCobro,
                NuEmpresa = e.NuEmpresa,
                NuRuc = e.NuRuc,
                TxRazonSocial = e.TxRazonSocial,
                SsTotFactura = e.SsTotFactura,
                SsTotImpuestos = e.SsTotImpuestos,
                CoUserModif = e.CoUserModif,
                FeModif = DateTime.Today
            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}