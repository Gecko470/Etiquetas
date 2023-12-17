using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace etiquetasMiin.Models
{
    public partial class appDBContext : DbContext
    {
        public appDBContext()
        {
        }

        public appDBContext(DbContextOptions<appDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VSageEtiquetasAlbarane> VSageEtiquetasAlbaranes { get; set; }
        public virtual DbSet<WfPath> WfPaths { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.14.1;Database=WFS200;User ID=logic;Password=Sage2009+;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<VSageEtiquetasAlbarane>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vSage_EtiquetasAlbaranes");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlbaran).HasColumnType("datetime");

                entity.Property(e => e.ImporteLiquido).HasColumnType("decimal(28, 10)");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nacion)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesAlbaran)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PesoBruto)
                    .HasColumnType("decimal(28, 10)")
                    .HasColumnName("PesoBruto_");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SerieAlbaran)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeriePedido)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaNacion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SuPedido)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WfPath>(entity =>
            {
                entity.ToTable("WF_Paths");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("path");

                entity.Property(e => e.RutaAbsoluta)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("rutaAbsoluta");

                entity.Property(e => e.RutaVirtual)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("rutaVirtual");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
