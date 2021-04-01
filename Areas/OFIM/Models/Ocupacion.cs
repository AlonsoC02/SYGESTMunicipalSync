using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Ocupacion
    {
        [Display(Name = "Id:")]
        public int OcupacionId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Ocupacion")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<PersonaOFIM> PersonaOFIM { get; set; }
        public Ocupacion()
        {
            PersonaOFIM = new HashSet<PersonaOFIM>();
        }

    }
}
