using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class TipoConsultaViewModel
    {
        [Required(ErrorMessage = "Debe digitar la Identificación del medico")]
        [Display(Name = "Id:")]
        public int TipoConsultaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del médico")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Persona:")]
        public string PersonaId { get; set; }

        public string Persona { get; set; }

     
        public string msgError { get; set; }

        public static implicit operator List<object>(TipoConsultaViewModel v)
        {
            throw new NotImplementedException();
        }

    }
}
