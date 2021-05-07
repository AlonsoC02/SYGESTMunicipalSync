using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class SeguimientoViewModel
    {
        [Display(Name = "Id:")]
        public int SeguimientoId { get; set; }


        [Display(Name = "Descripcion:")]
        [Required(ErrorMessage = "Debe digitar la descripcion del seguimiento")]
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }


        [Display(Name = "Cedula:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PersonaId { get; set; }
        [Display(Name = "Persona:")]
        public string Persona { get; set; }
        public Seguimiento Seguimiento { get; set; }

        [Display(Name = "Nombre Persona:")]
        public string NombrePersona { get; set; }

        [Display(Name = "Consulta:")]
        public int ConsultaId { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}
