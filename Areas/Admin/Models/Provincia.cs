using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models;
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
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Provincia")]
        [Display(Name = "Nombre:")]
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }

       
        public virtual ICollection<Canton> Canton { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        public virtual ICollection<Establecimiento> Establecimiento { get; set; }
        public Provincia()
        {
            Persona = new HashSet<Persona>();
            Establecimiento = new HashSet<Establecimiento>();
        }
    }
}
