using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Familia
    {

        [Display(Name = "Id:")]
        public int FamiliaId { get; set; }

        [Display(Name = "Persona 1:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PersonaId1 { get; set; }
        public virtual Persona Persona1 { get; set; }

        [Display(Name = "Persona 2:")]
        [StringLength(100, ErrorMessage = "Ha excedido los 100 caracteres")]
        public string PersonaId2 { get; set; }
        public virtual Persona Persona2 { get; set; }

        [Display(Name = "Parentesco:")]
        public int ParentescoId { get; set; }
        public virtual Parentesco Parentesco { get; set; }

    }
}
