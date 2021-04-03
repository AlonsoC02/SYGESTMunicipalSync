using Microsoft.EntityFrameworkCore;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.OFGA.Models;
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

        //--------------------Area Admin-------------------------------
        public virtual DbSet<Boton> Boton { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<TipoUsuarioPagina> TipoUsuarioPagina { get; set; }
        public virtual DbSet<TipoUsuarioPaginaBoton> TipoUsuarioPaginaBoton { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Utilitarios> Utilitarios { get; set; }
        //

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-4KIF3VN\\SQLEXPRESS;Database=SYGEST;Trusted_Connection=True;MultipleActiveResultsets=true");
            }                              
        }


        // **************************** ACTIVIDADES OFICINA DE LA MUJER************************************************

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

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                   .HasColumnName("Fecha")
                   .HasColumnType("datetime");

                entity.Property(e => e.Imagen)
                 .HasColumnName("Imagen")
                 .HasColumnType("varbinary(max)");        // <------------------------------------------------------

                entity.Property(e => e.Activo)
                 .HasColumnName("Activo")
                 .HasColumnType("bit");        // <------------------------------------------------------

                entity.Property(e => e.CategoriaId)
                        .HasColumnName("CategoriaId");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividad_Categoria");

                entity.Property(e => e.EjeId)
                      .HasColumnName("EjeId");

                entity.HasOne(d => d.Eje)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.EjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividad_Eje");
            });

            modelBuilder.Entity<Cupos>(entity =>
            {
                entity.HasKey(e => e.CuposId);

                entity.Property(e => e.CupoMax);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ActividadId)
                        .HasColumnName("ActividadId");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.Cupos)
                    .HasForeignKey(d => d.ActividadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cupos_Actividad");
            });



            // -----------------------------------  FALTA INSCRIPCIÓN --------------------------------------------





            // **************************** USUARIOS ************************************************


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

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Password2)
                    .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.PersonaId)
                   .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Persona");

                entity.Property(e => e.DistritoId)
                 .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Distrito");

                entity.Property(e => e.CantonId)
                 .HasColumnName("CantonId");

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Canton");

                entity.Property(e => e.ProvinciaId)
                 .HasColumnName("ProvinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Provincia");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuarioId)
               .HasColumnName("NombreUsuarioId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.NombreUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Usuario");

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

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.ContactoId);

                entity.Property(e => e.MedioNotificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

              

            });

            // **************************** PERSONA ************************************************

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.CedulaPersona)
               .IsRequired()
                .HasMaxLength(100)
              .IsUnicode(false);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Ape1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ape2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.FechaNac)
                    .HasColumnName("FechaNac")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                   .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelMovil)
                .IsRequired();
                   
                entity.Property(e => e.TelFijo);

                entity.Property(e => e.Fax);

                entity.Property(e => e.Sexo)
                    .HasColumnName("Sexo")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Direccion)
                     .IsRequired()
                     .HasMaxLength(200)
                     .IsUnicode(false);

                entity.Property(e => e.DistritoId)
                   .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Distrito");

                entity.Property(e => e.CantonId)
                 .HasColumnName("CantonId");

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.CantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Canton");

                entity.Property(e => e.ProvinciaId)
                .HasColumnName("ProvinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Provincia");

            });

            // **************************** CONSULTAS OFIM************************************************

            modelBuilder.Entity<TipoConsulta>(entity =>
            {
                entity.HasKey(e => e.TipoConsultaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PersonaId)
                .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.TipoConsulta)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoConsulta_Persona");

            });



            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.ConsultaId);

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                   .HasColumnName("Fecha")
                   .HasColumnType("date");

                entity.Property(e => e.HoraInicio)
                   .HasColumnName("HoraInicio")
                   .HasColumnType("date");

                entity.Property(e => e.HoraFin)
                   .HasColumnName("HoraFin")
                   .HasColumnType("date");

                entity.Property(e => e.Descripcion)
                   .IsRequired()
                   .HasMaxLength(300)
                   .IsUnicode(false);

                entity.Property(e => e.Respuesta)
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);

                entity.Property(e => e.Remitir)
                  .HasColumnName("Remitir")
                  .HasColumnType("bit");

                entity.Property(e => e.PersonaId)
                .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consulta_Persona");

                entity.Property(e => e.TipoConsultaId)
               .HasColumnName("TipoConsultaId");

                entity.HasOne(d => d.TipoConsulta)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.TipoConsultaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consulta_TipoConsulta");

            });

            modelBuilder.Entity<Seguimiento>(entity =>
            {
                entity.HasKey(e => e.SeguimientoId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PersonaId)
                .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Seguimiento)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seguimiento_Persona");

                entity.Property(e => e.ConsultaId)
               .HasColumnName("ConsultaId");

                entity.HasOne(d => d.Consulta)
                    .WithMany(p => p.Seguimiento)
                    .HasForeignKey(d => d.ConsultaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seguimiento_Consulta");


            });

            // **************************** DIRECCIÓN ************************************************


            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.ProvinciaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CantonId)
                .HasColumnName("CantonId");

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.CantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Provincia_Canton");

                entity.Property(e => e.DistritoId)
               .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Provincia_Distrito");


            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.HasKey(e => e.CantonId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                           
                entity.Property(e => e.DistritoId)
               .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Canton_Distrito");


            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.DistritoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                            
            });

            // **************************** PERSONA OFIM ************************************************


            modelBuilder.Entity<PersonaOFIM>(entity =>
            {
                entity.HasKey(e => e.PersonaOFIMId);

                entity.Property(e => e.PersonaId)
             .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Persona");

                entity.Property(e => e.PersonaId)
           .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Persona");

                entity.Property(e => e.OcupacionId)
           .HasColumnName("OcupacionId");

                entity.HasOne(d => d.Ocupacion)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.OcupacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Ocupacion");

                entity.Property(e => e.SeguroId)
           .HasColumnName("SeguroId");

                entity.HasOne(d => d.Seguro)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.SeguroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Seguro");

                entity.Property(e => e.NacionalidadId)
           .HasColumnName("NacionalidadId");

                entity.HasOne(d => d.Nacionalidad)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.NacionalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Nacionalidad");

                  entity.Property(e => e.NivelAcademicoId)
             .HasColumnName("NivelAcademicoId");

                entity.HasOne(d => d.NivelAcademico)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.NivelAcademicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_NivelAcademico");

                entity.Property(e => e.EstadoCivilId)
           .HasColumnName("EstadoCivilId");

                entity.HasOne(d => d.EstadoCivil)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.EstadoCivilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_EstadoCivil");

                entity.Property(e => e.PadecimientoId)
           .HasColumnName("PadecimientoId");

                entity.HasOne(d => d.Padecimiento)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.PadecimientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Padecimiento");

                entity.Property(e => e.DiscapacidadId)
           .HasColumnName("PersonaId");

                entity.HasOne(d => d.Discapacidad)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.DiscapacidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Discapacidad");

                entity.Property(e => e.IngresoPersonaId)
           .HasColumnName("IngresoPersonaId");

                entity.HasOne(d => d.IngresoPersona)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.IngresoPersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_IngresoPersona");

            });

            modelBuilder.Entity<Discapacidades>(entity =>
            {
                entity.HasKey(e => e.DiscapacidadesId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

            });


            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.HasKey(e => e.EstadoCivilId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                             
            });

            modelBuilder.Entity<IngresoPersona>(entity =>
            {
                entity.HasKey(e => e.IngresoPersonaId);

                entity.Property(e => e.IngresoMensual)
                     .HasColumnName("IngresoMensual")
                     .HasColumnType("real");   // <------------------ ver si se usa real o money

            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.HasKey(e => e.NacionalidadId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<NivelAcademico>(entity =>
            {
                entity.HasKey(e => e.NivelAcademicoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Ocupacion>(entity =>
            {
                entity.HasKey(e => e.OcupacionId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });


            modelBuilder.Entity<Padecimientos>(entity =>
            {
                entity.HasKey(e => e.PadecimientoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.HasKey(e => e.SeguroId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });


            // **************************** FAMILIA ************************************************

            modelBuilder.Entity<Parentesco>(entity =>
            {
                entity.HasKey(e => e.ParentescoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                            
            });

            modelBuilder.Entity<Familia>(entity =>
            {
                entity.HasKey(e => e.FamiliaId);

             

                entity.Property(e => e.PersonaId1)
                .HasColumnName("PersonaId1");

                entity.HasOne(d => d.Persona1)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.PersonaId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Familia_Persona1");

                entity.Property(e => e.PersonaId2)
              .HasColumnName("PersonaId2");

                entity.HasOne(d => d.Persona2)
                 .WithMany(p => p.Familia)
                 .HasForeignKey(d => d.PersonaId2)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Familia_Persona2");

                entity.Property(e => e.ParentescoId)
               .HasColumnName("ParentescoId");

                entity.HasOne(d => d.Parentesco)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.ParentescoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Familia_Parentesco");


            });


            // **************************** EMPRESARIEDAD ************************************************

            modelBuilder.Entity<CatProductoServicio>(entity =>
            {
                entity.HasKey(e => e.CatProductoServicioId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

            });



            modelBuilder.Entity<ProductoServicio>(entity =>
            {
                entity.HasKey(e => e.CatProductoServicioId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

                entity.Property(e => e.Imagen)
                 .HasColumnName("Imagen")
                 .HasColumnType("varbinary(max)");

                entity.Property(e => e.EmpresaId)
              .HasColumnName("EmpresaId");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.ProductoServicio)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoServicio_Empresa");



            });


            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.EmpresaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                 .HasColumnName("Imagen")
                 .HasColumnType("varbinary(max)");

                entity.Property(e => e.Ubicacion)
                 .IsRequired()
                 .HasMaxLength(200)
                 .IsUnicode(false);

                entity.Property(e => e.PaginaWeb)
                 .IsRequired()
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.Email)
                 .IsRequired()
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

                entity.Property(e => e.Telefono)
                .IsRequired();



                entity.Property(e => e.PersonaId)
              .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_Persona");

                entity.Property(e => e.CatProductoServicioId)
             .HasColumnName("CatProductoServicioId");

                entity.HasOne(d => d.CatProductoServicio)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.CatProductoServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_CatProductoServicio");



            });


            // ############################ CLASES OFICINA DE GESTIÓN AMBIENTAL ############################


            // **************************** RESIDUOS ORDINARIOS ************************************************

            modelBuilder.Entity<Basura>(entity =>
            {
                entity.HasKey(e => e.BasuraId);

                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                     .HasColumnName("Peso")
                     .HasColumnType("real");   // <------------------ ver si se usa real o money

            });

            // **************************** CHARLAS GESTIÓN AMBIENTAL ************************************************

            modelBuilder.Entity<Charlas>(entity =>
            {
                entity.HasKey(e => e.CharlasId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);

                entity.Property(e => e.Imagen)
                 .HasColumnName("Imagen")
                 .HasColumnType("varbinary(max)");

                entity.Property(e => e.Lugar)
                  .IsRequired()
                  .HasMaxLength(100)
                  .IsUnicode(false);

                entity.Property(e => e.Activa)
                .HasColumnName("Activa")
                .HasColumnType("bit");

                entity.Property(e => e.Expositor)
                  .IsRequired()
                  .HasMaxLength(250)
                  .IsUnicode(false);

            });

            // **************************** CENTRO DE ACOPIO  ************************************************

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.HasKey(e => e.ClasificacionId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                               
                entity.Property(e => e.Descripcion)
                  .IsRequired()
                  .HasMaxLength(200)
                  .IsUnicode(false);
            });

            modelBuilder.Entity<IngresoVenta>(entity =>
            {
                entity.HasKey(e => e.ImgresoVentaId);
                             
                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                       .HasColumnName("Peso")
                       .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.Precio)
                    .HasColumnName("Precio")
                    .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.Monto)
                    .HasColumnName("Monto")
                    .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.Total)
                    .HasColumnName("Total")
                    .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.MaterialId)
                    .HasColumnName("MaterialId");

                entity.HasOne(d => d.Materiales)
                    .WithMany(p => p.IngresoVenta)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngresoVenta_Materiales");

                entity.Property(e => e.ClasificacionId)
                    .HasColumnName("ClasificacionId");

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.IngresoVenta)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IngresoVenta_Clasificacion");

            });



            modelBuilder.Entity<Materiales>(entity =>
            {
                entity.HasKey(e => e.MaterialesId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                .HasColumnName("Color")
                .HasColumnType("bit");

                entity.Property(e => e.ClasificacionId)
                    .HasColumnName("ClasificacionId");

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.Materiales)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materiales_Clasificacion");
            });

            modelBuilder.Entity<Pacas>(entity =>
            {
                entity.HasKey(e => e.PacasId);

                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                       .HasColumnName("Peso")
                       .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.MaterialId)
                   .HasColumnName("MaterialId");

                entity.HasOne(d => d.Materiales)
                    .WithMany(p => p.Pacas)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacas_Materiales");

                entity.Property(e => e.ClasificacionId)
                    .HasColumnName("ClasificacionId");

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.Pacas)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pacas_Clasificacion");

            });

            modelBuilder.Entity<PuntoRecMaterial>(entity =>
            {
                entity.HasKey(e => e.PuntosRecMaterialId);

                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                       .HasColumnName("Peso")
                       .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.MaterialId)
                  .HasColumnName("MaterialId");

                entity.HasOne(d => d.Materiales)
                    .WithMany(p => p.PuntoRecMaterial)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntorecMaterial_Materiales");

                entity.Property(e => e.ClasificacionId)
                    .HasColumnName("ClasificacionId");

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.PuntoRecMaterial)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoRecMaterial_Clasificacion");

                entity.Property(e => e.DistritoId)
                    .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.PuntoRecMaterial)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoRecMaterial_Distrito");

            });

            modelBuilder.Entity<Recuento>(entity =>
            {
                entity.HasKey(e => e.RecuentoId);

                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.PesoGlobal)
                       .HasColumnName("PesoGlobal")
                       .HasColumnType("real");   // <------------------ ver si se usa real o money

                entity.Property(e => e.MaterialId)
                    .HasColumnName("MaterialId");

                entity.HasOne(d => d.Materiales)
                    .WithMany(p => p.Recuento)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recuento_Materiales");

                entity.Property(e => e.ClasificacionId)
                    .HasColumnName("ClasificacionId");

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.Recuento)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recuento_Clasificacion");

                              
            });

            // **************************** DENUNCIAS GESTIÓN AMBIENTAL  ************************************************

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.DenunciaId);

                entity.Property(e => e.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Infractor)
                   .IsRequired()
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.Property(e => e.Reincidente)
                .HasColumnName("Reincidente")
                .HasColumnType("bit");

                entity.Property(e => e.DependenciaAnterior)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);

                entity.Property(e => e.Anonima)
                .HasColumnName("Anonima")
                .HasColumnType("bit");

                entity.Property(e => e.Imagen)
               .HasColumnName("Imagen")
               .HasColumnType("varbinary(max)");


                entity.Property(e => e.Direccion)
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);

                entity.Property(e => e.DistritoId)
                    .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Denuncia_Distrito");

                entity.Property(e => e.CantonId)
                .HasColumnName("CantonId");

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.CantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Denuncia_Canton");

                entity.Property(e => e.ProvinciaId)
                .HasColumnName("ProvinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Denuncia_Provincia");

                entity.Property(e => e.LoginId)
                .HasColumnName("LoginId");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Denuncia_Login");

                entity.Property(e => e.TipoDenunciaId)
                .HasColumnName("TipoDenunciaId");

                entity.HasOne(d => d.TipoDenuncia)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.TipoDenunciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Denuncia_TipoDenuncia");

                entity.Property(e => e.TipoActividadId)
                .HasColumnName("TipoActividadId");

                entity.HasOne(d => d.TipoActividad)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.TipoActividadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Denuncia_TipoActividad");


            });

            modelBuilder.Entity<TipoActividad>(entity =>
            {
                entity.HasKey(e => e.TipoActividadId);
                               
                entity.Property(e => e.Nombre)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);
                               
            });


            modelBuilder.Entity<TipoDenuncia>(entity =>
            {
                entity.HasKey(e => e.TipoDenunciaId);

                entity.Property(e => e.Nombre)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            });


            // ############################ CLASES OFICINA DE PATENTES ############################


            // **************************** RESIDUOS ORDINARIOS ************************************************




            OnModelCreatingPartial(modelBuilder);

        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
