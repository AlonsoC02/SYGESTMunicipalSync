using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class TipoConsulta
    {

        [Display(Name = "Tipo Consulta:")]
        public int TipoConsultaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del tipo de consulta")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

  


        public virtual ICollection<Consulta> Consulta { get; set; }
        public TipoConsulta()
        {
            
            Consulta = new HashSet<Consulta>();
        }
    }
}
