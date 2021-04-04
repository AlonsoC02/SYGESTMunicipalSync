using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Distrito
    {
        [Display(Name = "Id:")]
        public int DistritoId { get; set; }

        [Required(ErrorMessage = "Debe digitar el distrito")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Canton> Canton { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<PuntoRecMaterial> PuntoRecMaterial { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        
        public virtual ICollection<Establecimiento> Establecimiento { get; set; }
        public Distrito()
        {
            Canton = new HashSet<Canton>();
            PuntoRecMaterial = new HashSet<PuntoRecMaterial>();
        }

    }
}
