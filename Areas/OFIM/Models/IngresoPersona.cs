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
        [Display(Name = "Ingreso mensual:")]
        public string IngresoMensual { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }

        public IngresoPersona()
        {
            Consulta = new HashSet<Consulta>();
        }

    }
}
