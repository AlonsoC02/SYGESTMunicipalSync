using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models
{
    public partial class Propietario
    {
        [Display(Name = "ID:")]
        public int PropietarioId { get; set; }

        [Display(Name = "Contacto:")]
        public int ContacotoId { get; set; }
        public virtual Contacto Contacoto { get; set; }

        [Display(Name = "Persona:")]
        public string PersonaId { get; set; }
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public virtual Persona Persona { get; set; }
    }
}
