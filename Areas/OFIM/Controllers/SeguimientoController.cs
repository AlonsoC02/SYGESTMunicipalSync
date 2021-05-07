using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                           persona.Id

                                join consulta in _db.Consulta
                         on seguimiento.ConsultaId equals
                         consulta.ConsultaId




                             select new SeguimientoViewModel
                             {
                                 SeguimientoId = seguimiento.SeguimientoId,                               
                                 ConsultaId = consulta.ConsultaId,                                
                                 PersonaId = persona.Id,
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
                                Value = persona.Id.ToString()
                            }
                                ).ToList();
            ViewBag.ListaPersona = listaPersona;
        }

        private void cargarConsulta()
        {
            List<SelectListItem> listaConsulta = new List<SelectListItem>();
            listaConsulta = (from consulta in _db.Consulta
                            orderby consulta.Motivo
                            join tipoConsulta in _db.TipoConsulta
                            on consulta.TipoConsultaId equals tipoConsulta.TipoConsultaId
                            select new SelectListItem
                            {
                                Text = consulta.Motivo + " - " + tipoConsulta.Nombre,
                                Value = consulta.ConsultaId.ToString()
                            }
                                   ).ToList();
            ViewBag.ListaConsulta = listaConsulta;
        }

        private void Buscar(string PersonaId)
        {
            Persona oPersona = _db.Persona
          .Where(p => p.Id == PersonaId).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonaID = oPersona.Id;
                ViewBag.NombrePersona = oPersona.Nombre + " " + oPersona.Ape1 + " " + oPersona.Ape2;
            }
            else
            {
                ViewBag.Error = "Persona no registrada, intente de nuevo!";
            }
        }


        [ActionName("GetConsulta")]
        public async Task<IActionResult> GetConsulta(string id)
        {
            List<Consulta> persona = new List<Consulta>();
            persona = await (from Consulta in _db.Consulta
                              where Consulta.PersonaId == id
                              select Consulta).ToListAsync();
            return Json(new SelectList(persona, "Id", "Nombre"));
        }

        public IActionResult Create(string PersonaId)
        {
            //cargarPersona();
            //cargarConsulta();

            if (PersonaId != null)
            {
                Buscar(PersonaId);
            }
            ViewBag.Controlador = "Seguimiento";
            ViewBag.Accion = "Create";
            return View();
        }

        public async Task<IActionResult> Created(Seguimiento seguimiento)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(seguimiento);
                }
                else
                {

                    Seguimiento _seguimiento = new Seguimiento();

                   
                    _seguimiento.SeguimientoId = seguimiento.SeguimientoId;
                    _seguimiento.Descripcion = seguimiento.Descripcion;
                    _seguimiento.ConsultaId = seguimiento.ConsultaId;
                    _seguimiento.PersonaId = seguimiento.PersonaId;
                   
                    _db.Seguimiento.Add(_seguimiento);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
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
