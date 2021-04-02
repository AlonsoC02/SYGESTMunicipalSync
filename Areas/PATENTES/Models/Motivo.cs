using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Motivo
    {
        [Display(Name = "ID:")]
        public int MotivoId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Debe digitar el motivo")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Formulario> Formulario { get; set; }
        public Motivo()
        {
            Formulario = new HashSet<Formulario>();
        }
    }
}
