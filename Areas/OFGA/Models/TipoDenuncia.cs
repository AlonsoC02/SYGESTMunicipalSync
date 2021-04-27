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
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción:")]
        [StringLength(200, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string Descripcion { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

        public TipoDenuncia()
        {
            Denuncia = new HashSet<Denuncia>();
        }
    }
}
