namespace tarimciyiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kargo")]
    public partial class Kargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kargo()
        {
            Siparis = new HashSet<Siparis>();
        }

        public int kargoID { get; set; }
        [Required]
        [Display(Name ="Firma")]
        [StringLength(50)]
        public string kargoAdi { get; set; }
        [Required]
        [Display(Name = "Adres")]
        [StringLength(50)]
        public string kargoAdresi { get; set; }
        [Required]
        [Display(Name = "Telofon")]
        [StringLength(50)]
        public string kargoTelefon { get; set; }
       
        [Display(Name = "Web")]
        [StringLength(50)]

        public string kargoWeb { get; set; }
        [Required]
        [Display(Name = "E-Mail")]
        [StringLength(50)]
        public string kargoEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
