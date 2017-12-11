namespace tarimciyiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiparisDetay")]
    public partial class SiparisDetay
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int siparisID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int urunID { get; set; }

        public int? adet { get; set; }

        [Column(TypeName = "money")]
        public decimal? fiyat { get; set; }

        public virtual Siparis Siparis { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
