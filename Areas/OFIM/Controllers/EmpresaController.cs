using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public EmpresaViewModel EmpresaVM { get; set; }
        public EmpresaController(DBSygestContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            EmpresaVM = new EmpresaViewModel()
            {
                CatProductoServicio = _db.CatProductoServicio,
                Persona = _db.Persona,
                Empresa = new Models.Empresa()
            };
        }

        public async Task<IActionResult> Index()
        {
            var Empresa =
            await _db.Empresa.Include(m => m.CatProductoServicio).Include(m => m.Persona).ToListAsync();
            return View(Empresa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var Empresa =
                await _db.Empresa.Include(m => m.CatProductoServicio).Include(m => m.Persona).ToListAsync();
                return View(Empresa);
            }
            else
            {
                var empresaItem =
                     await _db.Empresa.Where(p => p.CatProductoServicio.Nombre == dato)
                     .Include(p => p.Persona).Include(c => c.CatProductoServicio).ToListAsync();

                return View(empresaItem);
            }
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
                                            Value = catProductoServicio.Id.ToString()
                                        }
                                ).ToList();
            ViewBag.ListaCatProductoServicio = listaCatProductoServicio;
        }




        //GET - CREATE
        public IActionResult Create()
        {
            cargarCatProductoServicio();
            cargarPersona();
            return View(EmpresaVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            EmpresaVM.Empresa.CatProductoServicioId = Convert.ToInt32(Request.Form["CatProductoServicioId"].ToString());

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
                    EmpresaVM.Empresa.Logo = p1;
                }
                _db.Empresa.Add(EmpresaVM.Empresa);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(EmpresaVM.Empresa);
        }



        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            cargarPersona();
            cargarCatProductoServicio();
            if (EmpresaVM.Empresa == null)
            {
                return NotFound();
            }
            return View(EmpresaVM);
        }

        //POST - EDIT
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            if (!ModelState.IsValid)
            {
              
                return View(EmpresaVM);
            }
            //work in the image saving
            var files = HttpContext.Request.Form.Files;
            var empresaFromDb = await _db.Empresa.FindAsync(EmpresaVM.Empresa.Id);
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
            empresaFromDb.Nombre = EmpresaVM.Empresa.Nombre;
            empresaFromDb.Descripcion = EmpresaVM.Empresa.Descripcion;
            empresaFromDb.Ubicacion = EmpresaVM.Empresa.Ubicacion;
            empresaFromDb.Email = EmpresaVM.Empresa.Email;
            empresaFromDb.PaginaWeb = EmpresaVM.Empresa.PaginaWeb;
            empresaFromDb.Telefono = EmpresaVM.Empresa.Telefono;
            empresaFromDb.PersonaId = EmpresaVM.Empresa.PersonaId;
            empresaFromDb.CatProductoServicioId = EmpresaVM.Empresa.CatProductoServicioId;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET - DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          

            if (EmpresaVM.Empresa == null)
            {
                return NotFound();
            }
            return View(EmpresaVM);
        }

        //GET - DELETE

        public async Task<IActionResult> Delete(int? Id)
        {
            string Error = "";
            try
            {
                var empresaDelete = await _db.Empresa.Include(m => m.CatProductoServicio).Include(m => m.Persona).SingleOrDefaultAsync(m => m.Id == Id);

                _db.Empresa.Remove(empresaDelete);
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
