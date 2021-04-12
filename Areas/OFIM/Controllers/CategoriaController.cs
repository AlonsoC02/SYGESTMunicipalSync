using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class CategoriaController : Controller
    {
        private readonly DBSygestContext _db;
        List<Categoria> listaCategoria = new List<Categoria>();
        static List<Categoria> lista = new List<Categoria>();

        public CategoriaController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaCategoria = (from categoria in _db.Categoria


                           select new Categoria
                           {
                               CategoriaId = categoria.CategoriaId,
                               Nombre = categoria.Nombre,
                               
                           }).ToList();
            lista = listaCategoria;
            return View(listaCategoria);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Categoria.Where(m => m.CategoriaId == categoria.CategoriaId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta registro ya existe!";

                    return View(categoria);
                }
                else
                {

                    _db.Categoria.Add(categoria);
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
            Categoria oCategoria = _db.Categoria
                .Where(e => e.CategoriaId == Id).FirstOrDefault();
            return View(oCategoria);
        }
        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(categoria);
                }
                else
                {
                    _db.Categoria.Update(categoria);
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

            Categoria oCategoria = _db.Categoria
                       .Where(e => e.CategoriaId == id).First();
            return View(oCategoria);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var categoria = await _db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();

            }
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var categoria = await _db.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return View();
            }
            _db.Categoria.Remove(categoria);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
