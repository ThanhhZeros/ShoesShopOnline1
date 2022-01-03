using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShoesShopOnline.Models
{
    public partial class Shoes : DbContext
    {
        public Shoes()
            : base("name=Shoes")
        {
        }

        public virtual DbSet<AnhMoTa> AnhMoTas { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSPs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoanNguoiDung> TaiKhoanNguoiDungs { get; set; }
        public virtual DbSet<TaiKhoanQuanTri> TaiKhoanQuanTris { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AnhMoTa>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietSanPham>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.ChiTietSanPham)
                .HasForeignKey(e => new { e.MaAnh, e.KichCo });

            modelBuilder.Entity<DanhMucSP>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SDTNguoiNhan)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.EmailNguoiNhan)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaDM)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.AnhMoTas)
                .WithOptional(e => e.SanPham)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TaiKhoanNguoiDung>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanNguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanNguoiDung>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.TaiKhoanNguoiDung)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TaiKhoanQuanTri>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanQuanTri>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoanQuanTri>()
                .HasMany(e => e.TinTucs)
                .WithOptional(e => e.TaiKhoanQuanTri)
                .WillCascadeOnDelete();
        }
    }
}
