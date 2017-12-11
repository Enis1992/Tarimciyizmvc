namespace tarimciyiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int resimID { get; set; }

        public int? urunID { get; set; }

        [StringLength(250)]
        public string resimAdi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
