namespace Factoring.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        [Required]
        [StringLength(10)]
        public string NuFactura { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FeEmision { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FeVencimiento { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FeCobro { get; set; }

        public int NuEmpresa { get; set; }

        [Required]
        [StringLength(11)]
        public string NuRuc { get; set; }

        [Required]
        [StringLength(150)]
        public string TxRazonSocial { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SsTotFactura { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SsTotImpuestos { get; set; }

        [Required]
        [StringLength(50)]
        public string CoUserModif { get; set; }

        public DateTime FeModif { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ImagenFactura ImagenFactura { get; set; }
    }
}
