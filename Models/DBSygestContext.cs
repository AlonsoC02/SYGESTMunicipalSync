using Microsoft.EntityFrameworkCore;
using SYGESTMunicipalSync.Areas.Admin.Models;
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


        //  ACTIVIDADES OFICINA DE LA MUJER

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

            //----------------------------------------------------------------------

            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.ActividadId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoriaId)
                        .HasColumnName("CategoriaId");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.EjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividad_Eje");
            });


            // USUARIOS


            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.TipoUsuarioId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BotonHabilitado)
                  .HasColumnName("BotonHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.TipoUsuarioId)
                   .HasColumnName("TipoUsuarioId");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            modelBuilder.Entity<Boton>(entity =>
            {
                entity.HasKey(e => e.BotonId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
               .IsUnicode(false);

                entity.Property(e => e.BotonHabilitado)
                   .HasColumnName("BotonHabilitado");

                            
            });

            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.HasKey(e => e.PaginaId);

                entity.Property(e => e.Menu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Accion)
                .HasMaxLength(100)
               .IsUnicode(false);

                entity.Property(e => e.Controlador)
               .HasMaxLength(100)
              .IsUnicode(false);

                entity.Property(e => e.BotonHabilitado)
                   .HasColumnName("BotonHabilitado");

            });

            modelBuilder.Entity<TipoUsuarioPagina>(entity =>
            {
                entity.Property(e => e.TipoUsuarioPaginaId)
                    .HasColumnName("TipoUsuarioPaginaId");

                entity.Property(e => e.TipoUsuarioId)
                   .HasColumnName("TipoUsuarioId");

                entity.Property(e => e.PaginaId)
                  .HasColumnName("PaginaId");

                entity.Property(e => e.BotonHabilitado)
                    .HasColumnName("BotonHabilitado");

            });

            modelBuilder.Entity<TipoUsuarioPaginaBoton>(entity =>
            {
                entity.Property(e => e.TipoUsuarioPaginaBotonId)
                    .HasColumnName("TipoUsuarioPaginaBotonId");

                entity.Property(e => e.TipoUsuarioPaginaId)
                   .HasColumnName("TipoUsuarioPaginaId");

                entity.Property(e => e.BotonId)
                   .HasColumnName("BotonId");

                entity.Property(e => e.BotonHabilitado)
                    .HasColumnName("BotonHabilitado");
            });




        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
