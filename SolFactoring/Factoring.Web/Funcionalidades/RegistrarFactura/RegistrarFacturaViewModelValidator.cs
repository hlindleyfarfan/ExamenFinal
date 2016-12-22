using FluentValidation;
using System;


namespace Factoring.Web.Funcionalidades.RegistrarFactura
{
    public class RegistrarFacturaViewModelValidator : AbstractValidator<RegistrarFacturaViewModel>
    {
        public RegistrarFacturaViewModelValidator()
        {

            RuleFor(Modelo => Modelo.IdFactura)
               .NotEmpty()
               ;
            RuleFor(Modelo => Modelo.NuFactura)
.NotEmpty();
            RuleFor(Modelo => Modelo.NuEmpresa)
    .NotEmpty();
            RuleFor(Modelo => Modelo.TxRazonSocial)
    .NotEmpty();
            
            RuleFor(Modelo => Modelo.CoUserModif)
    .NotEmpty();
            RuleFor(Modelo => Modelo.FeVencimiento)
            .NotEmpty()
            .Must(ValidaFechaEmisionMenorIgualFechaVencim)
            .WithMessage("Fecha de Emision debe ser menor o igual que la Fecha de Vencimiento.");

            RuleFor(Modelo => Modelo.FeCobro)
            .NotEmpty()
            .Must(ValidaFechaVencimMenorIgualFechaCobro)
            .WithMessage("Fecha de Vencimiento debe ser menor o igual que la Fecha de Cobro.");

            RuleFor(Modelo => Modelo.NuRuc)
                .NotEmpty()
                .Length(11, 11)
                .WithMessage("El RUC debe ser de 11 caracteres.");

            RuleFor(Modelo => Modelo.NuRuc)
                .Must(ValidaRUCIniciaen2)
                .WithMessage("El RUC debe iniciar con el número 2.");

            RuleFor(Modelo => Modelo.SsTotFactura)
                .Must(ValidaTotalMayorCero)
                .WithMessage("El Total más impuestos debe ser mayor que cero.");

            RuleFor(Modelo => Modelo.SsTotImpuestos)
               .Must(ValidaIgv)
               .WithMessage("El Total de Impuestos debe ser igual al 18% del Total.");
        }

        private bool ValidaFechaEmisionMenorIgualFechaVencim(RegistrarFacturaViewModel modelo, DateTime vdatFeVencim)
        {
            DateTime datFechaEmision = modelo.FeEmision;
            return (vdatFeVencim >= datFechaEmision);
        }
        private bool ValidaFechaVencimMenorIgualFechaCobro(RegistrarFacturaViewModel modelo, DateTime vdatFeCobro)
        {
            DateTime datFechaVencim = modelo.FeVencimiento;
            return (vdatFeCobro >= datFechaVencim);
        }
        private bool ValidaRUCIniciaen2(RegistrarFacturaViewModel modelo, string vstrNuRUC)
        {
            if ( vstrNuRUC == null)
                return false;
            return (modelo.NuRuc.Substring(0, 1) == "2");
        }

        private bool ValidaTotalMayorCero(RegistrarFacturaViewModel modelo, Decimal vdecTotal)
        {
            decimal decSuma = modelo.SsTotImpuestos + vdecTotal;
            return (decSuma > 0);
        }

        private bool ValidaIgv(RegistrarFacturaViewModel modelo, Decimal vdecIgv)
        {
            return ((decimal)(modelo.SsTotFactura * 0.18m) == vdecIgv);
        }
    }
}