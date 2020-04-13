namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hanghoa")]
    public partial class Hanghoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hanghoa()
        {
            Chitietnhaps = new HashSet<Chitietnhap>();
            Chitietxuats = new HashSet<Chitietxuat>();
        }

        [Key]
        [StringLength(20)]
        public string Mahanghoa { get; set; }

        [Required]
        [StringLength(50)]
        public string Tenhanghoa { get; set; }

        public decimal Dongia { get; set; }

        [Required]
        [StringLength(15)]
        public string Donvitinh { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietnhap> Chitietnhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietxuat> Chitietxuats { get; set; }

        public virtual NhaCC NhaCC { get; set; }

        public virtual NhapXuatTon NhapXuatTon { get; set; }
    }
}
