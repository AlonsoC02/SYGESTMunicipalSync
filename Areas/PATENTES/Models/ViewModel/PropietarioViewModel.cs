using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models.ViewModel
{
    public class PropietarioViewModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int PropietarioId { get; set; }

        [Display(Name = "Contacto:")]
        public int ContactoId { get; set; }
        public string Contacto { get; set; }

        [Display(Name = "Cédula o Pasaporte:")]
        public string PersonaId { get; set; }
        [Display(Name = "Nombre Persona:")]
        public string NombrePersona { get; set; }

        public string msgError { get; set; }

        public static implicit operator List<object>(PropietarioViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
