using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models
{
    public partial class Categoria
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Categoria")]
        [DisplayName("Nombre Categoria")]
        public string Nombre { get; set; }

        public virtual ICollection<Eje> Eje { get; set; }

        public virtual ICollection<Actividad> Actividad { get; set; }
        public Categoria()
        {
            Actividad = new HashSet<Actividad>();
        }
    }
}
