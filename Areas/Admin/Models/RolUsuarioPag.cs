using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class RolUsuarioPag
    {
        [Display(Name = "Rol Usuario Página Id:")]
        public int RolUsuarioPagId { get; set; }

        [Display(Name = "Rol Usuario:")]
        public int? RolId { get; set; }
        public virtual Rol Rol { get; set; }

        [Display(Name = "Página Id")]
        public int? PaginaId { get; set; }
        public virtual Pagina Pagina { get; set; }

        [Display(Name = "Boton Habilitado")]
        public bool BotonHabilitado { get; set; }
        public virtual ICollection<RolUsuarioPagBoton> RolUsuarioPagBoton { get; set; }

        public RolUsuarioPag()
        {
            RolUsuarioPagBoton = new HashSet<RolUsuarioPagBoton>();
        }


    }
}
