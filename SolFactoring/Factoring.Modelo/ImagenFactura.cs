namespace Factoring.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("ImagenFactura")]
    public partial class ImagenFactura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFactura { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] ImFactura { get; set; }

        [Required]
        [StringLength(50)]
        public string CoUserModif { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FeModif { get; set; }

        public virtual Factura Factura { get; set; }
    }
}
