namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieunhap")]
    public partial class Phieunhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieunhap()
        {
            Chitietnhaps = new HashSet<Chitietnhap>();
        }

        [Key]
        [StringLength(20)]
        public string Maphieunhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaytao { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietnhap> Chitietnhaps { get; set; }

        public virtual NhaCC NhaCC { get; set; }
    }
}
