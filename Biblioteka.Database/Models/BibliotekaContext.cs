using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Biblioteka.Database.Models
{
    public partial class BibliotekaContext : DbContext
    {
        public BibliotekaContext()
        {
        }

        public BibliotekaContext(DbContextOptions<BibliotekaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClanModel> ClanModel { get; set; }
        public virtual DbSet<EvidencijaDugovanjaModel> EvidencijaDugovanjaModel { get; set; }
        public virtual DbSet<JezikModel> JezikModel { get; set; }
        public virtual DbSet<NaslovModel> NaslovModel { get; set; }
        public virtual DbSet<VrstaModel> VrstaModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-R5NN8B8;Database=Biblioteka;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClanModel>(entity =>
            {
                entity.HasKey(e => e.IdClan);

                entity.Property(e => e.IdClan).HasColumnName("idClan");

                entity.Property(e => e.ImePrezime)
                    .IsRequired()
                    .HasColumnName("imePrezime")
                    .HasMaxLength(50);

                entity.Property(e => e.Jmbg)
                    .HasColumnName("JMBG")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EvidencijaDugovanjaModel>(entity =>
            {
                entity.HasKey(e => e.IdEvidencija);

                entity.Property(e => e.IdEvidencija).HasColumnName("idEvidencija");

                entity.Property(e => e.DatumRazduzivanja)
                    .HasColumnName("datumRazduzivanja")
                    .HasColumnType("date");

                entity.Property(e => e.DatumZaduzivanja)
                    .HasColumnName("datumZaduzivanja")
                    .HasColumnType("date");

                entity.Property(e => e.IdClan).HasColumnName("idClan");

                entity.Property(e => e.IdNaslov).HasColumnName("idNaslov");

                entity.Property(e => e.UkupnaCena).HasColumnName("ukupnaCena");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.EvidencijaDugovanjaModel)
                    .HasForeignKey(d => d.IdClan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EvidencijaDugovanjaModel_ClanModel");

                entity.HasOne(d => d.IdNaslovNavigation)
                    .WithMany(p => p.EvidencijaDugovanjaModel)
                    .HasForeignKey(d => d.IdNaslov)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EvidencijaDugovanjaModel_NaslovModel");
            });

            modelBuilder.Entity<JezikModel>(entity =>
            {
                entity.HasKey(e => e.IdJezik);

                entity.Property(e => e.IdJezik).HasColumnName("idJezik");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NaslovModel>(entity =>
            {
                entity.HasKey(e => e.IdNaslov);

                entity.Property(e => e.IdNaslov).HasColumnName("idNaslov");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasMaxLength(50);

                entity.Property(e => e.CenaPoDanu).HasColumnName("cenaPoDanu");

                entity.Property(e => e.IdJezik).HasColumnName("idJezik");

                entity.Property(e => e.IdVrsta).HasColumnName("idVrsta");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdJezikNavigation)
                    .WithMany(p => p.NaslovModel)
                    .HasForeignKey(d => d.IdJezik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NaslovModel_JezikModel1");

                entity.HasOne(d => d.IdVrstaNavigation)
                    .WithMany(p => p.NaslovModel)
                    .HasForeignKey(d => d.IdVrsta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NaslovModel_VrstaModel1");
            });

            modelBuilder.Entity<VrstaModel>(entity =>
            {
                entity.HasKey(e => e.IdVrsta);

                entity.Property(e => e.IdVrsta).HasColumnName("idVrsta");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
