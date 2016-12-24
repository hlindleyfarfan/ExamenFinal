
using Factoring.Web.Funcionalidades.ListarEmpresa;
using FluentValidation;
using System.Collections.Generic;

namespace Factoring.Web.Funcionalidades.RegistrarEmpresa
{
    public class RegistrarEmpresaViewModelValidator : AbstractValidator<RegistrarEmpresaViewModel>
    {
        public RegistrarEmpresaViewModelValidator()
        {

            RuleFor(Modelo => Modelo.NuEmpresa)
                .NotEmpty();
            RuleFor(Modelo => Modelo.NoDepartamento)
    .NotEmpty();
            RuleFor(Modelo => Modelo.NoProvincia)
    .NotEmpty();
            RuleFor(Modelo => Modelo.NoDistrito)
    .NotEmpty();
            RuleFor(Modelo => Modelo.CoUser)
    .NotEmpty();
            RuleFor(Modelo => Modelo.CoUserModif)
    .NotEmpty();


            RuleFor(Modelo => Modelo.NuRuc)
                .NotEmpty()
                .Length(11, 11)
                .WithMessage("El RUC debe ser de 11 caracteres.");

            RuleFor(Modelo => Modelo.NuRuc)
                .Must(ValidaRUCIniciaen2)
                .WithMessage("El RUC debe iniciar con el número 2.");

            RuleFor(Modelo => Modelo.NuRuc)
                .Must(ValidaNoDuplicados)
                .WithMessage("Ya existe el RUC ingresado.");

            //RuleFor(Modelo => Modelo.NuRuc)
            //    .Must(ValidaModulo11)
            //    .WithMessage("RUC invalidado por Módulo 11.");

            RuleFor(Modelo => Modelo.TxRazonSocial)
                .NotEmpty()
                ;
        }

        private bool ValidaRUCIniciaen2(RegistrarEmpresaViewModel modelo, string vstrNuRUC)
        {
            return (modelo.NuRuc.Substring(0,1)=="2");
        }

        private bool ValidaNoDuplicados(RegistrarEmpresaViewModel modelo, string vstrNuRUC)
        {
            ListarEmpresaHandler obj = new ListarEmpresaHandler();
            return obj.NoExisteRUC(vstrNuRUC);
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