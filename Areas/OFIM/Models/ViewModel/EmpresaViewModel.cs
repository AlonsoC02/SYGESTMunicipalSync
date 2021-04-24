using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class EmpresaViewModel
    {

        public Empresa Empresa { get; set; }  //objeto de Actividad (CRUD)
        public IEnumerable<Persona> Persona { get; set; }
        public IEnumerable<CatProductoServicio> CatProductoServicio { get; set; }
    }
}
