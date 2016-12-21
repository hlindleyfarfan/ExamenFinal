namespace Factoring.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            Factura = new HashSet<Factura>();
        }

        [Key]
        public int NuEmpresa { get; set; }

        [Required]
        [StringLength(11)]
        public string NuRuc { get; set; }

        [Required]
        [StringLength(150)]
        public string TxRazonSocial { get; set; }

        [StringLength(200)]
        public string TxDireccion { get; set; }

        public int CoDistrito { get; set; }

        [StringLength(200)]
        public string TxRubro { get; set; }

        [Required]
        [StringLength(50)]
        public string CoUser { get; set; }

        [Required]
        [StringLength(50)]
        public string CoUserModif { get; set; }

        public DateTime FeModif { get; set; }

        public virtual Distrito Distrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
    }
}