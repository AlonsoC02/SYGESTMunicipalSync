using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class EstadoCivil
    {
        [Display(Name = "Id:")]
        public int EstadoCivilId { get; set; }

        [Required(ErrorMessage = "Debe digitar el estado civil")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public EstadoCivil()
        {
            Consulta = new HashSet<Consulta>();
        }

    }
}
