using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{

    [Area("OFIM")]
    public class TipoConsultaController : Controller
    {
        private readonly DBSygestContext _db;
        List<TipoConsultaViewModel> listaTipoConsulta = new List<TipoConsultaViewModel>();
        static List<TipoConsultaViewModel> lista = new List<TipoConsultaViewModel>();
        public TipoConsultaController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaTipoConsulta = (from tipoConsulta in _db.TipoConsulta


                                        select new TipoConsultaViewModel
                                        {
                                            TipoConsultaId = tipoConsulta.TipoConsultaId,
                                            Nombre = tipoConsulta.Nombre,
                                      


                                        }).ToList();
            lista = listaTipoConsulta;
            return View(listaTipoConsulta);

        }
        private void cargarUltimoRegistro()
        {
            var ultimoRegistro = _db.Set<TipoConsulta>().OrderByDescending(
                e => e.TipoConsultaId).FirstOrDefault();
            if (ultimoRegistro == null)
            {
                ViewBag.ID = 1;

            }
            else
            {
                ViewBag.ID = ultimoRegistro.TipoConsultaId + 1;
            }
        }
       
        public IActionResult Create()
        {
            cargarUltimoRegistro();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoConsulta tipoConsulta)
        {
            int nVeces = 0;
            
            try
            {
                nVeces = _db.TipoConsulta.Where(m => 
                m.Nombre == tipoConsulta.Nombre).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este Id ya existe!";

                    return View(tipoConsulta);
                }
                else
                {
                    _db.TipoConsulta.Add(tipoConsulta);
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
           
            TipoConsulta oTipoConsulta = _db.TipoConsulta
                .Where(e => e.TipoConsultaId == Id).FirstOrDefault();
            return View(oTipoConsulta);
        }
        [HttpPost]
        public IActionResult Edit(TipoConsulta tipoConsulta)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                   
                    return View(tipoConsulta);
                }
                else
                {
                    _db.TipoConsulta.Update(tipoConsulta);
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
           
            
            TipoConsulta tipoConsulta = _db.TipoConsulta
                       .Where(e => e.TipoConsultaId == id).First();
            return View(tipoConsulta);
        }
        public IActionResult Delete(int Id)
        {
          
           

            TipoConsulta oTipoConsulta = _db.TipoConsulta
                 .Where(m => m.TipoConsultaId == Id).First();
            return View(oTipoConsulta);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int TipoConsultaId)
        {
            string Error = "";
            try
            {
                TipoConsulta oTipoConsulta = _db.TipoConsulta
                     .Where(c => c.TipoConsultaId == TipoConsultaId).First();
                if (oTipoConsulta != null)
                {
                    _db.TipoConsulta.Remove(oTipoConsulta);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }


    
}
}
