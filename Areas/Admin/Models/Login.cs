using SYGESTMunicipalSync.Areas.OFGA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Login
    {
        [Display(Name = "Nombre de usuario:")]
        public int LoginId { get; set; }

        [Display(Name = "Nombre de usuario:")]
        public int NombreUsuarioId { get; set; }
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Debe digitar la contraseña")]
        [Display(Name = "Contraseña:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Password { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

        public Login()
        {
            
            Denuncia = new HashSet<Denuncia>();
        }
    }
}
