using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoleDatas.DBModels;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BdSnapping> BdSnappings { get; set; }

    public virtual DbSet<DmLoaithietbi> DmLoaithietbis { get; set; }

    public virtual DbSet<NvDuongday> NvDuongdays { get; set; }

    public virtual DbSet<NvFiledinhkem> NvFiledinhkems { get; set; }

    public virtual DbSet<NvMaybienap> NvMaybienaps { get; set; }

    public virtual DbSet<NvRole> NvRoles { get; set; }

    public virtual DbSet<NvText> NvTexts { get; set; }

    public virtual DbSet<NvThanhcai> NvThanhcais { get; set; }

    public virtual DbSet<NvThietbithuocdd> NvThietbithuocdds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=sodo1soi;Password=12345;Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.1.1.21)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = FTILIS) ));");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SODO1SOI");

        modelBuilder.Entity<BdSnapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BD_SNAPPING");

            entity.Property(e => e.Geometry)
                .HasColumnType("CLOB")
                .HasColumnName("GEOMETRY");
            entity.Property(e => e.Loaidoituong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOAIDOITUONG");
            entity.Property(e => e.Mapmis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAPMIS");
            entity.Property(e => e.Sttdiem)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STTDIEM");
        });

        modelBuilder.Entity<DmLoaithietbi>(entity =>
        {
            entity.HasKey(e => e.Maloaithietbi);

            entity.ToTable("DM_LOAITHIETBI");

            entity.Property(e => e.Maloaithietbi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MALOAITHIETBI");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Stt)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STT");
            entity.Property(e => e.Tenloaithietbi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENLOAITHIETBI");
        });

        modelBuilder.Entity<NvDuongday>(entity =>
        {
            entity.HasKey(e => e.Mapmis);

            entity.ToTable("NV_DUONGDAY");

            entity.Property(e => e.Mapmis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAPMIS");
            entity.Property(e => e.Capda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAPDA");
            entity.Property(e => e.Cottenhienthi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COTTENHIENTHI");
            entity.Property(e => e.Dahienthitrensd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DAHIENTHITRENSD");
            entity.Property(e => e.Daunoicuoi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DAUNOICUOI");
            entity.Property(e => e.Daunoidau)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DAUNOIDAU");
            entity.Property(e => e.Dentram)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DENTRAM");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Hienthiten)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HIENTHITEN");
            entity.Property(e => e.Hoatdong)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HOATDONG");
            entity.Property(e => e.Jsongeo)
                .HasColumnType("CLOB")
                .HasColumnName("JSONGEO");
            entity.Property(e => e.Mach)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MACH");
            entity.Property(e => e.Madvql)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MADVQL");
            entity.Property(e => e.Maucat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUCAT");
            entity.Property(e => e.Maudong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUDONG");
            entity.Property(e => e.Ngaylapdat)
                .HasColumnType("DATE")
                .HasColumnName("NGAYLAPDAT");
            entity.Property(e => e.Ngayvh)
                .HasColumnType("DATE")
                .HasColumnName("NGAYVH");
            entity.Property(e => e.Sododanhso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SODODANHSO");
            entity.Property(e => e.Sohieu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEU");
            entity.Property(e => e.Sohieubanve)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEUBANVE");
            entity.Property(e => e.Sohuu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHUU");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENCONGTY");
            entity.Property(e => e.Tendentram)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENDENTRAM");
            entity.Property(e => e.Tenduongday)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENDUONGDAY");
            entity.Property(e => e.Tentutram)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENTUTRAM");
            entity.Property(e => e.Truyentaidien)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TRUYENTAIDIEN");
            entity.Property(e => e.Tthientai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TTHIENTAI");
            entity.Property(e => e.Tutram)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TUTRAM");
            entity.Property(e => e.Idmap)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IDMAP");
        });

        modelBuilder.Entity<NvFiledinhkem>(entity =>
        {
            entity.HasKey(e => new { e.Maloaithietbi, e.Madt });

            entity.ToTable("NV_FILEDINHKEM");

            entity.Property(e => e.Maloaithietbi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MALOAITHIETBI");
            entity.Property(e => e.Madt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MADT");
            entity.Property(e => e.Duongdan)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DUONGDAN");
            entity.Property(e => e.Tenfile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENFILE");

            entity.HasOne(d => d.MaloaithietbiNavigation).WithMany(p => p.NvFiledinhkems)
                .HasForeignKey(d => d.Maloaithietbi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DM_LOAITHIETBI_NV_FILEDINHKEM");
        });

        modelBuilder.Entity<NvMaybienap>(entity =>
        {
            entity.HasKey(e => e.Mapmis);

            entity.ToTable("NV_MAYBIENAP");

            entity.Property(e => e.Mapmis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAPMIS");
            entity.Property(e => e.Cottenhienthi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COTTENHIENTHI");
            entity.Property(e => e.Dahienthitrensd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DAHIENTHITRENSD");
            entity.Property(e => e.Daunoi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DAUNOI");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Hangsx)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("HANGSX");
            entity.Property(e => e.Hienthiten)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HIENTHITEN");
            entity.Property(e => e.Hoatdong)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HOATDONG");
            entity.Property(e => e.Jsongeo)
                .HasColumnType("CLOB")
                .HasColumnName("JSONGEO");
            entity.Property(e => e.Mach)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MACH");
            entity.Property(e => e.Madvql)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MADVQL");
            entity.Property(e => e.Maucat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUCAT");
            entity.Property(e => e.Maudong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUDONG");
            entity.Property(e => e.Ngaylapdat)
                .HasColumnType("DATE")
                .HasColumnName("NGAYLAPDAT");
            entity.Property(e => e.Ngayvh)
                .HasColumnType("DATE")
                .HasColumnName("NGAYVH");
            entity.Property(e => e.Sododanhso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SODODANHSO");
            entity.Property(e => e.Sohieu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEU");
            entity.Property(e => e.Sohieubanve)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEUBANVE");
            entity.Property(e => e.Sohuu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHUU");
            entity.Property(e => e.Soserial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOSERIAL");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENCONGTY");
            entity.Property(e => e.Tenmba)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENMBA");
            entity.Property(e => e.Tentram)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENTRAM");
            entity.Property(e => e.Thuoctram)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("THUOCTRAM");
            entity.Property(e => e.Truyentaidien)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TRUYENTAIDIEN");
            entity.Property(e => e.Tthientai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TTHIENTAI");
        });

        modelBuilder.Entity<NvRole>(entity =>
        {
            entity.HasKey(e => e.Mapmis);

            entity.ToTable("NV_ROLE");

            entity.Property(e => e.Mapmis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAPMIS");
            entity.Property(e => e.Cottenhienthi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COTTENHIENTHI");
            entity.Property(e => e.Dahienthitrensd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DAHIENTHITRENSD");
            entity.Property(e => e.Daunoicuoi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DAUNOICUOI");
            entity.Property(e => e.Daunoidau)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DAUNOIDAU");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Hangsx)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("HANGSX");
            entity.Property(e => e.Hienthiten)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HIENTHITEN");
            entity.Property(e => e.Hoatdong)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HOATDONG");
            entity.Property(e => e.Jsongeo)
                .HasColumnType("CLOB")
                .HasColumnName("JSONGEO");
            entity.Property(e => e.Mach)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MACH");
            entity.Property(e => e.Madvql)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MADVQL");
            entity.Property(e => e.Maucat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUCAT");
            entity.Property(e => e.Maudong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUDONG");
            entity.Property(e => e.Ngaylapdat)
                .HasColumnType("DATE")
                .HasColumnName("NGAYLAPDAT");
            entity.Property(e => e.Ngayvh)
                .HasColumnType("DATE")
                .HasColumnName("NGAYVH");
            entity.Property(e => e.Sododanhso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SODODANHSO");
            entity.Property(e => e.Sohieu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEU");
            entity.Property(e => e.Sohieubanve)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEUBANVE");
            entity.Property(e => e.Sohuu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHUU");
            entity.Property(e => e.Soserial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOSERIAL");
            entity.Property(e => e.Tbbaove)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TBBAOVE");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENCONGTY");
            entity.Property(e => e.Tenrole)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENROLE");
            entity.Property(e => e.Tentram)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENTRAM");
            entity.Property(e => e.Thuoctram)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("THUOCTRAM");
            entity.Property(e => e.Truyentaidien)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TRUYENTAIDIEN");
            entity.Property(e => e.Tthientai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TTHIENTAI");
            entity.Property(e => e.Tubv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TUBV");
        });

        modelBuilder.Entity<NvText>(entity =>
        {
            entity.HasKey(e => e.Ma);

            entity.ToTable("NV_TEXT");

            entity.Property(e => e.Ma)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MA");
            entity.Property(e => e.Jsongeo)
                .HasColumnType("CLOB")
                .HasColumnName("JSONGEO");
            entity.Property(e => e.Madvql)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MADVQL");
            entity.Property(e => e.Sohieubanve)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEUBANVE");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENCONGTY");
            entity.Property(e => e.Texthienthi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TEXTHIENTHI");
            entity.Property(e => e.Truyentaidien)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TRUYENTAIDIEN");
        });

        modelBuilder.Entity<NvThanhcai>(entity =>
        {
            entity.HasKey(e => e.Mapmis);

            entity.ToTable("NV_THANHCAI");

            entity.Property(e => e.Mapmis)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAPMIS");
            entity.Property(e => e.Capda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CAPDA");
            entity.Property(e => e.Cottenhienthi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COTTENHIENTHI");
            entity.Property(e => e.Dahienthitrensd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DAHIENTHITRENSD");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Hienthiten)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HIENTHITEN");
            entity.Property(e => e.Hoatdong)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HOATDONG");
            entity.Property(e => e.Jsongeo)
                .HasColumnType("CLOB")
                .HasColumnName("JSONGEO");
            entity.Property(e => e.Madvql)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MADVQL");
            entity.Property(e => e.Maucat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUCAT");
            entity.Property(e => e.Maudong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MAUDONG");
            entity.Property(e => e.Ngaylapdat)
                .HasColumnType("DATE")
                .HasColumnName("NGAYLAPDAT");
            entity.Property(e => e.Ngayvh)
                .HasColumnType("DATE")
                .HasColumnName("NGAYVH");
            entity.Property(e => e.Sododanhso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SODODANHSO");
            entity.Property(e => e.Sohieu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEU");
            entity.Property(e => e.Sohieubanve)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHIEUBANVE");
            entity.Property(e => e.Sohuu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOHUU");
            entity.Property(e => e.Tencongty)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENCONGTY");
            entity.Property(e => e.Tenthanhcai)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TENTHANHCAI");
            entity.Property(e => e.Tentram)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TENTRAM");
            entity.Property(e => e.Thuoctram)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("THUOCTRAM");
            entity.Property(e => e.Truyentaidien)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TRUYENTAIDIEN");
            entity.Property(e => e.Tthientai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TTHIENTAI");
        });

        modelBuilder.Entity<NvThietbithuocdd>(entity =>
        {
            entity.HasKey(e => new { e.Maduongday, e.Matbkhac });

            entity.ToTable("NV_THIETBITHUOCDD");

            entity.Property(e => e.Maduongday)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MADUONGDAY");
            entity.Property(e => e.Matbkhac)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MATBKHAC");
            entity.Property(e => e.Loaitbkhac)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOAITBKHAC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
