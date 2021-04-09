using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.Admin.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonaController : Controller
    {
        List<PersonaViewModel> listaPersonas = new List<PersonaViewModel>();
        static List<PersonaViewModel> lista = new List<PersonaViewModel>();

        private readonly DBSygestContext _db;
        public PersonaController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaPersonas = (from persona in _db.Persona
                             join distrito in _db.Distrito
                             on persona.DistritoId equals
                             distrito.DistritoId

                             join canton in _db.Canton
                             on persona.CantonId equals
                             canton.CantonId

                             join provincia in _db.Provincia
                             on persona.ProvinciaId equals
                             provincia.ProvinciaId

                             select new PersonaViewModel
                             {
                                 CedulaPersona = persona.CedulaPersona,
                                 Nombre = persona.Nombre + " " +
                                 persona.Ape1 + " " +
                                 persona.Ape2,
                                 Email = persona.Email,
                                 TelMovil= persona.TelMovil,
                                 DistritoId = distrito.DistritoId,
                                 CantonId = canton.CantonId,
                                 ProvinciaId = provincia.ProvinciaId
                             }).ToList();
            ViewBag.Controlador = "Persona";
            ViewBag.Accion = "Index";
            return View(listaPersonas);
        }
        private void cargarDistrito()
        {
            List<SelectListItem> listaDistrito = new List<SelectListItem>();
            listaDistrito = (from distrito in _db.Distrito
                                orderby distrito.Nombre
                                select new SelectListItem
                                {
                                    Text = distrito.Nombre,
                                    Value = distrito.DistritoId.ToString()
                                }
                                ).ToList();
            ViewBag.ListaDistrito = listaDistrito;
        }

        private void cargarCanton()
        {
            List<SelectListItem> listaCanton = new List<SelectListItem>();
            listaCanton = (from canton in _db.Canton
                              orderby canton.CantonId
                              select new SelectListItem
                              {
                                  Text = canton.Nombre,
                                  Value = canton.CantonId.ToString()
                              }
                                ).ToList();
            ViewBag.ListaCanton = listaCanton;
        }

        private void cargarProvincia()
        {
            List<SelectListItem> listaProvincia = new List<SelectListItem>();
            listaProvincia = (from provincia in _db.Provincia
                                 orderby provincia.Nombre
                                 select new SelectListItem
                                 {
                                     Text = provincia.Nombre,
                                     Value = provincia.ProvinciaId.ToString()
                                 }
                                ).ToList();
            ViewBag.ListaProvincia = listaProvincia;
        }

        
        public IActionResult Create()
        {
            cargarDistrito();
            cargarCanton();
            cargarProvincia();
            

            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Persona.Where(m => m.CedulaPersona == persona.CedulaPersona).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta cédula de persona ya existe!";
                    cargarDistrito();
                    cargarCanton();
                    cargarProvincia();
                    return View(persona);
                }
                else
                {
                    Persona _persona = new Persona();
                    _persona.CedulaPersona = persona.CedulaPersona;
                    _persona.Nombre = persona.Nombre;
                    _persona.Ape1 = persona.Ape1;
                    _persona.Ape2 = persona.Ape2;
                    _persona.FechaNac = persona.FechaNac;
                    _persona.Email = persona.Email;
                    _persona.Sexo = persona.Sexo; 
                    _persona.TelMovil = persona.TelMovil;
                    _persona.TelFijo = persona.TelFijo;
                    _persona.Fax = persona.Fax;
                    _persona.Direccion = persona.Direccion;

                    _persona.CantonId = persona.CantonId;
                    _persona.DistritoId = persona.DistritoId;
                    _persona.ProvinciaId = persona.ProvinciaId;

                   
                    _db.Persona.Add(_persona);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id)
        {
            cargarDistrito();
            cargarCanton();
            cargarProvincia();
            int recCount = _db.Persona.Count(e => e.CedulaPersona == id);
            Persona _persona = (from p in _db.Persona
                                        where p.CedulaPersona == id
                                        select p).DefaultIfEmpty().Single();
            return View(_persona);
        }
        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarDistrito();
                    cargarCanton();
                    cargarProvincia();
                    return View(persona);
                }
                else
                {
                    _db.Persona.Update(persona);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(string id)
        {
            cargarDistrito();
            cargarCanton();
            cargarProvincia();
            Persona persona = _db.Persona
                       .Where(e => e.CedulaPersona == id).First();
            return View(persona);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var persona = await _db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();

            }
            return View(persona);
        }
        ////POST - DELETE    //si se realiza una operacion es un POST
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int? id)
        //{
        //    var persona = await _db.Persona.FindAsync(id);
        //    if (persona == null)
        //    {
        //        return View();
        //    }
        //    _db.Persona.Remove(persona);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Delete(string Id)
        {
            cargarDistrito();
            cargarCanton();
            cargarProvincia();
            Persona oPersona = _db.Persona
                 .Where(m => m.CedulaPersona == Id).First();
            return View(oPersona);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(string Id)
        {
            string Error = "";
            try
            {
                Persona oPersona = _db.Persona
                     .Where(c => c.CedulaPersona == Id).First();
                if (oPersona != null)
                {
                    _db.Persona.Remove(oPersona);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        private void BuscarPersona(string CedulaPersona)
        {
            Persona oPersona = _db.Persona
           .Where(p => p.CedulaPersona == CedulaPersona).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonOfimID = oPersona.CedulaPersona;
                ViewBag.Nombre = oPersona.CedulaPersona + " " + oPersona.Ape1;

            }
            else
            {
                ViewBag.Error = "Persona no registrada, intente de nuevo!";
            }
        }



    }
}

