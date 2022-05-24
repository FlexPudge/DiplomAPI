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

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<InfoTour> InfoTours { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<OptionsTour> OptionsTours { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<TypeTour> TypeTours { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GLEK-PC\\GLADSERVER;Initial Catalog=SmolenskTravel;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

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

                entity.Property(e => e.Idtour).HasColumnName("IDTour");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<OptionsTour>(entity =>
            {
                entity.ToTable("OptionsTour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idoptions).HasColumnName("IDOptions");

                entity.Property(e => e.Idtour).HasColumnName("IDTour");

                entity.HasOne(d => d.IdoptionsNavigation)
                    .WithMany(p => p.OptionsTours)
                    .HasForeignKey(d => d.Idoptions)
                    .HasConstraintName("FK_OptionsTour_Options");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.TypeTour).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeTour>(entity =>
            {
                entity.ToTable("TypeTour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(50);
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

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fio)
                    .HasMaxLength(50)
                    .HasColumnName("FIO");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
