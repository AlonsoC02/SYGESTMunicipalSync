using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class Recuento
    {
        [Display(Name = "Id:")]
        public int RecuentoId { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }

        [Display(Name = "Material:")]
        public int MaterialId { get; set; }
        public virtual Materiales Materiales { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso global")]
        [Display(Name = "Peso Global:")]
        public float PesoGlobal { get; set; }
    }
}
