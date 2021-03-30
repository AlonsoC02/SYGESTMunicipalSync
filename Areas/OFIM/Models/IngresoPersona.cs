using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class IngresoPersona
    {
        [Display(Name = "Id:")]
        public int IngresoPersonaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el ingreso de persona")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

    }
}
