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
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public Seguro()
        {
            Consulta = new HashSet<Consulta>();
        }

    }
}
