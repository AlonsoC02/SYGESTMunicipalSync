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
    public class TipoDenunciaController : Controller
    {
        private readonly DBSygestContext _db;
        List<TipoDenuncia> listaTipoDenuncia = new List<TipoDenuncia>();
        static List<TipoDenuncia> lista = new List<TipoDenuncia>();

        public TipoDenunciaController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaTipoDenuncia = (from tipoDenuncia in _db.TipoDenuncia


                                  select new TipoDenuncia
                                  {
                                      TipoDenunciaId = tipoDenuncia.TipoDenunciaId,
                                      Nombre = tipoDenuncia.Nombre,
                                     


                                  }).ToList();
            lista = listaTipoDenuncia;
            return View(listaTipoDenuncia);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoDenuncia tipoDenuncia)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.TipoDenuncia.Where(m => m.TipoDenunciaId == tipoDenuncia.TipoDenunciaId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta registro ya existe!";

                    return View(tipoDenuncia);
                }
                else
                {

                    _db.TipoDenuncia.Add(tipoDenuncia);
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
            TipoDenuncia oTipoDenuncia = _db.TipoDenuncia
                .Where(e => e.TipoDenunciaId == Id).FirstOrDefault();
            return View(oTipoDenuncia);
        }
        [HttpPost]
        public IActionResult Edit(TipoDenuncia tipoDenuncia)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(tipoDenuncia);
                }
                else
                {
                    _db.TipoDenuncia.Update(tipoDenuncia);
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

            TipoDenuncia oTipoDenuncia = _db.TipoDenuncia
                       .Where(e => e.TipoDenunciaId == id).First();
            return View(oTipoDenuncia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var tipoDenuncia = await _db.TipoDenuncia.FindAsync(id);
            if (tipoDenuncia == null)
            {
                return NotFound();

            }
            return View(tipoDenuncia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tipoDenuncia = await _db.TipoDenuncia.FindAsync(id);
            if (tipoDenuncia == null)
            {
                return View();
            }
            _db.TipoDenuncia.Remove(tipoDenuncia);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
