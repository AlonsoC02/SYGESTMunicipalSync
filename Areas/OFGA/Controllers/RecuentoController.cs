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
    public class RecuentoController : Controller
    {
        private readonly DBSygestContext _db;
        List<RecuentoViewModel> listaRecuento = new List<RecuentoViewModel>();
        static List<RecuentoViewModel> lista = new List<RecuentoViewModel>();
        public RecuentoController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaRecuento = (from recuento in _db.Recuento
                          join materiales in _db.Materiales
                        on recuento.MaterialId equals
                        materiales.MaterialId

                          join clasificacion in _db.Clasificacion
                          on recuento.ClasificacionId equals
                          clasificacion.ClasificacionId


                          select new RecuentoViewModel
                          {
                              RecuentoId = recuento.RecuentoId,
                              PesoGlobal = recuento.PesoGlobal,
                              FechaPeso = recuento.FechaPeso,
                              MaterialId = materiales.MaterialId,
                              ClasificacionId = clasificacion.ClasificacionId

                          }).ToList();
            ViewBag.Controlador = "Recuento";
            ViewBag.Accion = "Index";
            return View(listaRecuento);
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
        public IActionResult Create(Recuento recuento)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Recuento.Where(m => m.RecuentoId == recuento.RecuentoId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este Id ya existe!";
                    cargarMateriales();
                    cargarClasificacion();

                }
                else
                {
                    Recuento _recuento = new Recuento();
                    _recuento.RecuentoId = recuento.RecuentoId;
                    _recuento.PesoGlobal = recuento.PesoGlobal;
                    _recuento.FechaPeso = recuento.FechaPeso;
                    _recuento.MaterialId = recuento.MaterialId;
                    _recuento.ClasificacionId = recuento.ClasificacionId;
                    _db.Recuento.Add(_recuento);
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

            int recCount = _db.Recuento.Count(e => e.RecuentoId == id);
            Recuento _recuento = (from p in _db.Recuento
                            where p.RecuentoId == id
                            select p).DefaultIfEmpty().Single();
            return View(_recuento);
        }
        [HttpPost]
        public IActionResult Edit(Recuento recuento)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarMateriales();
                    cargarClasificacion();

                    return View(recuento);
                }
                else
                {
                    _db.Recuento.Update(recuento);
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

            Recuento recuento = _db.Recuento
                       .Where(e => e.RecuentoId == id).First();
            return View(recuento);
        }
        //DELETE
        [HttpPost]
        public IActionResult Delete(int? RecuentoId)
        {
            var Error = "";
            try
            {
                Recuento oRecuento = _db.Recuento
                             .Where(e => e.RecuentoId == RecuentoId).First();
                _db.Recuento.Remove(oRecuento);
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
