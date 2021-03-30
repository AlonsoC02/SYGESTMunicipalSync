using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class IngresoVenta
    {
        [Display(Name = "Id:")]
        public int ImgresoVentaId { get; set; }

        [Display(Name = "Material:")]
        public int MaterialId { get; set; }
        public virtual Materiales Materiales { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        //[Required(ErrorMessage = "Debe digitar el precio")]
        //[Display(Name = "Precio:")]
        //public float Precio { get; set; }

        //[Required(ErrorMessage = "Debe digitar el monto")]
        //[Display(Name = "Monto:")]
        //public float Monto { get; set; }

        //[Required(ErrorMessage = "Debe digitar el total")]
        //[Display(Name = "Tatal:")]
        //public float Total { get; set; }


    }
}
