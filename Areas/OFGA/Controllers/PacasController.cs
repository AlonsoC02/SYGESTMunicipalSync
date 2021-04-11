using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.OFGA.Models;
using SYGESTMunicipalSync.Areas.OFGA.Models.ViewModels;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Controllers
{
    [Area("OFGA")]
    public class PacasController : Controller
    {
        private readonly DBSygestContext _db;
        List<PacasViewModel> listaPacas = new List<PacasViewModel>();
        static List<PacasViewModel> lista = new List<PacasViewModel>();
        public PacasController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaPacas = (from pacas in _db.Pacas
                             join materiales in _db.Materiales
                           on pacas.MaterialId equals
                           materiales.MaterialId

                             join clasificacion in _db.Clasificacion
                             on pacas.ClasificacionId equals
                             clasificacion.ClasificacionId


                             select new PacasViewModel
                             {
                                 PacaId = pacas.PacaId,
                                 Peso = pacas.Peso,
                                 Fecha = pacas.Fecha,                                
                                 MaterialId = materiales.MaterialId,
                                 ClasificacionId = clasificacion.ClasificacionId
                                
                             }).ToList();
            ViewBag.Controlador = "Pacas";
            ViewBag.Accion = "Index";
            return View(listaPacas);
        }
        private void cargarMateriales()
        {
            List<SelectListItem> listaMateriales = new List<SelectListItem>();
            listaMateriales = (from materiales in _db.Materiales
                                orderby materiales.Nombre
                                select new SelectListItem
                                {
                                    Text = materiales.Nombre,
                                    Value = materiales.MaterialId.ToString()
                                }
                                ).ToList();
            ViewBag.ListaMateriales = listaMateriales;
        }

        private void cargarClasificacion()
        {
            List<SelectListItem> listaClasificacion = new List<SelectListItem>();
            listaClasificacion = (from clasificacion in _db.Clasificacion
                              orderby clasificacion.Nombre
                              select new SelectListItem
                              {
                                  Text = clasificacion.Nombre,
                                  Value = clasificacion.ClasificacionId.ToString()
                              }
                                ).ToList();
            ViewBag.ListaClasificacion = listaClasificacion;
        }


        public IActionResult Create()
        {
            cargarMateriales();
            cargarClasificacion();
            

            return View();
        }

        [HttpPost]
        public IActionResult Create(Pacas pacas)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Pacas.Where(m => m.PacaId == pacas.PacaId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este Id ya existe!";
                    cargarMateriales();
                    cargarClasificacion();
                   
                }
                else
                {
                    Pacas _pacas = new Pacas();
                    _pacas.PacaId = pacas.PacaId;
                    _pacas.Peso = pacas.Peso;
                    _pacas.Fecha = pacas.Fecha;
                    _pacas.MaterialId = pacas.MaterialId;
                    _pacas.ClasificacionId = pacas.ClasificacionId;
                    _db.Pacas.Add(_pacas);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            cargarClasificacion();
            cargarMateriales();

            int recCount = _db.Pacas.Count(e => e.PacaId == id);
            Pacas _pacas = (from p in _db.Pacas
                            where p.PacaId == id
                            select p).DefaultIfEmpty().Single();
            return View(_pacas);
        }
        [HttpPost]
        public IActionResult Edit(Pacas pacas)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarMateriales();
                    cargarClasificacion();
                    
                    return View(pacas);
                }
                else
                {
                    _db.Pacas.Update(pacas);
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
            cargarClasificacion();
            cargarMateriales();
           
            Pacas pacas = _db.Pacas
                       .Where(e => e.PacaId == id).First();
            return View(pacas);
        }
        public IActionResult Delete(int Id)
        {
            cargarMateriales();
            cargarClasificacion();
            
            Pacas oPacas = _db.Pacas
                 .Where(m => m.PacaId == Id).First();
            return View(oPacas);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int Id)
        {
            string Error = "";
            try
            {
                Pacas oPacas = _db.Pacas
                     .Where(c => c.PacaId == Id).First();
                if (oPacas != null)
                {
                    _db.Pacas.Remove(oPacas);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
