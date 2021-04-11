using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models.ViewModels
{
    public class PacasViewModel
    {
        [Key]        
        [Display(Name = "Paca Id: ")]
        public int PacaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el peso")]
        [Display(Name = "Peso: ")]
        public float Peso { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha:")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Materiales:")]
        public int MaterialId { get; set; }
        public string Materiales { get; set; }

        [Display(Name = "Clasificacion:")]
        public int ClasificacionId { get; set; }
        public string Clasificacion { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(PacasViewModel v)
        {
            throw new NotImplementedException();
        }

    }
}
