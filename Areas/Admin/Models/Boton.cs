using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Models
{
    public partial class Boton
    {
        public int BotonId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool BotonHabilitado { get; set; }
    }
}
