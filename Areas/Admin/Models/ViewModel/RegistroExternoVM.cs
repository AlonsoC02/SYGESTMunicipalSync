using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models.ViewModel
{
    public class RegistroExternoVM
    {
        [Required(ErrorMessage = "Debe digitar el ID de la Persona")]
        [Display(Name = "Cédula o Pasaporte:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string CedulaPersona { get; set; }

        [Display(Name = "Usuario Id:")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Persona")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Nombre usuario:")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Debe digitar el primer Apellido de la Persona")]
        [Display(Name = "Primer Apellido:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Ape1 { get; set; }

        [Required(ErrorMessage = "Debe digitar el segundo Apellido de la Persona")]
        [Display(Name = "Segundo Apellido:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Ape2 { get; set; }

        [Display(Name = "Fecha Nacimiento:")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNac { get; set; }

        [Display(Name = "Correo Electronico:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico válido")]
        public string Email { get; set; }

        [Display(Name = "Sexo:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un sexo valido")]
        public char Sexo { get; set; }

        [Display(Name = "Telefono Movil:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un teléfono valido")]
        public int TelMovil { get; set; }

        [Display(Name = "Telefono Fijo:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un teléfono valido")]
        public int TelFijo { get; set; }

        [Display(Name = "Fax:")]
        [EmailAddress(ErrorMessage = "Debe ingresar un fax valido")]
        public int Fax { get; set; }

        [Display(Name = "Dirección:")]
        [Required(ErrorMessage = "Debe digitar la dirección valida")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }

        [Display(Name = "Canton:")]
        public int CantonId { get; set; }
        public virtual Canton Canton { get; set; }

        [Display(Name = "Provincia:")]
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
      
        [Required(ErrorMessage = "Debe digitar la contraseña del usuario")]
        [Display(Name = "Contraseña:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe digitar la confirmacion de la contraseña")]
        [Display(Name = "Confirmar contraseña:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string ConfirmarContrasena { get; set; }

        [Display(Name = "Rol Usuario Id:")]
        public int RolUsuarioId { get; set; }

        [Display(Name = "Rol Id:")]

        public int RolId { get; set; }
        [Display(Name = "Rol de Usuario:")]
        public virtual Rol Rol { get; set; }

        [Display(Name = "Boton Habilitado:")]
        public bool BotonHabilitado { get; set; }
    }
}
