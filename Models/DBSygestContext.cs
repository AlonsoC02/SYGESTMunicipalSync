using Microsoft.EntityFrameworkCore;
using SYGESTMunicipalSync.Areas.OFIM.Models;

namespace SYGESTMunicipalSync.Models
{
    public partial class DBSygestContext : DbContext
    {
        public DBSygestContext()
        {
        }

        public DBSygestContext(DbContextOptions<DBSygestContext> options)
           : base(options)
        {
        }

        //DB SETS DE LAS CLASES

        //

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-4KIF3VN\\SQLEXPRESS;Database=SYGEST;Trusted_Connection=True;MultipleActiveResultsets=true");
            }                              
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Eje>(entity =>
            {
                entity.HasKey(e => e.EjeId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
           
            entity.Property(e => e.CategoriaId)
                    .HasColumnName("CategoriaId");

            entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Eje)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Eje_Categoria");
            });



        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
