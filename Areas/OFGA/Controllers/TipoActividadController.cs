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
    public class TipoActividadController : Controller
    {
        private readonly DBSygestContext _db;
        List<TipoActividad> listaTipoActividad = new List<TipoActividad>();
        static List<TipoActividad> lista = new List<TipoActividad>();
        
        public TipoActividadController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaTipoActividad = (from tipoActividad in _db.TipoActividad


                           select new TipoActividad
                           {
                               TipoActividadId = tipoActividad.TipoActividadId,
                               Nombre = tipoActividad.Nombre,
                               Descripcion = tipoActividad.Descripcion


                           }).ToList();
            lista = listaTipoActividad;
            return View(listaTipoActividad);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoActividad tipoActividad)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.TipoActividad.Where(m => m.TipoActividadId == tipoActividad.TipoActividadId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta registro ya existe!";

                    return View(tipoActividad);
                }
                else
                {

                    _db.TipoActividad.Add(tipoActividad);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }






        [HttpGet]
        public IActionResult Edit(int Id)
        {
            TipoActividad oTipoActividad = _db.TipoActividad
                .Where(e => e.TipoActividadId == Id).FirstOrDefault();
            return View(oTipoActividad);
        }
        [HttpPost]
        public IActionResult Edit(TipoActividad tipoActividad)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                                    
                    return View(tipoActividad);
                }
                else
                {
                    _db.TipoActividad.Update(tipoActividad);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {

            TipoActividad oTipoActividad = _db.TipoActividad
                       .Where(e => e.TipoActividadId == id).First();
            return View(oTipoActividad);
        }

        //DELETE
        [HttpPost]
        public IActionResult Delete(int? TipoActividadId)
        {
            var Error = "";
            try
            {
                TipoActividad oTipoActividad = _db.TipoActividad
                             .Where(e => e.TipoActividadId == TipoActividadId).First();
                _db.TipoActividad.Remove(oTipoActividad);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
