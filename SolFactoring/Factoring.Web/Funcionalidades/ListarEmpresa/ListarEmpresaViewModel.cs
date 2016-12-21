using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarEmpresa
{
    public class ListarEmpresaViewModel
    {
        public int NuEmpresa { get; set; }

        [Required]
        [StringLength(11)]
        public string NuRuc { get; set; }

        [Required]
        [StringLength(150)]
        public string TxRazonSocial { get; set; }

        [StringLength(200)]
        public string TxDireccion { get; set; }

        [Required]
        [StringLength(150)]
        public string NoDepartamento { get; set; }

        [Required]
        [StringLength(150)]
        public string NoProvincia { get; set; }

        [Required]
        [StringLength(150)]
        public string NoDistrito { get; set; }

        [StringLength(200)]
        public string TxRubro { get; set; }

        [Required]
        [StringLength(50)]
        public string CoUser { get; set; }
    }
}