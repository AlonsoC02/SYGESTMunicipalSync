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
                          join persona in _db.Persona
                        on tipoConsulta.PersonaId equals
                        persona.CedulaPersona

                       
                          select new TipoConsultaViewModel
                          {
                              TipoConsultaId = tipoConsulta.TipoConsultaId,
                              Nombre = tipoConsulta.Nombre,
                              PersonaId = persona.CedulaPersona,
                              Persona= persona.Nombre + " "+ persona.Ape1 + " " +persona.Ape2

                          }).ToList();
            ViewBag.Controlador = "TipoConsulta";
            ViewBag.Accion = "Index";
            return View(listaTipoConsulta);
        }
        private void cargarPersona()
        {
            List<SelectListItem> listaPersona = new List<SelectListItem>();
            listaPersona = (from persona in _db.Persona
                            orderby persona.Nombre
                            select new SelectListItem
                            {
                                Text = persona.Nombre + " " + persona.Ape1 + " " + persona.Ape2,
                                Value = persona.CedulaPersona.ToString()
                            }
                                ).ToList();
            ViewBag.ListaPersona = listaPersona;
        }

        public IActionResult Create()
        {
            cargarPersona();


            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoConsulta tipoConsulta)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.TipoConsulta.Where(m => m.TipoConsultaId == tipoConsulta.TipoConsultaId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este Id ya existe!";
                    cargarPersona();

                }
                else
                {
                    TipoConsulta _tipoConsulta = new TipoConsulta();
                    _tipoConsulta.TipoConsultaId = tipoConsulta.TipoConsultaId;
                    _tipoConsulta.Nombre = tipoConsulta.Nombre;
                    _tipoConsulta.PersonaId = tipoConsulta.PersonaId;
                    
                    _db.TipoConsulta.Add(_tipoConsulta);
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
            cargarPersona();
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
            cargarPersona();
            
            TipoConsulta tipoConsulta = _db.TipoConsulta
                       .Where(e => e.TipoConsultaId == id).First();
            return View(tipoConsulta);
        }
        public IActionResult Delete(int Id)
        {
            cargarPersona();
           

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
