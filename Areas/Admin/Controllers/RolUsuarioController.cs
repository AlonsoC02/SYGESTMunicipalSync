using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Filter;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[ServiceFilter(typeof(Seguridad))]
    public class RolUsuarioController : Controller
    {
        private readonly DBSygestContext _db;
        List<Rol> listaRol = new List<Rol>();
       
        public RolUsuarioController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaRol = (from rol in _db.Rol
                        select new Rol
                        {
                            RolId = rol.RolId,
                            Nombre = rol.Nombre,
                            Descripcion = rol.Descripcion

                        }).ToList();
            var model = listaRol;
            return View("Index", model);
        }

       
      

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Rol rol)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(rol);
                }
                else
                {
                    _db.Rol.Add(rol);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        

        public IActionResult Details(int id)
        {
            Rol oRol = _db.Rol
                         .Where(e => e.RolId == id).First();
            return View(oRol);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Rol oRol = _db.Rol
                         .Where(e => e.RolId == id).First();
            return View(oRol);
        }

        [HttpPost]
        public IActionResult Edit(Rol rol)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(rol);
                }
                else
                {
                    Rol _rol = new Rol
                    {
                        RolId = rol.RolId,
                        Nombre = rol.Nombre,
                        Descripcion = rol.Descripcion
                    };

                    _db.Rol.Update(_rol);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
       
        [HttpPost]
        public IActionResult Delete(int? RolId)
        {
            var Error = "";
            try
            {
                Rol oRol = _db.Rol
                             .Where(e => e.RolId == RolId).First();
                _db.Rol.Remove(oRol);
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
