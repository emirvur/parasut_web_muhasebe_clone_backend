using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MuhasebeApi.Models
{
    public partial class MuhasebeContext : DbContext
    {
        public MuhasebeContext()
        {
        }

        public MuhasebeContext(DbContextOptions<MuhasebeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calisan> Calisan { get; set; }
        public virtual DbSet<Cari> Cari { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Irsaliye> Irsaliye { get; set; }
        public virtual DbSet<Kasa> Kasa { get; set; }
        public virtual DbSet<Kasahar> Kasahar { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Odehar> Odehar { get; set; }
        public virtual DbSet<Odemeler> Odemeler { get; set; }
        public virtual DbSet<Tahshar> Tahshar { get; set; }
        public virtual DbSet<Tahsilat> Tahsilat { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Urunhareket> Urunhareket { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calisan>(entity =>
            {
                entity.HasKey(e => e.Calid);

                entity.Property(e => e.Calid).HasColumnName("calid");

                entity.Property(e => e.Adsoyad)
                    .IsRequired()
                    .HasColumnName("adsoyad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eposta)
                    .HasColumnName("eposta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Iban)
                    .HasColumnName("iban")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Katid).HasColumnName("katid");

                entity.Property(e => e.Tck)
                    .HasColumnName("tck")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Telno)
                    .HasColumnName("telno")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kat)
                    .WithMany(p => p.Calisan)
                    .HasForeignKey(d => d.Katid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calisan_Kategori");
            });

            modelBuilder.Entity<Cari>(entity =>
            {
                entity.Property(e => e.CariId).HasColumnName("cari_id");

                entity.Property(e => e.Adres)
                    .HasColumnName("adres")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bakiye).HasColumnName("bakiye");

                entity.Property(e => e.Cariunvani)
                    .IsRequired()
                    .HasColumnName("cariunvani")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eposta)
                    .HasColumnName("eposta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Faks)
                    .HasColumnName("faks")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hangicari).HasColumnName("hangicari");

                entity.Property(e => e.Iban)
                    .HasColumnName("iban")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Katid).HasColumnName("katid");

                entity.Property(e => e.Kisaisim)
                    .HasColumnName("kisaisim")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tckn)
                    .HasColumnName("tckn")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Telno)
                    .HasColumnName("telno")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Turu).HasColumnName("turu");

                entity.HasOne(d => d.Kat)
                    .WithMany(p => p.Cari)
                    .HasForeignKey(d => d.Katid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cari_Kategori");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.HasKey(e => e.Fatid);

                entity.Property(e => e.Fatid).HasColumnName("fatid");

                entity.Property(e => e.Araind).HasColumnName("araind");

                entity.Property(e => e.Aratop).HasColumnName("aratop");

                entity.Property(e => e.CariId).HasColumnName("cari_id");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Duztarih)
                    .HasColumnName("duztarih")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.FatTur).HasColumnName("fat_tur");

                entity.Property(e => e.Fataciklama)
                    .HasColumnName("fataciklama")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geneltoplam).HasColumnName("geneltoplam");

                entity.Property(e => e.Katid).HasColumnName("katid");

                entity.Property(e => e.Kdv).HasColumnName("kdv");

                entity.Property(e => e.Odeid).HasColumnName("odeid");

                entity.Property(e => e.Tahsid).HasColumnName("tahsid");

                entity.HasOne(d => d.Cari)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.CariId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fatura_Cari");

                entity.HasOne(d => d.Kat)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.Katid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fatura_Kategori");

                entity.HasOne(d => d.Ode)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.Odeid)
                    .HasConstraintName("FK_Fatura_Odemeler");

                entity.HasOne(d => d.Tahs)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.Tahsid)
                    .HasConstraintName("FK_Fatura_Tahsilat");
            });

            modelBuilder.Entity<Irsaliye>(entity =>
            {
                entity.HasKey(e => e.Irsid);

                entity.ToTable("irsaliye");

                entity.Property(e => e.Irsid).HasColumnName("irsid");

                entity.Property(e => e.Aciklama)
                    .IsRequired()
                    .HasColumnName("aciklama")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Araind).HasColumnName("araind");

                entity.Property(e => e.Aratop).HasColumnName("aratop");

                entity.Property(e => e.CariId).HasColumnName("cariId");

                entity.Property(e => e.Fatmi).HasColumnName("fatmi");

                entity.Property(e => e.Geneltop).HasColumnName("geneltop");

                entity.Property(e => e.Kdv).HasColumnName("kdv");

                entity.Property(e => e.Tarih)
                    .HasColumnName("tarih")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Tur).HasColumnName("tur");

                entity.HasOne(d => d.Cari)
                    .WithMany(p => p.Irsaliye)
                    .HasForeignKey(d => d.CariId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_irsaliye_Cari");
            });

            modelBuilder.Entity<Kasa>(entity =>
            {
                entity.Property(e => e.Kasaid).HasColumnName("kasaid");

                entity.Property(e => e.Bakiye).HasColumnName("bakiye");

                entity.Property(e => e.KasaAd)
                    .IsRequired()
                    .HasColumnName("kasa_ad")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kasahar>(entity =>
            {
                entity.HasKey(e => e.Khid);

                entity.ToTable("kasahar");

                entity.Property(e => e.Khid).HasColumnName("khid");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Kasaid).HasColumnName("kasaid");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Miktaraciklamasi)
                    .HasColumnName("miktaraciklamasi")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Netbakiye).HasColumnName("netbakiye");

                entity.Property(e => e.Ohid).HasColumnName("ohid");

                entity.Property(e => e.Thid).HasColumnName("thid");

                entity.HasOne(d => d.Kasa)
                    .WithMany(p => p.Kasahar)
                    .HasForeignKey(d => d.Kasaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_kasahar_Kasa");

                entity.HasOne(d => d.Oh)
                    .WithMany(p => p.Kasahar)
                    .HasForeignKey(d => d.Ohid)
                    .HasConstraintName("FK_kasahar_odehar");

                entity.HasOne(d => d.Th)
                    .WithMany(p => p.Kasahar)
                    .HasForeignKey(d => d.Thid)
                    .HasConstraintName("FK_kasahar_tahshar");
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.HasKey(e => e.Katid);

                entity.Property(e => e.Katid).HasColumnName("katid");

                entity.Property(e => e.Hangikat).HasColumnName("hangikat");

                entity.Property(e => e.Katadi)
                    .IsRequired()
                    .HasColumnName("katadi")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Odehar>(entity =>
            {
                entity.HasKey(e => e.Ohid);

                entity.ToTable("odehar");

                entity.Property(e => e.Ohid).HasColumnName("ohid");

                entity.Property(e => e.Aciklama)
                    .IsRequired()
                    .HasColumnName("aciklama")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Kasaid).HasColumnName("kasaid");

                entity.Property(e => e.Odeid).HasColumnName("odeid");

                entity.Property(e => e.Odendimik).HasColumnName("odendimik");

                entity.Property(e => e.Odenmistar)
                    .HasColumnName("odenmistar")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.Kasa)
                    .WithMany(p => p.Odehar)
                    .HasForeignKey(d => d.Kasaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_odehar_Kasa");

                entity.HasOne(d => d.Ode)
                    .WithMany(p => p.Odehar)
                    .HasForeignKey(d => d.Odeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_odehar_Odemeler");
            });

            modelBuilder.Entity<Odemeler>(entity =>
            {
                entity.HasKey(e => e.Odeid);

                entity.Property(e => e.Odeid).HasColumnName("odeid");

                entity.Property(e => e.Aciklama)
                    .HasColumnName("aciklama")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Duzt)
                    .HasColumnName("duzt")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Fatad)
                    .HasColumnName("fatad")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Kasaid).HasColumnName("kasaid");

                entity.Property(e => e.Odendimik).HasColumnName("odendimik");

                entity.Property(e => e.Odenecektar)
                    .HasColumnName("odenecektar")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Odenmistar)
                    .HasColumnName("odenmistar")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Topmik).HasColumnName("topmik");

                entity.HasOne(d => d.Kasa)
                    .WithMany(p => p.Odemeler)
                    .HasForeignKey(d => d.Kasaid)
                    .HasConstraintName("FK_Odemeler_Kasa");
            });

            modelBuilder.Entity<Tahshar>(entity =>
            {
                entity.HasKey(e => e.Thid);

                entity.ToTable("tahshar");

                entity.Property(e => e.Thid).HasColumnName("thid");

                entity.Property(e => e.Aciklama)
                    .HasColumnName("aciklama")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Alinmismik).HasColumnName("alinmismik");

                entity.Property(e => e.Kasaid).HasColumnName("kasaid");

                entity.Property(e => e.Tahsid).HasColumnName("tahsid");

                entity.Property(e => e.Tediltar)
                    .HasColumnName("tediltar")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.Kasa)
                    .WithMany(p => p.Tahshar)
                    .HasForeignKey(d => d.Kasaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tahshar_Kasa");

                entity.HasOne(d => d.Tahs)
                    .WithMany(p => p.Tahshar)
                    .HasForeignKey(d => d.Tahsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tahshar_Tahsilat");
            });

            modelBuilder.Entity<Tahsilat>(entity =>
            {
                entity.HasKey(e => e.Tahsid);

                entity.Property(e => e.Tahsid).HasColumnName("tahsid");

                entity.Property(e => e.Aciklama)
                    .HasColumnName("aciklama")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Alinmismik).HasColumnName("alinmismik");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Duzt)
                    .HasColumnName("duzt")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Fatad)
                    .HasColumnName("fatad")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Kasaid).HasColumnName("kasaid");

                entity.Property(e => e.Tediltar)
                    .HasColumnName("tediltar")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Topmik).HasColumnName("topmik");

                entity.Property(e => e.Vadetarih)
                    .HasColumnName("vadetarih")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.Kasa)
                    .WithMany(p => p.Tahsilat)
                    .HasForeignKey(d => d.Kasaid)
                    .HasConstraintName("FK_Tahsilat_Kasa");
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.HasKey(e => e.Barkodno);

                entity.Property(e => e.Barkodno)
                    .HasColumnName("barkodno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adet).HasColumnName("adet");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasColumnName("adi")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Birim)
                    .IsRequired()
                    .HasColumnName("birim")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KategoriId).HasColumnName("kategori_id");

                entity.Property(e => e.Kdv).HasColumnName("kdv");

                entity.Property(e => e.Krseviye).HasColumnName("krseviye");

                entity.Property(e => e.Verharal).HasColumnName("verharal");

                entity.Property(e => e.Verharsat).HasColumnName("verharsat");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Urun)
                    .HasForeignKey(d => d.KategoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Urun_Kategori");
            });

            modelBuilder.Entity<Urunhareket>(entity =>
            {
                entity.HasKey(e => e.Urharid);

                entity.Property(e => e.Urharid).HasColumnName("urharid");

                entity.Property(e => e.Barkodno).HasColumnName("barkodno");

                entity.Property(e => e.Brfiyat).HasColumnName("brfiyat");

                entity.Property(e => e.Fatid).HasColumnName("fatid");

                entity.Property(e => e.Irsid).HasColumnName("irsid");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Vergi).HasColumnName("vergi");

                entity.HasOne(d => d.BarkodnoNavigation)
                    .WithMany(p => p.Urunhareket)
                    .HasForeignKey(d => d.Barkodno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Urunhareket_Urun");

                entity.HasOne(d => d.Fat)
                    .WithMany(p => p.Urunhareket)
                    .HasForeignKey(d => d.Fatid)
                    .HasConstraintName("FK_Urunhareket_Fatura");

                entity.HasOne(d => d.Irs)
                    .WithMany(p => p.Urunhareket)
                    .HasForeignKey(d => d.Irsid)
                    .HasConstraintName("FK_Urunhareket_irsaliye");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
