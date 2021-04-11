using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel
{
    public class EjeAndCategoriaViewModel
    {
        public IEnumerable<Categoria> CategoriaList { get; set; }
        public Eje Eje { get; set; }
        public List<string> EjeList { get; set; }
        public string StatusMessage { get; set; }
    }
}
