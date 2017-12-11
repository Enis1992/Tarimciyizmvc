namespace tarimciyiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adres
    {
        public int adresID { get; set; }

        public Guid? musteriID { get; set; }

        [StringLength(50)]
        public string adresAdi { get; set; }

        [StringLength(500)]
        public string adresAlani { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
