using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class EjeController : Controller
    {
        private readonly DBSygestContext _db;

        List<EjeCategoria> listaEje = new List<EjeCategoria>();
        static List<EjeCategoria> lista = new List<EjeCategoria>();


        public string StatusMessage { get; set; }


        public EjeController(DBSygestContext db)
        {
            _db = db;
        }

        public List<EjeCategoria> BuscarEjeCategory(string nombreCategory)
        {
            List<EjeCategoria> listaEjeCategory = new List<EjeCategoria>();
            if (nombreCategory == null || nombreCategory.Length == 0)
            {
                listaEje = (from Eje in _db.Eje
                            join category in _db.Categoria
                            on Eje.CategoriaId equals category.Id
                            select new EjeCategoria
                            {
                                Id = Eje.Id,
                                Nombre = Eje.Nombre,
                                Categoria = category.Nombre
                            }).ToList();
                ViewBag.Categoria = "";
            }
            else
            {
                listaEje = (from Eje in _db.Eje
                            join category in _db.Categoria
                            on Eje.CategoriaId equals category.Id
                            where category.Nombre.Contains(nombreCategory)
                            select new EjeCategoria
                            {
                                Id = Eje.Id,
                                Nombre = Eje.Nombre,
                                Categoria = category.Nombre
                            }).ToList();
                ViewBag.Category = nombreCategory;
            }
            lista = listaEje;
            return listaEje;
        }


        public IActionResult Index()
        {
            listaEje = BuscarEjeCategory("");
            return View(listaEje);
        }
        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            EjeAndCategoriaViewModel model = new EjeAndCategoriaViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                Eje = new Models.Eje(),
                EjeList =
                     await _db.Eje.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EjeAndCategoriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EjeExist = _db.Eje.Include(s => s.Categoria).Where(s => s.Nombre
                                      == model.Eje.Nombre
                                      && s.CategoriaId == model.Eje.CategoriaId);
                if (EjeExist.Count() > 0)
                {
                    StatusMessage = "Error: Este Eje ya ha sido creado en la Categoria " + EjeExist.First().Categoria.Nombre +
                          " Por favor, use otro nombre";
                }
                else
                {
                    _db.Eje.Add(model.Eje);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            EjeAndCategoriaViewModel modelVM = new EjeAndCategoriaViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                Eje = model.Eje,
                EjeList = await _db.Eje.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }
        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eje = await _db.Eje.SingleOrDefaultAsync(m => m.Id == id);
            if (eje == null)
            {
                return NotFound();
            }
            EjeAndCategoriaViewModel model = new EjeAndCategoriaViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                Eje = eje,
                EjeList =
                await _db.Eje.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };
            return View(model);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EjeAndCategoriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var EjeExist = _db.Eje.Include(s => s.Categoria).Where(s => s.Nombre == model.Eje.Nombre
                                  && s.CategoriaId == model.Eje.CategoriaId);
                if (EjeExist.Count() > 0)
                {
                    StatusMessage = "Error: Este Eje ya ha sido creado en la Categoria " + EjeExist.First().Categoria.Nombre +
                            " Por favor, use otro nombre";
                }
                else
                {
                    var EjeFromDB = await _db.Eje.FindAsync(id);
                    EjeFromDB.Nombre = model.Eje.Nombre;
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            EjeAndCategoriaViewModel modelVM = new EjeAndCategoriaViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                Eje = model.Eje,
                EjeList = await _db.Eje.OrderBy(p => p.Nombre).Select(p => p.Nombre).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }

        //GET - DELETE






        //GET - DETAILS
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var eje = await _db.Eje.SingleOrDefaultAsync(m => m.Id == Id);
            if (eje == null)
            {
                return NotFound();
            }
            EjeAndCategoriaViewModel model = new EjeAndCategoriaViewModel()
            {
                CategoriaList = await _db.Categoria.ToListAsync(),
                Eje = eje,
                EjeList = await _db.Eje.OrderBy(p => p.Nombre).Select(p => p.Nombre).Distinct().ToListAsync()
            };
            return View(model);
        }


        public IActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                var EjeExist = _db.Actividad.Include(s => s.Eje).Where(s => s.EjeId == Id
                                  && s.EjeId == Id);


                if (EjeExist.Count() > 0)
                {
                    StatusMessage = "Error: Este Eje está siendo usado por la actividad " + EjeExist.First().Id +
                            " Primero debe editar o eliminar la actividad para poder eliminar este eje";
                }
                else
                {
                    Eje oEje = _db.Eje.Where(e => e.Id == Id).First();
                    _db.Eje.Remove(oEje);
                    _db.SaveChanges();
                    StatusMessage = StatusMessage;
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [ActionName("GetEjes")]
        public async Task<IActionResult> GetEjes(int id)
        {
            List<Eje> ejes = new List<Eje>();
            ejes = await (from Eje in _db.Eje
                          where Eje.CategoriaId == id
                          select Eje).ToListAsync();
            return Json(new SelectList(ejes, "Id", "Name"));
        }

        //public FileResult exportar()
        //{
        //    Utilitarios util = new Utilitarios();
        //    string[] cabeceras = { "Id Eje", "Nombre", "Category" };
        //    string[] nombrePropiedades = { "Id", "Name", "Category" };
        //    string titulo = "Reporte de Ejes";
        //    byte[] buffer = util.ExportarPDFDatos(nombrePropiedades, lista, titulo);
        //    return File(buffer, "application/pdf");
        //}

    }
}