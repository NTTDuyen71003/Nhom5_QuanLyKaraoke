using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LTW_Karaoke.Model
{
    public partial class KaraokeDB : DbContext
    {
        public KaraokeDB()
            : base("name=KaraokeDB")
        {
        }

        public virtual DbSet<DANHMUC> DANHMUCs { get; set; }
        public virtual DbSet<HOADONBANHANG> HOADONBANHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<MATHANG> MATHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HOADONBANHANG>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONGs)
                .WithRequired(e => e.LOAIPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATHANG>()
                .HasMany(e => e.HOADONBANHANGs)
                .WithRequired(e => e.MATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONBANHANGs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.HOADONBANHANGs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);
        }
    }
}
