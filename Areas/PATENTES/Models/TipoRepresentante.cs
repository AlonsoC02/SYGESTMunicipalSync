using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class TipoRepresentante
    {
        [Display(Name = "ID:")]
        public int TipoRepresentanteId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Debe digitar el nombre del tipo de representante")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Solicitante> Solicitante { get; set; }
        public TipoRepresentante()
        {
            Solicitante = new HashSet<Solicitante>();
        }
    }
}
