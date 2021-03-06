using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.Admin.Models.ViewModel;
using SYGESTMunicipalSync.Filter;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(Seguridad))]
    public class PaginaController : Controller
    {
        private readonly DBSygestContext _db;
        public static List<Pagina> lista;
        private List<MenuController> ListaMenu = new List<MenuController>();
        public PaginaController(DBSygestContext db)
        {
            _db = db;
        }
        private void CargarMenus()
        {
            var list = new SelectList(
                new[]{
                    new{ID="1",Name="Mantenimiento"},
                    new{ID="2",Name="Consultas"},
                    new{ID="3",Name="Citas"},
                    new{ID="4",Name="Accesibilidad"},
                            }, "ID", "Name", 1);
            ViewBag.ListaMenu = list;
        }
        /*CRUD*/
        private void CargarUltimoRegistro()
        {
            var ultimoRegistro = _db.Set<Pagina>().OrderByDescending(e => e.PaginaId).FirstOrDefault();
            if (ultimoRegistro == null)
            {
                ViewBag.ID = 1;
            }
            else
            {
                ViewBag.ID = ultimoRegistro.PaginaId + 1;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {

            CargarMenus();
            CargarUltimoRegistro();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pagina pagina)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pagina);
                }
                else
                {

                    CargarUltimoRegistro();
                    Pagina _pagina = new Pagina()
                    {
                        PaginaId = ViewBag.ID,
                        Menu = pagina.Menu,
                       
                        Accion = pagina.Accion,
                        Controlador = pagina.Controlador,
                    };

                    _db.Pagina.Add(_pagina);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction("Index", "RolUsuario");
        }

        public IActionResult Details(int id)
        {
            CargarMenus();
            CargarUltimoRegistro();
            int recCount = _db.Pagina.Count(e => e.PaginaId == id);
            Pagina _pagina = (from p in _db.Pagina
                              where p.PaginaId == id
                              select p).DefaultIfEmpty().Single();
            return View(_pagina);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CargarMenus();
            CargarUltimoRegistro();
            int recCount = _db.Pagina.Count(e => e.PaginaId == id);
            Pagina _pagina = (from p in _db.Pagina
                              where p.PaginaId == id
                              select p).DefaultIfEmpty().Single();
            return View(_pagina);
        }

        [HttpPost]
        public IActionResult Edit(Pagina pagina)
        {
            string rpta = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pagina);
                }
                else
                {
                    rpta = "OK";

                    Pagina _pagina = new Pagina()
                    {
                        PaginaId = pagina.PaginaId,
                        Menu = pagina.Menu,
                        
                        Accion = pagina.Accion,
                        Controlador = pagina.Controlador,
                    };
                    _db.Pagina.Update(_pagina);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return RedirectToAction("Index", "TipoUsuarios");
        }
        [HttpPost]
        public IActionResult Delete(int PaginaId)
        {
            var Error = "";
            try
            {
                Pagina _pagina = _db.Pagina
                             .Where(e => e.PaginaId == PaginaId).First();
                _db.Pagina.Remove(_pagina);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction("Index", "TipoUsuarios");
        }
    }
}
