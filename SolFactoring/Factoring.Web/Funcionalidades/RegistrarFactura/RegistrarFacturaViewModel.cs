using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.RegistrarFactura
{
    [Validator(typeof(RegistrarFacturaViewModelValidator))]
    public class RegistrarFacturaViewModel
    {
        [Display(Name = "Id")]
        public int IdFactura { get; set; }

        [Display(Name = "Número")]
        public string NuFactura { get; set; }

        [Display(Name = "Fec. Emisión")]
        public DateTime FeEmision { get; set; }

        [Display(Name = "Fec. Vencim.")]
        public DateTime FeVencimiento { get; set; }

        [Display(Name = "Fec. Cobro")]
        public DateTime FeCobro { get; set; }

        [Display(Name = "Id Empresa")]
        public int NuEmpresa { get; set; }

        //[Required]
        //[StringLength(11)]
        [Display(Name = "RUC")]
        public string NuRuc { get; set; }

        [Display(Name = "Raz. Social")]
        public string TxRazonSocial { get; set; }

        [Display(Name = "Total")]
        public decimal SsTotFactura { get; set; }

        [Display(Name = "IGV")]
        public decimal SsTotImpuestos { get; set; }

        //[Required]
        //[StringLength(50)]
        [Display(Name = "Usuario Modif.")]
        public string CoUserModif { get; set; }
        [Display(Name = "Fec. Modif.")]
        public DateTime FeModif { get; set; }
    }
}