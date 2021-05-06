using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class NivelAcademico
    {
        [Display(Name = "Id:")]
        public int NivelAcademicoId { get; set; }

        [Required(ErrorMessage = "Debe digitar el grado de nivel academico")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }


        public virtual ICollection<Consulta> Consulta { get; set; }
        public NivelAcademico()
        {
            Consulta = new HashSet<Consulta>();
        }
    }
}
