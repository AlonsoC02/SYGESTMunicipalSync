using SYGESTMunicipalSync.Areas.Admin.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            RolUsuario = new HashSet<RolUsuario>();
            TipoUsuarioPagina = new HashSet<TipoUsuarioPagina>();
        }
        [Display(Name = "Tipo Usuario Id:")]
        public int TipoUsuarioId { get; set; }

        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        public int BotonHabilitado { get; set; }
        public virtual ICollection<TipoUsuarioPagina> TipoUsuarioPagina { get; set; }
        public virtual ICollection<RolUsuario> RolUsuario { get; set; }

        [Display(Name = "Descripcion:")]
        [StringLength(400, ErrorMessage = "Ha excedido los 400 caracteres")]
        [Required(ErrorMessage = "Debe digitar la descripción de la Especialidad")]
        public string Descripcion { get; set; }

        
    }
}
