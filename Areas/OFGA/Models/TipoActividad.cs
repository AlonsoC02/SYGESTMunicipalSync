using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class TipoActividad
    {
        [Display(Name = "ID:")]
        public int TipoActividadId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del tipo de la actividad")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción de los tipos de actividad")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

        public TipoActividad()
        {
            Denuncia = new HashSet<Denuncia>();
        }
    }
}
