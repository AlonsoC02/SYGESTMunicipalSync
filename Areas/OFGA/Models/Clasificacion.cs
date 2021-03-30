using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Clasificacion
    {
        [Display(Name = "Id:")]
        public int ClasificacionId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre de la clasificacion")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción de la clasificacion")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<Materiales> Materiales { get; set; }
        public virtual ICollection<Pacas> Pacas { get; set; }
        public virtual ICollection<Recuento> Recuento { get; set; }
        public virtual ICollection<PuntoRecMaterial> PuntoRecMaterial { get; set; }
        public virtual ICollection<IngresoVenta> IngresoVenta { get; set; }
        public Clasificacion()
        {
            Materiales = new HashSet<Materiales>();
        }
    }
}
