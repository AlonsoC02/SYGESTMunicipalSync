using Microsoft.EntityFrameworkCore;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models;

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
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolUsuarioPag> RolUsuarioPag { get; set; }
        public virtual DbSet<RolUsuarioPagBoton> RolUsuarioPagBoton { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }

        //-------------------- Area OFGA----------------------------

        public virtual DbSet<Basura> Basura { get; set; }
        public virtual DbSet<Charlas> Charlas { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<IngresoVenta> IngresoVenta { get; set; }
        public virtual DbSet<Materiales> Materiales { get; set; }
        public virtual DbSet<Pacas> Pacas { get; set; }
        public virtual DbSet<PuntoRecMaterial> PuntoRecMaterial { get; set; }
        public virtual DbSet<Quejas> Quejas { get; set; }
        public virtual DbSet<Recuento> Recuento { get; set; }
        public virtual DbSet<TipoActividad> TipoActividad { get; set; }
        public virtual DbSet<TipoDenuncia> TipoDenuncia { get; set; }

        //-------------------- Area OFIM----------------------------

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<CatProductoServicio> CatProductoServicio { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Cupos> Cupos { get; set; }
        public virtual DbSet<Discapacidades> Discapacidades { get; set; }
        public virtual DbSet<Eje> Eje { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<IngresoPersona> IngresoPersona { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidad { get; set; }
        public virtual DbSet<NivelAcademico> NivelAcademico { get; set; }
        public virtual DbSet<Ocupacion> Ocupacion { get; set; }
        public virtual DbSet<Padecimientos> Padecimientos { get; set; }
        public virtual DbSet<Parentesco> Parentesco { get; set; }
        public virtual DbSet<PersonaOFIM> PersonaOFIM { get; set; }
        public virtual DbSet<ProductoServicio> ProductoServicio { get; set; }
        public virtual DbSet<Seguimiento> Seguimiento { get; set; }
        public virtual DbSet<Seguro> Seguro { get; set; }
        public virtual DbSet<TipoConsulta> TipoConsulta { get; set; }


        //-------------------- Area PATENTES----------------------------

        public virtual DbSet<Clase> Clase { get; set; }
        public virtual DbSet<ClasifSenasa> ClasifSenasa { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Establecimiento> Establecimiento { get; set; }
        public virtual DbSet<Formulario> Formulario { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Motivo> Motivo { get; set; }
        public virtual DbSet<Propietario> Propietario { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Solicitante> Solicitante { get; set; }
        public virtual DbSet<TipoInmueble> TipoInmueble { get; set; }
        public virtual DbSet<TipoRepresentante> TipoRepresentante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("server=DESKTOP-4KIF3VN\\SQLEXPRESS;Database=SYGEST;Trusted_Connection=True;MultipleActiveResultsets=true");
                //optionsBuilder.UseSqlServer("server=LAPTOP-9LLKQMMH\\SQLEXPRESS;Database=SYGEST;Trusted_Connection=True;MultipleActiveResultsets=true");
                optionsBuilder.UseSqlServer("server=LAPTOP-FQENG2D7\\SQLEXPRESS;Database=SYGEST;Trusted_Connection=True;MultipleActiveResultsets=true");
            }                              
        }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // ############################ CLASES DEL SISTEMA ############################


            // **************************** USUARIOS ************************************************


            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

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
                    .IsRequired()
                    .HasMaxLength(50)
                   .IsUnicode(false);

                //entity.Property(e => e.ConfirmarContrasena)
                //    .IsRequired()
                //    .HasMaxLength(50)
                //   .IsUnicode(false);

                entity.Property(e => e.PersonaId)
                   .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Persona");

                entity.Property(e => e.RolId)
                  .HasColumnName("RolId");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");


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
                   .HasColumnName("BotonHabilitado")
                   .HasColumnType("bit");


            });

            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.HasKey(e => e.PaginaId);

                entity.Property(e => e.Menu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Accion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controlador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<RolUsuarioPag>(entity =>
            {
                entity.HasKey(e => e.RolUsuarioPagId);


                entity.Property(e => e.BotonHabilitado)
                    .IsRequired()
                    .HasColumnName("BotonHabilitado")
                    .HasColumnType("bit");

                entity.Property(e => e.RolId)
                      .HasColumnName("RolId");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolUsuarioPag)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolUsuarioPag_Rol");

                entity.Property(e => e.PaginaId)
                      .HasColumnName("PaginaId");

                entity.HasOne(d => d.Pagina)
                    .WithMany(p => p.RolUsuarioPag)
                    .HasForeignKey(d => d.PaginaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolUsuarioPag_Pagina");

            });

            modelBuilder.Entity<RolUsuarioPagBoton>(entity =>
            {
                entity.Property(e => e.RolUsuarioPagBotonId)
                    .HasColumnName("RolUsuarioPagBotonId");


                entity.Property(e => e.BotonHabilitado)
                   .IsRequired()
                   .HasColumnName("BotonHabilitado")
                   .HasColumnType("bit");

                entity.Property(e => e.RolUsuarioPagId)
                      .HasColumnName("RolUsuarioPagId");

                entity.HasOne(d => d.RolUsuarioPag)
                    .WithMany(p => p.RolUsuarioPagBoton)
                    .HasForeignKey(d => d.RolUsuarioPagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolUsuarioPagBoton_RolUsuarioPag");

                entity.Property(e => e.BotonId)
                      .HasColumnName("BotonId");

                entity.HasOne(d => d.Boton)
                    .WithMany(p => p.RolUsuarioPagBoton)
                    .HasForeignKey(d => d.BotonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolUsuarioPagBoton_Boton");

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
                entity.HasKey(e => e.CedulaPersona);
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
                    .IsRequired()
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
                    .IsRequired()
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

           

            // **************************** DIRECCIÓN ************************************************


            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.ProvinciaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.HasKey(e => e.CantonId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                           
                entity.Property(e => e.ProvinciaId)
               .HasColumnName("ProvinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Canton_Provincia");


            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.DistritoId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.CantonId)
              .HasColumnName("CantonId");

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.CantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distrito_Canton");


                entity.Property(e => e.ProvinciaId)
              .HasColumnName("ProvinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distrito_Provincia");


            });

           







            // ############################ CLASES OFICINA DE LA MUJER ############################

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
           .HasColumnName("DiscapacidadId");

                entity.HasOne(d => d.Discapacidad)
                    .WithMany(p => p.PersonaOFIM)
                    .HasForeignKey(d => d.DiscapacidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaOFIM_Discapacidades");

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
                entity.HasKey(e => e.DiscapacidadId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
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
                     .IsRequired()
                     .HasColumnName("IngresoMensual")
                     .HasColumnType("money");   // <------------------ ver si se usa real o money

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

            // **************************** EMPRESARIEDAD ************************************************

            modelBuilder.Entity<CatProductoServicio>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                  .HasMaxLength(200)
                  .IsUnicode(false);

            });



            modelBuilder.Entity<ProductoServicio>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
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

                entity.Property(e => e.CatProductoServicioId)
            .HasColumnName("CatProductoServicioId");

                entity.HasOne(d => d.CatProductoServicio)
                    .WithMany(p => p.ProductoServicio)
                    .HasForeignKey(d => d.CatProductoServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoServicio_CatProductoServicio");



            });


            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

           

                entity.Property(e => e.Ubicacion)
                 .IsRequired()
                 .HasMaxLength(200)
                 .IsUnicode(false);

                entity.Property(e => e.PaginaWeb)
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.Email)
                 .HasMaxLength(100)
                 .IsUnicode(false);

                entity.Property(e => e.Logo)
                .HasColumnName("Logo")
                .HasColumnType("varbinary(max)");        // <------------------------------------------------------

                entity.Property(e => e.Descripcion)
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
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(false);

                entity.Property(e => e.PersonaId2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.ParentescoId)
               .HasColumnName("ParentescoId");

                entity.HasOne(d => d.Parentesco)
                    .WithMany(p => p.Familia)
                    .HasForeignKey(d => d.ParentescoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Familia_Parentesco");


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
                   .IsRequired()
                   .HasColumnName("Fecha")
                   .HasColumnType("date");

                entity.Property(e => e.HoraInicio)
                   .IsRequired()
                   .HasColumnName("HoraInicio")
                   .HasColumnType("date");

                entity.Property(e => e.HoraFin)
                    .IsRequired()
                   .HasColumnName("HoraFin")
                   .HasColumnType("date");

                entity.Property(e => e.Descripcion)
                   .HasMaxLength(300)
                   .IsUnicode(false);

                entity.Property(e => e.Respuesta)
                   .HasMaxLength(200)
                   .IsUnicode(false);

                entity.Property(e => e.Remitir)
                  .IsRequired()
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

            // **************************** ACTIVIDADES OFICINA DE LA MUJER************************************************
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Eje>(entity =>
            {
                entity.HasKey(e => e.Id);

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
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                   .IsRequired()
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
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Activo)
               .HasColumnName("Activo")
               .HasColumnType("bit");

                entity.Property(e => e.ActividadId)
                        .HasColumnName("ActividadId");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.Cupos)
                    .HasForeignKey(d => d.ActividadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cupos_Actividad");
            });



            // -----------------------------------  FALTA INSCRIPCIÓN --------------------------------------------


            // ############################ CLASES OFICINA DE GESTIÓN AMBIENTAL ############################


            // **************************** RESIDUOS ORDINARIOS ************************************************

            modelBuilder.Entity<Basura>(entity =>
            {
                entity.HasKey(e => e.BasuraId);

                entity.Property(e => e.Fecha)
                .IsRequired()
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                     .IsRequired()
                     .HasColumnName("Peso")
                     .HasColumnType("float");   // <------------------ ver si se usa real o money

            });

            // **************************** CHARLAS GESTIÓN AMBIENTAL ************************************************

            modelBuilder.Entity<Charlas>(entity =>
            {
                entity.HasKey(e => e.CharlaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                .IsRequired()
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
                  .HasMaxLength(200)
                  .IsUnicode(false);
            });

            modelBuilder.Entity<IngresoVenta>(entity =>
            {
                entity.HasKey(e => e.ImgresoVentaId);
                             
                entity.Property(e => e.Fecha)
                .IsRequired()
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                        .IsRequired()
                       .HasColumnName("Peso")
                       .HasColumnType("float");   // <------------------ ver si se usa real o money

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasColumnName("Precio")
                    .HasColumnType("money");   // <------------------ ver si se usa real o money

                entity.Property(e => e.Monto)
                    .IsRequired()
                    .HasColumnName("Monto")
                    .HasColumnType("money");   // <------------------ ver si se usa real o money

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnName("Total")
                    .HasColumnType("money");   // <------------------ ver si se usa real o money

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
                entity.HasKey(e => e.MaterialId);

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
                entity.HasKey(e => e.PacaId);

                entity.Property(e => e.Fecha)
                .IsRequired()
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                       .IsRequired()
                       .HasColumnName("Peso")
                       .HasColumnType("float");   // <------------------ ver si se usa real o money

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
                .IsRequired()
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

                entity.Property(e => e.Peso)
                       .IsRequired()
                       .HasColumnName("Peso")
                       .HasColumnType("float");   // <------------------ ver si se usa real o money

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

                entity.Property(e => e.FechaPeso)
                .IsRequired()
                .HasColumnName("FechaPeso")
                .HasColumnType("datetime");

                entity.Property(e => e.PesoGlobal)
                       .IsRequired()
                       .HasColumnName("PesoGlobal")
                       .HasColumnType("float");   // <------------------ ver si se usa real o money

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
                .IsRequired()
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

                //entity.Property(e => e.LoginId)
                //.HasColumnName("LoginId");

                //entity.HasOne(d => d.Login)
                //    .WithMany(p => p.Denuncia)
                //    .HasForeignKey(d => d.LoginId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Denuncia_Login");

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

                entity.Property(e => e.Descripcion)
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);

            });


            // ############################ CLASES OFICINA DE PATENTES ############################


            // **************************** DATOS DEL ESTABLECIMIENTO ************************************************

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.CodigoClase);
                entity.Property(e => e.CodigoClase)
               .IsRequired()
                .HasMaxLength(50)
              .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                      .HasMaxLength(200)
                      .IsUnicode(false);
                     
                entity.Property(e => e.Riesgo)
                    .IsRequired()
                    .HasColumnName("Sexo")
                    .HasColumnType("char(1)");


                entity.Property(e => e.GrupoId)
                   .HasColumnName("GrupoId");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Grupo");

                entity.Property(e => e.DivisionId)
                 .HasColumnName("DivisionId");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Division");

                entity.Property(e => e.SeccionId)
                .HasColumnName("SeccionId");

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Clase)
                    .HasForeignKey(d => d.SeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clase_Seccion");

            });


            modelBuilder.Entity<ClasifSenasa>(entity =>
            {
                entity.HasKey(e => e.ClasifSenasaId);

                entity.Property(e => e.Nombre)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);


            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.CodigoDivision);
                entity.Property(e => e.CodigoDivision)
                            .IsRequired()
                            .HasMaxLength(50)
                            .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                           .HasMaxLength(200)
                           .IsUnicode(false);

                entity.Property(e => e.SeccionId)
                .HasColumnName("SeccionId");

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Division)
                    .HasForeignKey(d => d.SeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Division_Seccion");

            });

            modelBuilder.Entity<Establecimiento>(entity =>
            {
                entity.HasKey(e => e.EstablecimientoId);

                entity.Property(e => e.NombreComercial)
                           .IsRequired()
                           .HasMaxLength(100)
                           .IsUnicode(false);

                entity.Property(e => e.DescripcionActividad)
                           .HasMaxLength(200)
                           .IsUnicode(false);

                entity.Property(e => e.ActividadesSecundarias)
                           .IsRequired()
                           .HasMaxLength(200)
                           .IsUnicode(false);

                entity.Property(e => e.Direccion)
                           .IsRequired()
                           .HasMaxLength(200)
                           .IsUnicode(false);

                entity.Property(e => e.NumFinca)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);

                entity.Property(e => e.NumPlano)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);

                entity.Property(e => e.PaginaWeb)
                         .HasMaxLength(100)
                         .IsUnicode(false);

                entity.Property(e => e.HoraEntrada)
              .IsRequired()
              .HasColumnName("HoraEntrada")
              .HasColumnType("datetime");

                entity.Property(e => e.HoraCierre)
             .IsRequired()
             .HasColumnName("HoraCierre")
             .HasColumnType("datetime");

                entity.Property(e => e.Aream2)
                       .IsRequired()
                       .HasColumnName("Aream2")
                       .HasColumnType("float");   // <------------------ ver si se usa real o money

                entity.Property(e => e.CantHombres)
                .IsRequired();

                entity.Property(e => e.CantMujeres)
                .IsRequired();

                entity.Property(e => e.Calificados)
                .IsRequired();

                entity.Property(e => e.NoCalificados)
                .IsRequired();

                entity.Property(e => e.Solicitante)
                .HasColumnName("Solicitante")
                .HasColumnType("bit");


                entity.Property(e => e.DistritoId)
                  .HasColumnName("DistritoId");

                entity.HasOne(d => d.Distrito)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.DistritoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_Distrito");

                entity.Property(e => e.CantonId)
                .HasColumnName("CantonId");

                entity.HasOne(d => d.Canton)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.CantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_Canton");

                entity.Property(e => e.ProvinciaId)
                .HasColumnName("ProvinciaId");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_Provincia");

                entity.Property(e => e.TipoInmuebleId)
                .HasColumnName("TipoInmuebleId");

                entity.HasOne(d => d.TipoInmueble)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.TipoInmuebleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_TipoInmueble");

                entity.Property(e => e.ClasifSenasaId)
                .HasColumnName("ClasifSenesaId");

                entity.HasOne(d => d.ClasifSenasa)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.ClasifSenasaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_ClasifSenasa");

                entity.Property(e => e.ClaseId)
                .HasColumnName("ClaseId");

                entity.HasOne(d => d.Clase)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.ClaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_Clase");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.CodigoGrupo);
                entity.Property(e => e.CodigoGrupo)
                            .IsRequired()
                            .HasMaxLength(50)
                            .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                           .HasMaxLength(200)
                           .IsUnicode(false);

                entity.Property(e => e.SeccionId)
                .HasColumnName("SeccionId");

                entity.HasOne(d => d.Seccion)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.SeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Seccion");

                entity.Property(e => e.DivisionId)
                .HasColumnName("DivisionId");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Division");

            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.CodigoSeccion);
                entity.Property(e => e.CodigoSeccion)
                            .IsRequired()
                            .HasMaxLength(50)
                            .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                           .HasMaxLength(200)
                           .IsUnicode(false);

             
            });

            modelBuilder.Entity<TipoInmueble>(entity =>
            {
                entity.HasKey(e => e.TipoInmuebleId);

                entity.Property(e => e.Nombre)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);


            });

            // **************************** FORMULARIO ************************************************


            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.HasKey(e => e.FormularioId);

                entity.Property(e => e.NumTramite);

                entity.Property(e => e.FechaRecibo)
             .IsRequired()
             .HasColumnName("HoraCierre")
             .HasColumnType("datetime");

                entity.Property(e => e.MotivoId)
                  .HasColumnName("MotivoId");

                entity.HasOne(d => d.Motivo)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.MotivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Formulario_Motivo");

                entity.Property(e => e.SolicitanteId)
                 .HasColumnName("SolicitanteId");

                entity.HasOne(d => d.Solicitante)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.SolicitanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Formulario_Solicitante");

                entity.Property(e => e.PropietarioId)
                 .HasColumnName("PropietarioId");

                entity.HasOne(d => d.Propietario)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.PropietarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Formulario_Propietario");

                entity.Property(e => e.EstablecimientoId)
                 .HasColumnName("EstableciientoId");

                entity.HasOne(d => d.Establecimiento)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.EstablecimientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Formulario_Establecimiento");


            });

            modelBuilder.Entity<Motivo>(entity =>
            {
                entity.HasKey(e => e.MotivoId);

                entity.Property(e => e.Nombre)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);


            });

            // **************************** DATOS DEL SOLICITANTE ************************************************

            modelBuilder.Entity<Solicitante>(entity =>
            {
                entity.HasKey(e => e.SolicitanteId);

                entity.Property(e => e.CedulaJuridica)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);

                entity.Property(e => e.NombreRazonSocial)
                           .IsRequired()
                           .HasMaxLength(100)
                           .IsUnicode(false);

                entity.Property(e => e.TipoRepresentanteId)
                 .HasColumnName("TipoRepresentanteId");

                entity.HasOne(d => d.TipoRepresentante)
                    .WithMany(p => p.Solicitante)
                    .HasForeignKey(d => d.TipoRepresentanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitante_TipoRepresentante");

                entity.Property(e => e.ContactoId)
                 .HasColumnName("ContactoId");

                entity.HasOne(d => d.Contacto)
                    .WithMany(p => p.Solicitante)
                    .HasForeignKey(d => d.ContactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitante_Contacto");

                entity.Property(e => e.PersonaId)
               .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Solicitante)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitante_Persona");


            });

            modelBuilder.Entity<TipoRepresentante>(entity =>
            {
                entity.HasKey(e => e.TipoRepresentanteId);

                entity.Property(e => e.Nombre)
                           .IsRequired()
                           .HasMaxLength(50)
                           .IsUnicode(false);


            });

            // **************************** DATOS DEL PROPIETARIO ************************************************

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.PropietarioId);

                entity.Property(e => e.ContactoId)
                .HasColumnName("ContactoId");

                entity.HasOne(d => d.Contacto)
                    .WithMany(p => p.Propietario)
                    .HasForeignKey(d => d.ContactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Propietario_Contacto");

                entity.Property(e => e.PersonaId)
               .HasColumnName("PersonaId");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Propietario)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Propietario_Persona");

            });

            OnModelCreatingPartial(modelBuilder);

        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
