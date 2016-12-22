using Factoring.Web.Funcionalidades.ListarFactura;
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

            RuleFor(Modelo => Modelo.NuRuc)
                .Must(ValidaModulo11)
                .WithMessage("RUC invalidado por Módulo 11.");

            RuleFor(Modelo => Modelo.NuFactura)
                .Must(ValidaNoDuplicados)
                .WithMessage("Ya existe el Nro. de Factura ingresado.");

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

        private bool ValidaNoDuplicados(RegistrarFacturaViewModel modelo, string vstrNuFactura)
        {
            ListarFacturaHandler obj = new ListarFacturaHandler();
            return obj.NoExisteFacturaxEmpresa(vstrNuFactura, modelo.NuEmpresa);
        }

        public bool ValidaModulo11(string vstrNuRuc)
        {
            if (!string.IsNullOrEmpty(vstrNuRuc))
            {
                int addition = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int vstrNuRucLength = vstrNuRuc.Length;

                string identificationComponent = vstrNuRuc.Substring(0, vstrNuRucLength - 1);

                int identificationComponentLength = identificationComponent.Length;

                int diff = hash.Length - identificationComponentLength;

                for (int i = identificationComponentLength - 1; i >= 0; i--)
                {
                    addition += (identificationComponent[i] - '0') * hash[i + diff];
                }

                addition = 11 - (addition % 11);

                if (addition == 11)
                {
                    addition = 0;
                }

                char last = char.ToUpperInvariant(vstrNuRuc[vstrNuRucLength - 1]);

                if (vstrNuRucLength == 11)
                {
                    // The identification document corresponds to a RUC.
                    return addition.Equals(last - '0');
                }
                else if (char.IsDigit(last))
                {
                    // The identification document corresponds to a DNI with a number as verification digit.
                    char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                    return last.Equals(hashNumbers[addition]);
                }
                else if (char.IsLetter(last))
                {
                    // The identification document corresponds to a DNI with a letter as verification digit.
                    char[] hashLetters = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                    return last.Equals(hashLetters[addition]);
                }
            }

            return false;
        }
    }
}