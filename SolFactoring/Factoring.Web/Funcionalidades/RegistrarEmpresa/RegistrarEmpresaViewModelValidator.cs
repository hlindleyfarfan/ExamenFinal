
using FluentValidation;

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

            RuleFor(Modelo => Modelo.TxRazonSocial)
                .NotEmpty()
                ;
        }

        private bool ValidaRUCIniciaen2(RegistrarEmpresaViewModel modelo, string vstrNuRUC)
        {
            return (modelo.NuRuc.Substring(0,1)=="2");
        }
    }
}