using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Distrito
    {
        [Display(Name = "Id:")]
        public int DistritoId { get; set; }

        [Required(ErrorMessage = "Debe digitar el distrito")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Canton> Canton { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public Distrito()
        {
            Canton = new HashSet<Canton>();
        }

    }
}
