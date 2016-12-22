using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.RegistrarFactura
{
    public class RegistrarFacturaViewModel
    {
        public int IdFactura { get; set; }

        [Display(Name = "Número")]
        public string NuFactura { get; set; }

        [Display(Name = "Fec. Emisión")]
        public DateTime FeEmision { get; set; }


        public DateTime FeVencimiento { get; set; }


        public DateTime FeCobro { get; set; }

        public int NuEmpresa { get; set; }

        [Required]
        [StringLength(11)]
        public string NuRuc { get; set; }

        [Display(Name = "Raz. Social")]
        public string TxRazonSocial { get; set; }

        [Display(Name = "Total")]
        public decimal SsTotFactura { get; set; }

        [Display(Name = "IGV")]
        public decimal SsTotImpuestos { get; set; }

        [Required]
        [StringLength(50)]
        public string CoUserModif { get; set; }

        public DateTime FeModif { get; set; }
    }
}