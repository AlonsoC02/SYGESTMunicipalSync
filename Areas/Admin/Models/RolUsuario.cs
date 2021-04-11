using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class RolUsuario
    {
        public RolUsuario()
        {
            RolUsuarioPag = new HashSet<RolUsuarioPag>();

        }
        [Display(Name = "Rol Usuario Id:")]
        public int RolUsuarioId { get; set; }

        [Display(Name = "Rol Id:")]

        public int RolId { get; set; }
        [Display(Name = "Rol de Usuario:")]
        public virtual Rol Rol { get; set; }

        [Display(Name = "Usuario Id:")]
        public int UsuarioId { get; set; }

        [Display(Name = "Usuario:")]
        public virtual Usuario Usuario { get; set; }

        [Display(Name = "Boton Habilitado:")]
        public bool BotonHabilitado { get; set; }

        public virtual ICollection<RolUsuarioPag> RolUsuarioPag { get; set; }
    }
}

