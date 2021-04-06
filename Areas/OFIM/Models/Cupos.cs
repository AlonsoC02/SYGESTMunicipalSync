using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Cupos
    {
        [Display(Name = "Id:")]
        public int CuposId { get; set; }

        [Required(ErrorMessage = "Debe digitar cupo maximo")]
        [Display(Name = "CupoMax:")]
        public int CupoMax { get; set; }

        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripción del cupo")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Actividad:")]
        public int ActividadId { get; set; }
        public virtual Actividad Actividad { get; set; }
    }
}
