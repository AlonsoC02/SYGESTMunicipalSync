using SYGESTMunicipalSync.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Models.ViewModel
{
    public class EstablecimientoViewModel
    {
        public Establecimiento Establecimiento { get; set; }  //objeto de ProductItem (CRUD)
        public IEnumerable<Clase> Clase { get; set; }
        public IEnumerable<Provincia> Provincia { get; set; }   //combo categoria
        public IEnumerable<Canton> Canton { get; set; }     //combo todos los datos prod
        public IEnumerable<Distrito> Distrito { get; set; }
    }
}
