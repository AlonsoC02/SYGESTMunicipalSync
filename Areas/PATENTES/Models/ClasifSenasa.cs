using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class ClasifSenasa
    {
        [Display(Name = "ID:")]
        public int ClasifSenasaId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Debe digitar el nombre de la clasificacion de Senasa")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }
    }
}
