using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class EmpresaController : Controller
    {

        private readonly DBSygestContext _db;
        List<EmpresaViewModel> listaEmpresa = new List<EmpresaViewModel>();
        static List<EmpresaViewModel> lista = new List<EmpresaViewModel>();
        public EmpresaController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaEmpresa = (from empresa in _db.Empresa
                            select new EmpresaViewModel
                            {
                                EmpresaId = empresa.EmpresaId,
                                Nombre = empresa.Nombre,
                                Descripcion = empresa.Descripcion.Substring(0, 85) + "...",
                                Ubicacion = empresa.Ubicacion.Substring(0, 85) + "...",
                                Telefono = empresa.Telefono,
                                Email = empresa.Email,
                                PaginaWeb = empresa.PaginaWeb,
                                PersonaId = empresa.PersonaId,
                                CatProductoServicioId = empresa.CatProductoServicioId,
                                Logo = empresa.Logo


                            }).ToList();
            lista = listaEmpresa;
            return View(listaEmpresa);
        }
        private void cargarPersona()
        {
            List<SelectListItem> listaPersona = new List<SelectListItem>();
            listaPersona = (from persona in _db.Persona
                               orderby persona.Nombre
                               select new SelectListItem
                               {
                                   Text = persona.Nombre,
                                   Value = persona.CedulaPersona.ToString()
                               }
                                ).ToList();
            ViewBag.ListaPersona = listaPersona;
        }

        private void cargarCatProductoServicio()
        {
            List<SelectListItem> listaCatProductoServicio = new List<SelectListItem>();
            listaCatProductoServicio = (from catProductoServicio in _db.CatProductoServicio
                            orderby catProductoServicio.Nombre
                            select new SelectListItem
                            {
                                Text = catProductoServicio.Nombre,
                                Value = catProductoServicio.CatProductoServicioId.ToString()
                            }
                                ).ToList();
            ViewBag.ListaCatProductoServicio = listaCatProductoServicio;
        }

        //GET - CREATE

        public IActionResult Create(int id)
            
        {
            cargarCatProductoServicio();
            cargarPersona();
            return View();
        }
        ////POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    empresa.Logo = p1;
                }
                _db.Empresa.Add(empresa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empresa = await _db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        //Postt-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empresa empresa)
        {
            if (empresa.EmpresaId == 0)
            {
                return NotFound();
            }

            var empresaFromDb = await _db.Empresa.FindAsync(empresa.EmpresaId);

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    empresaFromDb.Logo = p1;
                }
                empresaFromDb.Nombre = empresa.Nombre;
                empresaFromDb.Descripcion = empresa.Descripcion;
                empresaFromDb.Ubicacion = empresa.Ubicacion;
                empresaFromDb.Email = empresa.Email;
                empresaFromDb.PaginaWeb = empresa.PaginaWeb;
                empresaFromDb.Telefono = empresa.Telefono;
                empresaFromDb.PersonaId = empresa.PersonaId;
                empresaFromDb.CatProductoServicioId = empresa.CatProductoServicioId;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }


        //DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var empresa = await _db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();

            }
            return View(empresa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var empresa = await _db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return View();
            }
            _db.Empresa.Remove(empresa);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ////DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empresa = await _db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

    }
}
