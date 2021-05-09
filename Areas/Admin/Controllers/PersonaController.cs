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
                                 FechaNac = persona.FechaNac,
                                 TelMovil= persona.TelMovil,
                                 Distrito = distrito.Nombre,
                                 Canton = canton.Nombre,
                                 Provincia = provincia.Nombre
                             }).ToList();
            ViewBag.Controlador = "Persona";
            ViewBag.Accion = "Index";
            return View(listaPersonas);
        }
        private void cargarDistrito()
        {
            List<SelectListItem> listaDistrito= new List<SelectListItem>();
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


        private void ListarCanton()
        {
            List<SelectListItem> listaCanton = new List<SelectListItem>();
            listaCanton = (from canton in _db.Canton
                              orderby canton.Nombre
                              select new SelectListItem
                              {
                                  Text = canton.Nombre,
                                  Value = canton.CantonId.ToString()
                              }
                                ).ToList();
            ViewBag.ListaCanton = listaCanton;
        }

        private void ListarProvincia()
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
            ListarCanton();
            ListarProvincia();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            int nVeces = 0;
          
                nVeces = _db.Persona.Where(m => m.Id == PersonaVM.Persona.Id).Count();
                PersonaVM.Persona.Id = Request.Form["CedulaPersona"].ToString();
            if (!ModelState.IsValid || nVeces >= 1)
            {
                    if (nVeces >= 1) ViewBag.Error = "Esta Persona ya se encuentra registrada!";
                    return View(PersonaVM);
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



        private void BuscarPersona(string PersonaId)
        {
            Persona oPersona = _db.Persona
           .Where(p => p.Id == PersonaId).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonaID = oPersona.Id;
                ViewBag.Nombre = oPersona.Nombre + " " + oPersona.Ape1;
                
            }
            else
            {
                ViewBag.Error = "Persona no registrada, intente de nuevo!";
            }
        }


        [ActionName("GetCantones")]
        public async Task<IActionResult> GetCantones(int id)
        {
            List<Canton> cantones = new List<Canton>();
            cantones = await (from Canton in _db.Canton
                              where Canton.ProvinciaId == id
                              select Canton).ToListAsync();
            return Json(new SelectList(cantones, "Id", "Nombre"));
        }

        public IActionResult Details(string id)
        {
            cargarDistrito();
            ListarCanton();
            ListarProvincia();
            Persona persona = _db.Persona
                       .Where(e => e.CedulaPersona == id).First();
            return View(persona);
        }
        [HttpPost]
        public IActionResult Delete(string CedulaPersona)
        {
            var Error = "";
            try
            {
                Persona oPersona = _db.Persona
                             .Where(e => e.Id == CedulaPersona).First();
                _db.Persona.Remove(oPersona);
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

