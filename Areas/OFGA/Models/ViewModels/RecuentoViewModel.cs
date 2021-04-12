using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models.ViewModels
{
    public class RecuentoViewModel
    {

        [Key]
        [Display(Name = "Recuento Id: ")]
        public int RecuentoId { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso global")]
        [Display(Name = "Peso global: ")]
        public float PesoGlobal { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha:")]
        public DateTime? FechaPeso { get; set; }

        [Display(Name = "Materiales:")]
        public int MaterialId { get; set; }
        public string Materiales { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public string Clasificacion { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(RecuentoViewModel v)
        {
            throw new NotImplementedException();
        }

    }
}
