namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietxuat")]
    public partial class Chitietxuat
    {
        [Key]
        public int STT { get; set; }

        [Required]
        [StringLength(20)]
        public string Maphieuxuat { get; set; }

        [Required]
        [StringLength(20)]
        public string Mahanghoa { get; set; }

        public int soluong { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngayxuat { get; set; }

        [Required]
        [StringLength(20)]
        public string Makhachhang { get; set; }

        public virtual Hanghoa Hanghoa { get; set; }

        public virtual Phieuxuat Phieuxuat { get; set; }
    }
}
