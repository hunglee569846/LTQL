namespace websiteBANHANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Chitietnhap",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        Maphieunhap = c.String(nullable: false, maxLength: 20, unicode: false),
                        Mahanghoa = c.String(nullable: false, maxLength: 20, unicode: false),
                        Soluong = c.Int(nullable: false),
                        Ngaynhap = c.DateTime(nullable: false, storeType: "date"),
                        MaNCC = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.STT)
                .ForeignKey("dbo.Hanghoa", t => t.Mahanghoa)
                .ForeignKey("dbo.Phieunhap", t => t.Maphieunhap)
                .Index(t => t.Maphieunhap)
                .Index(t => t.Mahanghoa);
            
            CreateTable(
                "dbo.Hanghoa",
                c => new
                    {
                        Mahanghoa = c.String(nullable: false, maxLength: 20, unicode: false),
                        Tenhanghoa = c.String(nullable: false, maxLength: 50),
                        Dongia = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Donvitinh = c.String(nullable: false, maxLength: 15),
                        MaNCC = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Mahanghoa)
                .ForeignKey("dbo.NhaCC", t => t.MaNCC)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.Chitietxuat",
                c => new
                    {
                        STT = c.Int(nullable: false, identity: true),
                        Maphieuxuat = c.String(nullable: false, maxLength: 20, unicode: false),
                        Mahanghoa = c.String(nullable: false, maxLength: 20, unicode: false),
                        soluong = c.Int(nullable: false),
                        Ngayxuat = c.DateTime(nullable: false, storeType: "date"),
                        Makhachhang = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.STT)
                .ForeignKey("dbo.Phieuxuat", t => t.Maphieuxuat)
                .ForeignKey("dbo.Hanghoa", t => t.Mahanghoa)
                .Index(t => t.Maphieuxuat)
                .Index(t => t.Mahanghoa);
            
            CreateTable(
                "dbo.Phieuxuat",
                c => new
                    {
                        Maphieuxuat = c.String(nullable: false, maxLength: 20, unicode: false),
                        Ngaytao = c.DateTime(nullable: false, storeType: "date"),
                        Makhachhang = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Maphieuxuat)
                .ForeignKey("dbo.Khachhang", t => t.Makhachhang)
                .Index(t => t.Makhachhang);
            
            CreateTable(
                "dbo.Khachhang",
                c => new
                    {
                        Makhachhang = c.String(nullable: false, maxLength: 20, unicode: false),
                        Tenkhachhang = c.String(nullable: false, maxLength: 50),
                        Sodienthoai = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.Makhachhang);
            
            CreateTable(
                "dbo.Hoadon",
                c => new
                    {
                        Mahoadon = c.String(nullable: false, maxLength: 20, unicode: false),
                        Ngaytao = c.DateTime(nullable: false, storeType: "date"),
                        Makhachhang = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Mahoadon)
                .ForeignKey("dbo.Khachhang", t => t.Makhachhang)
                .Index(t => t.Makhachhang);
            
            CreateTable(
                "dbo.NhaCC",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenNCC = c.String(nullable: false, maxLength: 50),
                        Sodienthoai = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.Phieunhap",
                c => new
                    {
                        Maphieunhap = c.String(nullable: false, maxLength: 20, unicode: false),
                        Ngaytao = c.DateTime(nullable: false, storeType: "date"),
                        MaNCC = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Maphieunhap)
                .ForeignKey("dbo.NhaCC", t => t.MaNCC)
                .Index(t => t.MaNCC);
            
            CreateTable(
                "dbo.NhapXuatTon",
                c => new
                    {
                        Mahanghoa = c.String(nullable: false, maxLength: 20, unicode: false),
                        STT = c.Int(nullable: false, identity: true),
                        SoNhap = c.Int(nullable: false),
                        SoXuat = c.Int(nullable: false),
                        SoTon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Mahanghoa)
                .ForeignKey("dbo.Hanghoa", t => t.Mahanghoa)
                .Index(t => t.Mahanghoa);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhapXuatTon", "Mahanghoa", "dbo.Hanghoa");
            DropForeignKey("dbo.Phieunhap", "MaNCC", "dbo.NhaCC");
            DropForeignKey("dbo.Chitietnhap", "Maphieunhap", "dbo.Phieunhap");
            DropForeignKey("dbo.Hanghoa", "MaNCC", "dbo.NhaCC");
            DropForeignKey("dbo.Chitietxuat", "Mahanghoa", "dbo.Hanghoa");
            DropForeignKey("dbo.Phieuxuat", "Makhachhang", "dbo.Khachhang");
            DropForeignKey("dbo.Hoadon", "Makhachhang", "dbo.Khachhang");
            DropForeignKey("dbo.Chitietxuat", "Maphieuxuat", "dbo.Phieuxuat");
            DropForeignKey("dbo.Chitietnhap", "Mahanghoa", "dbo.Hanghoa");
            DropIndex("dbo.NhapXuatTon", new[] { "Mahanghoa" });
            DropIndex("dbo.Phieunhap", new[] { "MaNCC" });
            DropIndex("dbo.Hoadon", new[] { "Makhachhang" });
            DropIndex("dbo.Phieuxuat", new[] { "Makhachhang" });
            DropIndex("dbo.Chitietxuat", new[] { "Mahanghoa" });
            DropIndex("dbo.Chitietxuat", new[] { "Maphieuxuat" });
            DropIndex("dbo.Hanghoa", new[] { "MaNCC" });
            DropIndex("dbo.Chitietnhap", new[] { "Mahanghoa" });
            DropIndex("dbo.Chitietnhap", new[] { "Maphieunhap" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.NhapXuatTon");
            DropTable("dbo.Phieunhap");
            DropTable("dbo.NhaCC");
            DropTable("dbo.Hoadon");
            DropTable("dbo.Khachhang");
            DropTable("dbo.Phieuxuat");
            DropTable("dbo.Chitietxuat");
            DropTable("dbo.Hanghoa");
            DropTable("dbo.Chitietnhap");
            DropTable("dbo.Accounts");
        }
    }
}
