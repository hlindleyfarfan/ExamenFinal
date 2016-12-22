using Factoring.Web.Funcionalidades.ListarFactura;
using Factoring.Web.Funcionalidades.RegistrarEmpresa;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.EditarEmpresa
{
    public class EliminarEmpresaViewModelValidator : AbstractValidator<EliminarEmpresaViewModel>
    {
        public EliminarEmpresaViewModelValidator()
        {
            RuleFor(Modelo => Modelo.NuRuc)
               .Must(ValidaSinFacturas)
               .WithMessage("No se permite eliminar, tiene facturas registradas.");
        }

        private bool ValidaSinFacturas(EliminarEmpresaViewModel modelo, string vstrNuRUC)
        {
            ListarFacturaHandler obj = new ListarFacturaHandler();
            return obj.NoExistenFacturasxEmpresa(modelo.NuEmpresa);
        }
    }
}