using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models.ViewModels
{
    public class MaterialesClasificacionViewModel
    {
        [Required(ErrorMessage = "Debe digitar la Identificación del medico")]
        [Display(Name = "Identificación:")]
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del médico")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Especialidad:")]
        public int ClasificacionId { get; set; }

        public string Clasificacion { get; set; }

        [Display(Name = "Color")]
        public bool Color { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(MaterialesClasificacionViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
