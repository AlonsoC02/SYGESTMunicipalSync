using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models.ViewModels
{
    public class PuntoRecMaterialMaterialesClasificacionViewModel
    {
        [Required(ErrorMessage = "Debe digitar la Identificación del medico")]
        [Display(Name = "Identificación:")]
        public int PuntosRecMaterialId { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso")]
        [Display(Name = "Peso:")]
        public float Peso { get; set; }

        [Display(Name = "Material:")]
        public int MaterialId { get; set; }

        public string Material { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }

        public string Clasificacion { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }

        public string Distrito { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de entrada ")]
        public DateTime? Fecha { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(PuntoRecMaterialMaterialesClasificacionViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
