using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Division
    {
        [Display(Name = "Codigo División:")]
        [Required(ErrorMessage = "Debe digitar el codigo")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string CodigoDivision { get; set; }

        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Debe digitar la descripcion")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Sección:")]
        public string SeccionId { get; set; }
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public virtual Seccion Seccion { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<Clase> Clase { get; set; }
        public Division()
        {
            Grupo = new HashSet<Grupo>();
        }
    }
}
