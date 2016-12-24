using Factoring.Modelo;
using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.EditarFactura
{
    public class EliminarFacturaHandler:IDisposable
    {
        private readonly FacturaRepositorio repositorio;
        public EliminarFacturaHandler()
        {
            repositorio = new FacturaRepositorio(new FactoringContext());
        }

        public void Ejecutar(EditarFacturaViewModel modelo)
        {
            Factura factura = CreaFactura(modelo);
            repositorio.Facturas.Eliminar(factura);
            repositorio.Commit();
        }
        private Factura CreaFactura(EditarFacturaViewModel modelo)
        {
            return new Factura()
            {
                IdFactura = modelo.IdFactura,
                NuFactura = modelo.NuFactura,
                FeEmision = modelo.FeEmision,
                FeVencimiento = modelo.FeVencimiento,
                FeCobro = modelo.FeCobro,
                NuEmpresa = modelo.NuEmpresa,
                NuRuc = modelo.NuRuc,
                TxRazonSocial = modelo.TxRazonSocial,
                SsTotFactura = modelo.SsTotFactura,
                SsTotImpuestos = modelo.SsTotImpuestos,
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