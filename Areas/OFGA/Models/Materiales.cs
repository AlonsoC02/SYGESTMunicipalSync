using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Materiales
    {
        [Display(Name = "Id:")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del material")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Color")]
        public bool Color { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }


        public virtual ICollection<Pacas> Pacas { get; set; }
        public virtual ICollection<Recuento> Recuento { get; set; }
        public virtual ICollection<PuntoRecMaterial> PuntoRecMaterial { get; set; }
        public virtual ICollection<IngresoVenta> IngresoVenta { get; set; }
        public Materiales()
        {
            Pacas = new HashSet<Pacas>();
            Recuento = new HashSet<Recuento>();
            PuntoRecMaterial = new HashSet<PuntoRecMaterial>();
            IngresoVenta = new HashSet<IngresoVenta>();
        }
    }
}
