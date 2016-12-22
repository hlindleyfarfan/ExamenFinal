using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.RegistrarEmpresa
{
    [Validator(typeof(RegistrarEmpresaViewModelValidator))]
    public class RegistrarEmpresaViewModel
    {
        [Display(Name = "Id")]
        public int NuEmpresa { get; set; }

        [Display(Name = "RUC")]
        public string NuRuc { get; set; }

        [Display(Name = "Raz. Social")]
        public string TxRazonSocial { get; set; }

        [Display(Name = "Dirección")]
        public string TxDireccion { get; set; }

        [Display(Name = "Departamento")]
        public string NoDepartamento { get; set; }

        [Display(Name = "Provincia")]
        public string NoProvincia { get; set; }

        [Display(Name = "Distrito")]
        public string NoDistrito { get; set; }

        [Display(Name = "Rubro")]
        public string TxRubro { get; set; }

        [Display(Name = "Usuario")]
        public string CoUser { get; set; }

        [Display(Name = "Usuario Modif.")]
        public string CoUserModif { get; set; }

        [Display(Name = "Fec. Modif.")]
        public DateTime FeModif { get; set; }
    }
}