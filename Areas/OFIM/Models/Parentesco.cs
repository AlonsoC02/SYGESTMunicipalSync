using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Parentesco
    {
        [Display(Name = "Id:")]
        public int ParentescoId { get; set; }

        [Required(ErrorMessage = "Debe digitar el parentesco")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Familia> Familia { get; set; }
        public Parentesco()
        {
            Familia = new HashSet<Familia>();
        }

    }
}
