using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class ProductoServicioController : Controller
    {
        private readonly DBSygestContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ProductoServicioViewModel ProductoServicioVM { get; set; }
        public ProductoServicioController(DBSygestContext db,
            IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
            ProductoServicioVM = new ProductoServicioViewModel()
            {
                CatProductoServicio = _db.CatProductoServicio,
                ProductoServicio = new Models.ProductoServicio()
            };
        }
        public async Task<IActionResult> Index()
        {
            var ProductoServicio =
            await _db.ProductoServicio.Include(m => m.CatProductoServicio).Include(m => m.Empresa).ToListAsync();
            return View(ProductoServicio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string dato)
        {
            if (dato == null)
            {
                var ProductoServicio =
                await _db.ProductoServicio.Include(m => m.CatProductoServicio).Include(m => m.Empresa).ToListAsync();
                return View(ProductoServicio);
            }
            else
            {
                var prodServicioItem =
                     await _db.ProductoServicio.Where(p => p.CatProductoServicio.Nombre == dato)
                     .Include(p => p.Empresa).Include(c => c.CatProductoServicio).ToListAsync();

                return View(prodServicioItem);
            }
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View(ProductoServicioVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            ProductoServicioVM.ProductoServicio.EmpresaId = Convert.ToInt32(Request.Form["EmpresaId"].ToString());

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
                    ProductoServicioVM.ProductoServicio.Imagen = p1;
                }
                _db.ProductoServicio.Add(ProductoServicioVM.ProductoServicio);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ProductoServicioVM.ProductoServicio);
        }


        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductoServicioVM.ProductoServicio = await _db.ProductoServicio.Include(m => m.CatProductoServicio).Include(m => m.Empresa).SingleOrDefaultAsync(m => m.Id == id);
            ProductoServicioVM.Empresa = await _db.Empresa.Where(p => p.CatProductoServicioId == ProductoServicioVM.ProductoServicio.CatProductoServicioId).ToListAsync();
            if (ProductoServicioVM.ProductoServicio == null)
            {
                return NotFound();
            }
            return View(ProductoServicioVM);
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
            ProductoServicioVM.ProductoServicio.EmpresaId = Convert.ToInt32(Request.Form["EmpresaId"].ToString());
            if (!ModelState.IsValid)
            {
                ProductoServicioVM.Empresa = await _db.Empresa.Where(p => p.CatProductoServicioId == ProductoServicioVM.ProductoServicio.CatProductoServicioId).ToListAsync();
                return View(ProductoServicioVM);
            }
            //work in the image saving
            var files = HttpContext.Request.Form.Files;
            var productoServicioFromDb = await _db.ProductoServicio.FindAsync(ProductoServicioVM.ProductoServicio.Id);
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
                productoServicioFromDb.Imagen = p1;
            }
            productoServicioFromDb.Nombre = ProductoServicioVM.ProductoServicio.Nombre;
            productoServicioFromDb.Descripcion = ProductoServicioVM.ProductoServicio.Descripcion;
            productoServicioFromDb.CatProductoServicioId = ProductoServicioVM.ProductoServicio.CatProductoServicioId;
            productoServicioFromDb.EmpresaId = ProductoServicioVM.ProductoServicio.EmpresaId;
         
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
            ProductoServicioVM.ProductoServicio = await _db.ProductoServicio.Include(m => m.CatProductoServicio).Include(m => m.Empresa).SingleOrDefaultAsync(m => m.Id == id);
            ProductoServicioVM.Empresa = await _db.Empresa.Where(s => s.CatProductoServicioId == ProductoServicioVM.ProductoServicio.CatProductoServicioId).ToListAsync();

            if (ProductoServicioVM.ProductoServicio == null)
            {
                return NotFound();
            }
            return View(ProductoServicioVM);
        }

        //GET - DELETE

        public async Task<IActionResult> Delete(int? Id)
        {
            string Error = "";
            try
            {
                var productoServicioDelete = await _db.ProductoServicio.Include(m => m.CatProductoServicio).Include(m => m.Empresa).SingleOrDefaultAsync(m => m.Id == Id);

                _db.ProductoServicio.Remove(productoServicioDelete);
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
