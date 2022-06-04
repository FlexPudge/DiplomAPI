using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RoflanBobus
{
    public partial class SmolenskTravelContext : DbContext
    {
        public SmolenskTravelContext()
        {
        }

        public SmolenskTravelContext(DbContextOptions<SmolenskTravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutPhoto> AboutPhotos { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<InfoTour> InfoTours { get; set; }
        public virtual DbSet<LivingTour> LivingTours { get; set; }
        public virtual DbSet<ProgrammTour> ProgrammTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=GLEK-PC\\GLADSERVER;Initial Catalog=SmolenskTravel;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AboutPhoto>(entity =>
            {
                entity.ToTable("AboutPhoto");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.HasOne(d => d.IdTourNavigation)
                    .WithMany(p => p.AboutPhotos)
                    .HasForeignKey(d => d.IdTour)
                    .HasConstraintName("FK_AboutPhoto_Tours");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .HasColumnName("FIO");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idclient).HasColumnName("IDClient");

                entity.Property(e => e.Idtours).HasColumnName("IDTours");

                entity.HasOne(d => d.IdclientNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Idclient)
                    .HasConstraintName("FK_Favorite_Clients");

                entity.HasOne(d => d.IdtoursNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Idtours)
                    .HasConstraintName("FK_Favorite_Tours");
            });

            modelBuilder.Entity<InfoTour>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<LivingTour>(entity =>
            {
                entity.ToTable("LivingTour");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ProgrammTour>(entity =>
            {
                entity.ToTable("ProgrammTour");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.IdlivingTour).HasColumnName("IDLivingTour");

                entity.Property(e => e.IdprogrammTour).HasColumnName("IDProgrammTour");

                entity.Property(e => e.IdtourInfo).HasColumnName("IDTourInfo");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.TypeTour).HasMaxLength(50);

                entity.HasOne(d => d.IdlivingTourNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.IdlivingTour)
                    .HasConstraintName("FK_Tours_LivingTour");

                entity.HasOne(d => d.IdprogrammTourNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.IdprogrammTour)
                    .HasConstraintName("FK_Tours_ProgrammTour");

                entity.HasOne(d => d.IdtourInfoNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.IdtourInfo)
                    .HasConstraintName("FK_Tours_InfoTours");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateSale).HasColumnType("date");

                entity.Property(e => e.Idclients).HasColumnName("IDClients");

                entity.Property(e => e.Idtours).HasColumnName("IDTours");

                entity.HasOne(d => d.IdclientsNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.Idclients)
                    .HasConstraintName("FK_Vouchers_Clients");

                entity.HasOne(d => d.IdtoursNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.Idtours)
                    .HasConstraintName("FK_Vouchers_Tours");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
