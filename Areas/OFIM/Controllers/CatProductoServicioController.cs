using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class CatProductoServicioController : Controller
    {
        private readonly DBSygestContext _db;
        List<CatProductoServicio> listaCatProductoServicio = new List<CatProductoServicio>();
        static List<CatProductoServicio> lista = new List<CatProductoServicio>();

        public CatProductoServicioController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaCatProductoServicio = (from catProductoServicio in _db.CatProductoServicio


                                  select new CatProductoServicio
                                  {
                                      CatProductoServicioId = catProductoServicio.CatProductoServicioId,
                                      Nombre = catProductoServicio.Nombre,
                                      Descripcion = catProductoServicio.Descripcion


                                  }).ToList();
            lista = listaCatProductoServicio;
            return View(listaCatProductoServicio);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CatProductoServicio catProductoServicio)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.CatProductoServicio.Where(m => m.CatProductoServicioId == catProductoServicio.CatProductoServicioId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta registro ya existe!";

                    return View(catProductoServicio);
                }
                else
                {

                    _db.CatProductoServicio.Add(catProductoServicio);
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
            CatProductoServicio oCatProductoServicio = _db.CatProductoServicio
                .Where(e => e.CatProductoServicioId == Id).FirstOrDefault();
            return View(oCatProductoServicio);
        }
        [HttpPost]
        public IActionResult Edit(CatProductoServicio catProductoServicio)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(catProductoServicio);
                }
                else
                {
                    _db.CatProductoServicio.Update(catProductoServicio);
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

            CatProductoServicio oCatProductoServicio = _db.CatProductoServicio
                       .Where(e => e.CatProductoServicioId == id).First();
            return View(oCatProductoServicio);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var catProductoServicio = await _db.CatProductoServicio.FindAsync(id);
            if (catProductoServicio == null)
            {
                return NotFound();

            }
            return View(catProductoServicio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var catProductoServicio = await _db.CatProductoServicio.FindAsync(id);
            if (catProductoServicio == null)
            {
                return View();
            }
            _db.CatProductoServicio.Remove(catProductoServicio);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
