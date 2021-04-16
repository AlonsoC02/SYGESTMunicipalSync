using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class EmpresaAndProdServicioViewModel
    {
        public IEnumerable<CatProductoServicio> CatProductoServicioList { get; set; }
        public Empresa Empresa { get; set; }
        public List<string> EmpresaList { get; set; }
        public string StatusMessage { get; set; }

    }
}
