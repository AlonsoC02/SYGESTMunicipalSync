using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Canton
    {
        [Display(Name = "Id:")]
        public int CantonId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del Canton")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Display(Name = "Distrito:")]
        public int DistritoId { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
        public Canton()
        {
            Provincia = new HashSet<Provincia>();
        }
    }
}
