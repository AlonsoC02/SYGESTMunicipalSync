using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class TipoInmueble
    {
        [Display(Name = "ID:")]
        public int TipoInmuebleId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Debe digitar el nombre del tipo de inmueble")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }
    }
}
