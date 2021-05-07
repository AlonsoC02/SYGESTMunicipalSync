using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly DBSygestContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PersonaViewModel PersonaVM { get; set; }
        
        public PersonaController(DBSygestContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            PersonaVM = new PersonaViewModel()
            {
                Provincia = _db.Provincia,
                Persona = new Models.Persona()
            };
        }
        public async Task<IActionResult> Index()
        {
            var Persona =
            await _db.Persona.Include(m => m.Provincia).Include(m => m.Canton).Include(m => m.Distrito).ToListAsync();
            return View(Persona);
        }
        
        public IActionResult Create()
        {
            return View(PersonaVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            int nVeces = 0;
          
                nVeces = _db.Persona.Where(m => m.CedulaPersona == PersonaVM.Persona.CedulaPersona).Count();
                PersonaVM.Persona.CedulaPersona =Request.Form["CedulaPersona"].ToString();
            if (!ModelState.IsValid || nVeces >= 1)
            {
                    if (nVeces >= 1) ViewBag.Error = "Esta Persona ya se encuentra registrada!";
                    return View(PersonaVM);
            }
                else
                {
                    _db.Persona.Add(PersonaVM.Persona);
            await _db.SaveChangesAsync();
           
                }
            
            return RedirectToAction(nameof(Index));
        }



        private void BuscarPersona(string PersonaId)
        {
            Persona oPersona = _db.Persona
           .Where(p => p.CedulaPersona == PersonaId).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonaID = oPersona.CedulaPersona;
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

        [ActionName("GetDistritos")]
        public async Task<IActionResult> GetDistritos(int id)
        {
            List<Distrito> cantones = new List<Distrito>();
            cantones = await (from Distrito in _db.Distrito
                              where Distrito.CantonId == id
                              select Distrito).ToListAsync();
            return Json(new SelectList(cantones, "Id", "Nombre"));
        }

        


        [HttpPost]
        public IActionResult Delete(string CedulaPersona)
        {
            var Error = "";
            try
            {
                Persona oPersona = _db.Persona
                             .Where(e => e.CedulaPersona == CedulaPersona).First();
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

