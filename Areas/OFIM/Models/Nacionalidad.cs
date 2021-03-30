using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Nacionalidad
    {
        [Display(Name = "Id:")]
        public int NacionalidadId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la nacionalidad")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        public virtual ICollection<PersonaOFIM> PersonaOFIM { get; set; }
        public Nacionalidad()
        {
            PersonaOFIM = new HashSet<PersonaOFIM>();
        }

    }
}
