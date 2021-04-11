using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class ActividadViewModel
    {
        public Actividad Actividad { get; set; }  //objeto de Actividad (CRUD)
        public IEnumerable<Categoria> Categoria { get; set; }
        public IEnumerable<Eje> Eje { get; set; }
    }
}
