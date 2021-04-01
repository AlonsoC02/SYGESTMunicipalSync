using SYGESTMunicipalSync.Areas.OFGA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Provincia
    {
        [Display(Name = "Id:")]
        public int ProvinciaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Provincia")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Canton:")]
        public int CantonId { get; set; }
        public virtual Canton Canton { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        public Provincia()
        {
            Persona = new HashSet<Persona>();
            Denuncia = new HashSet<Denuncia>();
        }
    }
}
