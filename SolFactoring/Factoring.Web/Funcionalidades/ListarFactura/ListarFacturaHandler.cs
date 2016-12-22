using Factoring.Repositorio;
using Factoring.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarFactura
{
    public class ListarFacturaHandler:IDisposable
    {
        private readonly FacturaRepositorio repositorio;
        public ListarFacturaHandler()
        {
            repositorio = new FacturaRepositorio(
                            new FactoringContext()
                );
        }

        public void Dispose()
        {
            repositorio.Dispose();
        }

        public IEnumerable<ListarFacturaViewModel> Ejecutar(int filtroNuEmpresa)
        {
            var consulta = repositorio.Facturas.TrerTodos();


            consulta = consulta
                .Where(x =>
                x.NuEmpresa.Equals(filtroNuEmpresa)
                );

            return consulta.Select(e =>
                         new ListarFacturaViewModel()
                         {
                             IdFactura=e.IdFactura,
                             NuFactura=e.NuFactura,
                             FeEmision=e.FeEmision,
                             //FeVencimiento=e.FeVencimiento,
                             //FeCobro=e.FeCobro,
                             //NuEmpresa = e.NuEmpresa,
                             //NuRuc = e.NuRuc,
                             TxRazonSocial = e.TxRazonSocial,
                             SsTotFactura=e.SsTotFactura,
                             SsTotImpuestos=e.SsTotImpuestos,
                             //CoUserModif = e.CoUserModif,
                             //FeModif = e.FeModif
                         }
                     ).ToList();
        }
    }
}