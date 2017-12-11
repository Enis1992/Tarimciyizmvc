namespace tarimciyiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Siparis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparis()
        {
            SiparisDetay = new HashSet<SiparisDetay>();
        }

        public int siparisID { get; set; }

        public Guid? musteriID { get; set; }

        public DateTime? siparisTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal? toplamTutar { get; set; }

        public bool? sepettemi { get; set; }

        public int? siparisDurumID { get; set; }

        public int? kargoID { get; set; }

        [StringLength(50)]
        public string kargoTakipNo { get; set; }

        public virtual Kargo Kargo { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual SiparisDurum SiparisDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetay { get; set; }
    }
}
