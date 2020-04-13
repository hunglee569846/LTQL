namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietnhap")]
    public partial class Chitietnhap
    {
        [Key]
        public int STT { get; set; }

        [Required]
        [StringLength(20)]
        public string Maphieunhap { get; set; }

        [Required]
        [StringLength(20)]
        public string Mahanghoa { get; set; }

        public int Soluong { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //định dạng lại thoi gian chỉ có ngày
        public DateTime Ngaynhap { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNCC { get; set; }

        public virtual Hanghoa Hanghoa { get; set; }

        public virtual Phieunhap Phieunhap { get; set; }
    }
}
