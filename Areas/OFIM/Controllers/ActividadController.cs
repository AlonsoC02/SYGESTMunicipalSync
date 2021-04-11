using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]

    public class ActividadController : Controller
    {
        private readonly DBSygestContext _db;

        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ActividadViewModel ActividadVM { get; set; }
        public ActividadController(DBSygestContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            ActividadVM = new ActividadViewModel()
            {
                Categoria = _db.Categoria,
                Actividad = new Models.Actividad()
            };
        }
        public async Task<IActionResult> Index()
        {
            var Actividad =
            await _db.Actividad.Include(m => m.Categoria).Include(m => m.Eje).ToListAsync();
            return View(Actividad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var Actividad =
                await _db.Actividad.Include(m => m.Categoria).Include(m => m.Eje).ToListAsync();
                return View(Actividad);
            }
            else
            {
                var actItem =
                     await _db.Actividad.Where(p => p.Categoria.Nombre == dato)
                     .Include(p => p.Eje).Include(c => c.Categoria).ToListAsync();

                return View(actItem);
            }
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(ActividadVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            ActividadVM.Actividad.EjeId = Convert.ToInt32(Request.Form["EjeId"].ToString());

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
                    ActividadVM.Actividad.Imagen = p1;
                }
                _db.Actividad.Add(ActividadVM.Actividad);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ActividadVM.Actividad);
        }


        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ActividadVM.Actividad = await _db.Actividad.Include(m => m.Categoria).Include(m => m.Eje).SingleOrDefaultAsync(m => m.ActividadId == id);
            ActividadVM.Eje = await _db.Eje.Where(p => p.CategoriaId == ActividadVM.Actividad.CategoriaId).ToListAsync();
            if (ActividadVM.Actividad == null)
            {
                return NotFound();
            }
            return View(ActividadVM);
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
            ActividadVM.Actividad.EjeId = Convert.ToInt32(Request.Form["EjeId"].ToString());
            if (!ModelState.IsValid)
            {
                ActividadVM.Eje = await _db.Eje.Where(p => p.CategoriaId == ActividadVM.Actividad.CategoriaId).ToListAsync();
                return View(ActividadVM);
            }
            //work in the image saving
            var files = HttpContext.Request.Form.Files;
            var actividadFromDb = await _db.Actividad.FindAsync(ActividadVM.Actividad.ActividadId);
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
                actividadFromDb.Imagen = p1;
            }
            actividadFromDb.Nombre = ActividadVM.Actividad.Nombre;
            actividadFromDb.Descripcion = ActividadVM.Actividad.Descripcion;
            actividadFromDb.Fecha = ActividadVM.Actividad.Fecha;
            actividadFromDb.Activo = ActividadVM.Actividad.Activo;
            actividadFromDb.CategoriaId = ActividadVM.Actividad.CategoriaId;
            actividadFromDb.EjeId = ActividadVM.Actividad.EjeId;
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
            ActividadVM.Actividad = await _db.Actividad.Include(m => m.Categoria).Include(m => m.Eje).SingleOrDefaultAsync(m => m.ActividadId == id);
            ActividadVM.Eje = await _db.Eje.Where(s => s.CategoriaId == ActividadVM.Actividad.CategoriaId).ToListAsync();

            if (ActividadVM.Actividad == null)
            {
                return NotFound();
            }
            return View(ActividadVM);
        }

        //GET - DELETE

        public async Task<IActionResult> Delete(int? Id)
        {
            string Error = "";
            try
            {
                var actividadDelete = await _db.Actividad.Include(m => m.Categoria).Include(m => m.Eje).SingleOrDefaultAsync(m => m.ActividadId == Id);

                _db.Actividad.Remove(actividadDelete);
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

