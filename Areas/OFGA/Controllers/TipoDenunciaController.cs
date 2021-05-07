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
                                      Descripcion = tipoDenuncia.Descripcion



                                  }).ToList();
            lista = listaTipoDenuncia;
            return View(listaTipoDenuncia);

        }

        private void cargarUltimoRegistro()
        {
            var ultimoRegistro = _db.Set<TipoDenuncia>().OrderByDescending(e => e.TipoDenunciaId).FirstOrDefault();
            if (ultimoRegistro == null)
            {
                ViewBag.ID = 1;

            }
            else
            {
                ViewBag.ID = ultimoRegistro.TipoDenunciaId + 1;
            }
        }

        public IActionResult Create()
        {
            cargarUltimoRegistro();
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
                    cargarUltimoRegistro();
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

        //DELETE
        [HttpPost]
        public IActionResult Delete(int? TipoDenunciaId)
        {
            var Error = "";
            try
            {
                TipoDenuncia oTipoDenuncia = _db.TipoDenuncia
                             .Where(e => e.TipoDenunciaId == TipoDenunciaId).First();
                _db.TipoDenuncia.Remove(oTipoDenuncia);
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
