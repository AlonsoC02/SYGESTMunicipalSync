using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class PuntoRecMaterial
    {
        [Display(Name = "Id:")]
        public int PuntosRecMaterialId { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso")]
        [Display(Name = "Peso:")]
        public float Peso { get; set; }

        [Display(Name = "Material:")]
        public int MaterialId { get; set; }
        public virtual Materiales Materiales { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }

        //[Display(Name = "Lugar:")]
        //[Required(ErrorMessage = "Debe digitar el lugar del punto de recuperacion")]
        //[StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        //public string Lugar { get; set; }

        [Display(Name = "Fecha:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
    }
}
