using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Seccion
    {
        [Display(Name = "Codigo Sección:")]
        [Required(ErrorMessage = "Debe digitar el codigo")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string CodigoSeccion { get; set; }

        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Debe digitar la descripcion")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<Division> Division { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<Clase> Clase { get; set; }
        public Seccion()
        {
            Division = new HashSet<Division>();
        }
    }
}
