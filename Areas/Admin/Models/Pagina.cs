using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Pagina
    {
        [Display(Name = "Id Página")]
        public int PaginaId { get; set; }

        public string Menu { get; set; }

        [Display(Name = "Nombre de la acción")]
        [Required(ErrorMessage = "Debe escribir un nombre de método de acción")]
        public string Accion { get; set; }

        [Display(Name = "Nombre del contrador")]
        [Required(ErrorMessage = "Debe escribir un nombre de controlador")]
        [MinLength(3, ErrorMessage = "El nombre debe tener una longitud mínima de 3")]
        [MaxLength(100, ErrorMessage = "El nombre debe tener una longitud máxima de 100")]
        public string Controlador { get; set; }

        public int BotonHabilitado { get; set; }

        [Display(Name = "Boton:")]
        public int? BotonId { get; set; }
        public virtual Boton Boton { get; set; }

        public virtual ICollection<TipoUsuarioPag> TipoUsuarioPag { get; set; }
        public Pagina()
        {
            TipoUsuarioPag = new HashSet<TipoUsuarioPag>();

        }
    }
}
