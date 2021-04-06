using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class TipoUsuarioPag
    {
        [Display(Name = "Tipo Usuario Página Id:")]
        public int TipoUsuarioPagId { get; set; }

        [Display(Name = "Tipo Usuario:")]
        public int? TipoUsuarioId { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Página Id")]
        public int? PaginaId { get; set; }
        public virtual Pagina Pagina { get; set; }

        [Display(Name = "Boton Habilitado")]
        public bool BotonHabilitado { get; set; }

        public virtual ICollection<RolUsuario> RolUsuario { get; set; }
        public virtual ICollection<TipoUsuarioPagBoton> TipoUsuarioPagBoton { get; set; }

        public TipoUsuarioPag()
        {
            RolUsuario = new HashSet<RolUsuario>();
            TipoUsuarioPagBoton = new HashSet<TipoUsuarioPagBoton>();
        }


    }
}
