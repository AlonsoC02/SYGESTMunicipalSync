using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class RolUsuario
    {

        [Display(Name = "Rol Usuario Id:")]
        public int TipoUsuarioId { get; set; }

        [Display(Name = "Tipo de Usuario Id:")]
        public int RolId { get; set; }

        [Display(Name = "Tipo de Usuario:")]
        public virtual TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Usuario Id:")]
        public int UsuarioId { get; set; }

        [Display(Name = "Tipo de Usuario:")]
        public virtual Usuario Usuario { get; set; }
    }
}
