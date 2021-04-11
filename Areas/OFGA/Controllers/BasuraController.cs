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
    public class BasuraController : Controller
    {

        private readonly DBSygestContext _db;
        List<Basura> listaBasura = new List<Basura>();
        static List<Basura> lista = new List<Basura>();
        static private string _Fecha;
        public BasuraController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaBasura = (from basura in _db.Basura


                               select new Basura
                               {
                                   BasuraId = basura.BasuraId,
                                   Peso = basura.Peso,
                                   Fecha = basura.Fecha


                               }).ToList();
            lista = listaBasura;
            return View(listaBasura);

        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Basura basura)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Basura.Where(m => m.BasuraId == basura.BasuraId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta registro ya existe!";

                    return View(basura);
                }
                else
                {

                    _db.Basura.Add(basura);
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
            Basura oBasura = _db.Basura
                .Where(e => e.BasuraId == Id).FirstOrDefault();
            return View(oBasura);
        }
        [HttpPost]
        public IActionResult Edit(Basura basura)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Fecha = basura.Fecha.ToString("yyyy-MM-dd");
                    _Fecha = ViewBag.Fecha;
                    return View(basura);
                }
                else
                {
                    _db.Basura.Update(basura);
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

            Basura oBasura = _db.Basura
                       .Where(e => e.BasuraId == id).First();
            return View(oBasura);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var basura = await _db.Basura.FindAsync(id);
            if (basura == null)
            {
                return NotFound();

            }
            return View(basura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var basura = await _db.Basura.FindAsync(id);
            if (basura == null)
            {
                return View();
            }
            _db.Basura.Remove(basura);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
