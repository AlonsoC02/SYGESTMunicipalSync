using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class ProductoServicioViewModel
    {
        public ProductoServicio ProductoServicio { get; set; }  //objeto de Actividad (CRUD)
        public IEnumerable<CatProductoServicio> CatProductoServicio { get; set; }
        public IEnumerable<Empresa> Empresa { get; set; }

    }
}
