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
    public class SeguimientoController : Controller
    {
        private readonly DBSygestContext _db;
        List<SeguimientoViewModel> listaSeguimiento = new List<SeguimientoViewModel>();
        static List<SeguimientoViewModel> lista = new List<SeguimientoViewModel>();
        public SeguimientoController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaSeguimiento = (from seguimiento in _db.Seguimiento
                             join persona in _db.Persona
                           on seguimiento.PersonaId equals
                           persona.CedulaPersona

                             join consulta in _db.Consulta
                         on seguimiento.ConsultaId equals
                         consulta.ConsultaId




                             select new SeguimientoViewModel
                             {
                                 SeguimientoId = seguimiento.SeguimientoId,                               
                                 ConsultaId = consulta.ConsultaId,                                
                                 PersonaId = persona.CedulaPersona,
                                 Persona = persona.Nombre + " " + persona.Ape1 + " " + persona.Ape2


                             }).ToList();
            ViewBag.Controlador = "Seguimiento";
            ViewBag.Accion = "Index";
            return View(listaSeguimiento);
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

        private void cargarConsulta()
        {
            List<SelectListItem> listaConsulta = new List<SelectListItem>();
            listaConsulta = (from consulta in _db.Consulta
                                 orderby consulta.Motivo
                                 select new SelectListItem
                                 {
                                     Text = consulta.Motivo,
                                     Value = consulta.ConsultaId.ToString()
                                 }
                                ).ToList();
            ViewBag.ListaConsulta = listaConsulta;
        }


        public IActionResult Create()
        {
            cargarPersona();
            cargarConsulta();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seguimiento seguimiento)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Seguimiento.Where(m => m.SeguimientoId == seguimiento.SeguimientoId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este Id ya existe!";
                    cargarPersona();
                    cargarConsulta();
                }
                else
                {
                    Seguimiento _seguimiento = new Seguimiento();
                    _seguimiento.ConsultaId = seguimiento.ConsultaId;
                    _seguimiento.Descripcion = seguimiento.Descripcion;
                    _seguimiento.PersonaId = seguimiento.PersonaId;
                    _seguimiento.ConsultaId = seguimiento.ConsultaId;
                   


                    _db.Seguimiento.Add(_seguimiento);
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
            cargarConsulta(); 

            Seguimiento oSeguimiento = _db.Seguimiento
                .Where(e => e.SeguimientoId == Id).FirstOrDefault();
            return View(oSeguimiento);
        }
        [HttpPost]
        public IActionResult Edit(Seguimiento seguimiento)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(seguimiento);
                }
                else
                {
                    _db.Seguimiento.Update(seguimiento);
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
            cargarConsulta();

            Seguimiento seguimiento = _db.Seguimiento
                       .Where(e => e.SeguimientoId == id).First();
            return View(seguimiento);
        }
        public IActionResult Delete(int Id)
        {
            cargarPersona();
            cargarConsulta();

            Seguimiento oSeguimiento = _db.Seguimiento
                 .Where(m => m.SeguimientoId == Id).First();
            return View(oSeguimiento);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int SeguimientoId)
        {
            string Error = "";
            try
            {
                Seguimiento oSeguimiento = _db.Seguimiento
                     .Where(c => c.SeguimientoId == SeguimientoId).First();
                if (oSeguimiento != null)
                {
                    _db.Seguimiento.Remove(oSeguimiento);
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
