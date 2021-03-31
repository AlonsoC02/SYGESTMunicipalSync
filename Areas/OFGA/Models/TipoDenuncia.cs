using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Models
{
    public partial class TipoDenuncia
    {
        [Display(Name = "ID:")]
        public int TipoDenunciaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el nombre del tipo de la denuncia")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }
    }
}
