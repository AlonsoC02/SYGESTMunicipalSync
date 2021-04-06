using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Boton
    {
        public int BotonId { get; set; }
        [StringLength(50, ErrorMessage = "Ha excedido los 50 caracteres")]
        public string Nombre { get; set; }
        [StringLength(200, ErrorMessage = "Ha excedido los 200 caracteres")]
        public string Descripcion { get; set; }
        public bool BotonHabilitado { get; set; }

        public virtual ICollection<TipoUsuarioPagBoton> TipoUsuarioPagBoton { get; set; }
        public virtual ICollection<Pagina> Pagina { get; set; }
        public Boton()
        {
            TipoUsuarioPagBoton = new HashSet<TipoUsuarioPagBoton>();
            Pagina = new HashSet<Pagina>();
        }
    }
}
