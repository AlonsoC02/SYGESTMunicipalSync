using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Controllers
{
    //[ServiceFilter(typeof(Seguridad))]
    public class ClasificacionController : Controller
    {
        private readonly DBSygestContext _db;
        List<Clasificacion> listaClasificacion = new List<Clasificacion>();
        static List<Clasificacion> lista = new List<Clasificacion>();
        public ClasificacionController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaClasificacion = (from clasificacion in _db.Clasificacion
                                 select new Clasificacion
                                 {
                                     ClasificacionId = clasificacion.ClasificacionId,
                                     Nombre = clasificacion.Nombre,
                                     Descripcion = clasificacion.Descripcion.Substring(0, 85) + "..."
                                 }).ToList();
            var model = listaClasificacion;
            return View("Index", model);
        }
    }
}
