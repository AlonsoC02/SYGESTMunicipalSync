using SYGESTMunicipalSync.Areas.OFGA.Models;
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

        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar la contraseña del usuario")]
        [Display(Name = "Contraseña:")]
        public string Password { get; set; }

        [Display(Name = "Tipo de Usuario Id:")]
        public int TipoUsuarioId { get; set; }

        [Display(Name = "Tipo de Usuario:")]
        public virtual TipoUsuario TipoUsuario { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

        public Usuario()
        {
            Denuncia = new HashSet<Denuncia>();
        }
    }
}
