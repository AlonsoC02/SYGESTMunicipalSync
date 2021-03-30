using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Seguro
    {
        [Display(Name = "Id:")]
        public int SeguroId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del seguro")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        public virtual ICollection<PersonaOFIM> PersonaOFIM { get; set; }
        public Seguro()
        {
            PersonaOFIM = new HashSet<PersonaOFIM>();
        }

    }
}
