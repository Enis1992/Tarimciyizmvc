namespace tarimciyiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Resim = new HashSet<Resim>();
            SiparisDetay = new HashSet<SiparisDetay>();
        }
      
        public int urunID { get; set; }
       
        [Display(Name = "Kategori")]
        public int? kategoriID { get; set; }
        
        [Display(Name = "Marka")]
        
        public int? markaID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        [StringLength(250)]
        public string urunAdi { get; set; }

        [Display(Name = "Aciklama")]
        [StringLength(1000)]
        public string urunAciklama { get; set; }

        [Display(Name = "Fiyat")]
        [Column(TypeName = "money")]
        public decimal? urunFiyat { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Marka Marka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}
