namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieuxuat")]
    public partial class Phieuxuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phieuxuat()
        {
            Chitietxuats = new HashSet<Chitietxuat>();
        }

        [Key]
        [StringLength(20)]
        public string Maphieuxuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaytao { get; set; }

        [Required]
        [StringLength(20)]
        public string Makhachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietxuat> Chitietxuats { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
