using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Controllers
{
    [Area("OFGA")]
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
            lista = listaClasificacion;
            return View(listaClasificacion);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Clasificacion materialType)
        {
            int nVeces = 0;
            string Error = "";
            try
            {
                nVeces = _db.Clasificacion.Where(e =>
                                       e.Nombre == materialType.Nombre).Count();

                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces > 1) ViewBag.msgError = "El nombre de la persona" +
                              " ya está registrado";

                    return View(materialType);
                }
                else
                {
                    _db.Clasificacion.Add(materialType);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        //Apartir de aca todo nuevo
        public IActionResult Details(int id)
        {
            Clasificacion oEspecialidad = _db.Clasificacion
                         .Where(e => e.ClasificacionId == id).First();
            return View(oEspecialidad);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Clasificacion oEspecialidad = _db.Clasificacion
                         .Where(e => e.ClasificacionId == id).First();
            return View(oEspecialidad); ;
        }

        [HttpPost]
        public IActionResult Edit(Clasificacion especialidad)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(especialidad);
                }
                else
                {
                    Clasificacion _especialidad = new Clasificacion
                    {
                        ClasificacionId = especialidad.ClasificacionId,
                        Nombre = especialidad.Nombre,
                        Descripcion = especialidad.Descripcion
                    };
                    _db.Clasificacion.Update(_especialidad);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var category = await _db.Clasificacion.FindAsync(id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var category = await _db.Clasificacion.FindAsync(id);
            if (category == null)
            {
                return View();
            }
            _db.Clasificacion.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
