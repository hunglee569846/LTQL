namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadon")]
    public partial class Hoadon
    {
        [Key]
        [StringLength(20)]
        public string Mahoadon { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaytao { get; set; }

        [Required]
        [StringLength(20)]
        public string Makhachhang { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
