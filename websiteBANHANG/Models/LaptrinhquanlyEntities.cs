namespace websiteBANHANG.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LaptrinhquanlyEntities : DbContext
    {
        public LaptrinhquanlyEntities()
            : base("name=LaptrinhquanlyEtity")
        {
        }

        public virtual DbSet<Chitietnhap> Chitietnhaps { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Chitietxuat> Chitietxuats { get; set; }
        public virtual DbSet<Hanghoa> Hanghoas { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<NhaCC> NhaCCs { get; set; }
        public virtual DbSet<NhapXuatTon> NhapXuatTons { get; set; }
        public virtual DbSet<Phieunhap> Phieunhaps { get; set; }
        public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietnhap>()
                .Property(e => e.Maphieunhap)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietnhap>()
                .Property(e => e.Mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietnhap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietxuat>()
                .Property(e => e.Maphieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietxuat>()
                .Property(e => e.Mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<Chitietxuat>()
                .Property(e => e.Makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<Hanghoa>()
                .Property(e => e.Mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<Hanghoa>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hanghoa>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<Hanghoa>()
                .HasMany(e => e.Chitietnhaps)
                .WithRequired(e => e.Hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hanghoa>()
                .HasMany(e => e.Chitietxuats)
                .WithRequired(e => e.Hanghoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hanghoa>()
                .HasOptional(e => e.NhapXuatTon)
                .WithRequired(e => e.Hanghoa);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.Mahoadon)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.Makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.Makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.Sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .HasMany(e => e.Hoadons)
                .WithRequired(e => e.Khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khachhang>()
                .HasMany(e => e.Phieuxuats)
                .WithRequired(e => e.Khachhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCC>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCC>()
                .Property(e => e.Sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCC>()
                .HasMany(e => e.Hanghoas)
                .WithRequired(e => e.NhaCC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCC>()
                .HasMany(e => e.Phieunhaps)
                .WithRequired(e => e.NhaCC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhapXuatTon>()
                .Property(e => e.Mahanghoa)
                .IsUnicode(false);

            modelBuilder.Entity<Phieunhap>()
                .Property(e => e.Maphieunhap)
                .IsUnicode(false);

            modelBuilder.Entity<Phieunhap>()
                .Property(e => e.MaNCC)
                .IsUnicode(false);

            modelBuilder.Entity<Phieunhap>()
                .HasMany(e => e.Chitietnhaps)
                .WithRequired(e => e.Phieunhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Maphieuxuat)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuat>()
                .Property(e => e.Makhachhang)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
               .Property(e => e.Password)
               .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ArticleID)
                .IsUnicode(false);

            modelBuilder.Entity<Phieuxuat>()
                .HasMany(e => e.Chitietxuats)
                .WithRequired(e => e.Phieuxuat)
                .WillCascadeOnDelete(false);
        }
    }
}
