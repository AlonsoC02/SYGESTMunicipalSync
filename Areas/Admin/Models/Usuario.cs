using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Usuario
    {
        [Display(Name = "Usuario Id:")]
        public int UsuarioId { get; set; }

        [Display(Name = "Nombre usuario:")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Debe digitar la contraseña del usuario")]
        [Display(Name = "Contraseña:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe digitar la confirmacion de la contraseña")]
        [Display(Name = "Confirmar contraseña:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string ConfirmarContrasena { get; set; }

        [Display(Name = "Persona:")]
        public string PersonaId { get; set; }
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public virtual Persona Persona { get; set; }

        public virtual ICollection<RolUsuario> RolUsuario { get; set; }
        public virtual ICollection<Login> Login { get; set; }

        public Usuario()
        {
            RolUsuario = new HashSet<RolUsuario>();
            Login = new HashSet<Login>();
        }
    }
}
