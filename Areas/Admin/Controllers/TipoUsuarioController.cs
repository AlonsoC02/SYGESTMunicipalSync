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
    [ServiceFilter(typeof(Seguridad))]
    public class TipoUsuarioController : Controller
    {
        
        private readonly DBSygestContext _db;
        
        List<TipoUsuario> listaTipoUsuarios = new List<TipoUsuario>();
        
        public TipoUsuarioController(DBSygestContext db)
        {
            _db = db;
        }

      public List<TipoUsuario> listarTipoUsuarios()
        {
            listaTipoUsuarios = (from tipoUsuario in _db.TipoUsuario
                                 select new TipoUsuario
                             {
                                 TipoUsuarioId = tipoUsuario.TipoUsuarioId,
                                 Nombre = tipoUsuario.Nombre,
                                 BotonHabilitado = tipoUsuario.BotonHabilitado,
                                 Descripcion = tipoUsuario.Descripcion
                             }).ToList();
            return listaTipoUsuarios;
        }
        private void cargarUltimoRegistro()
        {
            var ultimoRegistro = _db.Set<TipoUsuario>().OrderByDescending(
                t => t.TipoUsuarioId).FirstOrDefault();
            if (ultimoRegistro == null)
            {
                ViewBag.ID = 1;
                
            }
            else
            {
                ViewBag.ID = ultimoRegistro.TipoUsuarioId + 1;
            }
        }

    //INDEX
        public IActionResult Index()
        {
            listaTipoUsuarios = listarTipoUsuarios();
            return View(listaTipoUsuarios);
        }

    //CREATE
        [HttpGet]
        public IActionResult Create()
        {
            cargarUltimoRegistro();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoUsuario tipoUsuario)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tipoUsuario);
                }
                else
                {
                    cargarUltimoRegistro();
                    TipoUsuario _tipoUsuario = new TipoUsuario
                    {
                        TipoUsuarioId = ViewBag.ID,
                        Nombre = tipoUsuario.Nombre,
                        BotonHabilitado = 1,
                        Descripcion = tipoUsuario.Descripcion
                    };

                    _db.TipoUsuario.Add(_tipoUsuario);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        
        
    //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TipoUsuario oTipoUsuario = _db.TipoUsuario
                         .Where(e => e.TipoUsuarioId == id).First();
            return View(oTipoUsuario);
        }

        [HttpPost]
        public IActionResult Edit(TipoUsuario tipoUsuario)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tipoUsuario);
                }
                else
                {
                    TipoUsuario _tipoUsuario = new TipoUsuario
                    {
                        TipoUsuarioId= tipoUsuario.TipoUsuarioId,
                        Nombre = tipoUsuario.Nombre,
                        BotonHabilitado = tipoUsuario.BotonHabilitado,
                        Descripcion = tipoUsuario.Descripcion
                    };
                    
                    _db.TipoUsuario.Update(_tipoUsuario);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    
    //DETAILS
        public IActionResult Details(int id)
        {
            TipoUsuario oTipoUsuario = _db.TipoUsuario
                         .Where(e => e.TipoUsuarioId == id).First();
            return View(oTipoUsuario);
        }
        [HttpPost]

    //DELETE
        public IActionResult Delete(int? TipoUsuarioId)
        {
            var Error = "";
            try
            {
                TipoUsuario oTipoUsuario = _db.TipoUsuario
                             .Where(e => e.TipoUsuarioId == TipoUsuarioId).First();
                _db.TipoUsuario.Remove(oTipoUsuario);
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
