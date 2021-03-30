using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Seguimiento
    {
        [Display(Name = "Seguimiento:")]
        public int SeguimientoId { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripcion del seguimiento")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Respuesta { get; set; }


        [Display(Name = "Persona:")]
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        [Display(Name = "Consulta:")]
        public int ConsultaId { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}
