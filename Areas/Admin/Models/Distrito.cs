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
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar el distrito")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Provincia:")]
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }

        [Display(Name = "Canton:")]
        public int CantonId { get; set; }
        public virtual Canton Canton { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<PuntoRecMaterial> PuntoRecMaterial { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        
        public virtual ICollection<Establecimiento> Establecimiento { get; set; }
        public Distrito()
        {
            
            PuntoRecMaterial = new HashSet<PuntoRecMaterial>();
        }

    }
}
