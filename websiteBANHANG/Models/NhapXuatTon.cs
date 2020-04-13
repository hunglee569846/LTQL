namespace websiteBANHANG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapXuatTon")]
    public partial class NhapXuatTon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }

        [Key]
        [StringLength(20)]
        public string Mahanghoa { get; set; }

        public int SoNhap { get; set; }

        public int SoXuat { get; set; }

        public int SoTon { get; set; }

        public virtual Hanghoa Hanghoa { get; set; }
    }
}
