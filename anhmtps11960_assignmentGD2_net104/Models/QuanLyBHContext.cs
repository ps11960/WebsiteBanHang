using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace anhmtps11960_assignmentGD2_net104.Models
{
    public partial class QuanLyBHContext : DbContext
    {
        public QuanLyBHContext()
        {

        }

        public QuanLyBHContext(DbContextOptions<QuanLyBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BOSSMTA;Database=QuanLyBH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm);

                entity.Property(e => e.MaDm)
                    .HasColumnName("MaDM")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.LoaiDm)
                    .IsRequired()
                    .HasColumnName("LoaiDM")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDt)
                    .IsRequired()
                    .HasColumnName("SoDT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TenKhach)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.GiaSp)
                    .IsRequired()
                    .HasColumnName("GiaSP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hinhanh).HasMaxLength(100);

                entity.Property(e => e.LoaiSp)
                    .IsRequired()
                    .HasColumnName("LoaiSP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaDm)
                    .IsRequired()
                    .HasColumnName("MaDM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasColumnName("TenSP")
                    .HasMaxLength(50);

                entity.Property(e => e.ThongtinSp)
                    .HasColumnName("ThongtinSP")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_DM");
            });
        }
    }
}
