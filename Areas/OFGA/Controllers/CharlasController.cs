using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SYGESTMunicipalSync.Areas.OFGA.Controllers
{
    [Area("OFGA")]
    public class CharlasController : Controller
    {
        private readonly DBSygestContext _db;
        List<Charlas> listaCharlas = new List<Charlas>();
        static List<Charlas> lista = new List<Charlas>();

        public CharlasController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaCharlas = (from charlas in _db.Charlas
                          select new Charlas
                          {
                              CharlaId = charlas.CharlaId,
                              Nombre = charlas.Nombre,
                              Descripcion = charlas.Descripcion.Substring(0, 85) + "...",
                              Lugar = charlas.Lugar.Substring(0, 85) + "...",
                              Expositor = charlas.Expositor.Substring(0, 85) + "...",
                              Fecha = charlas.Fecha,
                              Imagen = charlas.Imagen,
                              Activa = charlas.Activa

                          }).ToList();
            lista = listaCharlas;
            return View(listaCharlas);
        }

        //GET- CREATE
        public IActionResult Create()
        {
            return View();
        }
        ////POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Charlas charlas)
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
                    charlas.Imagen = p1;
                }
                _db.Charlas.Add(charlas);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charlas);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var charlas = await _db.Charlas.FindAsync(id);
            if (charlas == null)
            {
                return NotFound();
            }
            return View(charlas);
        }

        //Postt-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Charlas charlas)
        {
            if (charlas.CharlaId == 0)
            {
                return NotFound();
            }

            var charlasFromDb = await _db.Charlas.FindAsync(charlas.CharlaId);

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
                    charlasFromDb.Imagen = p1;
                }
                charlasFromDb.Nombre = charlas.Nombre;
                charlasFromDb.Descripcion = charlas.Descripcion;
                charlasFromDb.Lugar = charlas.Lugar;
                charlasFromDb.Expositor = charlas.Expositor;
                charlasFromDb.Fecha = charlas.Fecha;
                charlasFromDb.Activa = charlas.Activa;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charlas);
        }


        //DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var charlas = await _db.Charlas.FindAsync(id);
            if (charlas == null)
            {
                return NotFound();

            }
            return View(charlas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var charlas = await _db.Charlas.FindAsync(id);
            if (charlas == null)
            {
                return View();
            }
            _db.Charlas.Remove(charlas);
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
            var charlas = await _db.Charlas.FindAsync(id);
            if (charlas == null)
            {
                return NotFound();
            }
            return View(charlas);
        }

        
        public IActionResult IndexTalks()
        {
            listaCharlas = (from charlas in _db.Charlas
                          where charlas.Activa == true
                          select new Charlas
                          {


                              CharlaId = charlas.CharlaId,
                              Nombre = charlas.Nombre,
                              Descripcion = charlas.Descripcion.Substring(0, 85) + "...",
                              Lugar = charlas.Lugar.Substring(0, 85) + "...",
                              Expositor = charlas.Expositor.Substring(0, 85) + "...",
                              Fecha = charlas.Fecha,
                              Imagen = charlas.Imagen,
                              Activa = charlas.Activa

                          }).ToList();

            lista = listaCharlas;

            return View(listaCharlas);

        }

    }
}
