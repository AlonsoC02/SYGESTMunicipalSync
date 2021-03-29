using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Eje
    {
        public int EjeId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del Eje")]
        [DisplayName("Nombre Eje")]
        public string Nombre { get; set; }

        [Display(Name = "Categoria Id: ")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
