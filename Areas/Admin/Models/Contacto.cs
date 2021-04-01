using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Contacto
    {
        [Display(Name = "ID:")]
        public int ContactoId { get; set; }

        [Display(Name = "Medio de Notificación:")]
        [Required(ErrorMessage = "Debe digitar el medio para para ser contactado")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string MedioNotificacion { get; set; }


        public virtual ICollection<Quejas> Quejas { get; set; }
        public virtual ICollection<Solicitante> Solicitante { get; set; }
        public virtual ICollection<Propietario> Propietario { get; set; }
        public Contacto()
        {
            Quejas = new HashSet<Quejas>();
            Solicitante = new HashSet<Solicitante>();
            Propietario = new HashSet<Propietario>();
        }
    }
}
