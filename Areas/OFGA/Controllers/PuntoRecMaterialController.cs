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
    public class PuntoRecMaterialController : Controller
    {
        private readonly DBSygestContext _db;
        List<PuntoRecMaterialMaterialesClasificacionViewModel> listaPunto = new List<PuntoRecMaterialMaterialesClasificacionViewModel>();
        static List<PuntoRecMaterialMaterialesClasificacionViewModel> lista = new List<PuntoRecMaterialMaterialesClasificacionViewModel>();

        public PuntoRecMaterialController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaPunto = (from puntoRecMaterial in _db.PuntoRecMaterial
                          join clasificacion in _db.Clasificacion
                          on puntoRecMaterial.ClasificacionId equals clasificacion.ClasificacionId

                          join distrito in _db.Distrito
                          on puntoRecMaterial.DistritoId equals distrito.DistritoId

                          join material in _db.Materiales
                          on puntoRecMaterial.MaterialId equals material.MaterialId

                          select new PuntoRecMaterialMaterialesClasificacionViewModel
                          {
                              PuntosRecMaterialId = puntoRecMaterial.PuntosRecMaterialId,
                              Peso = puntoRecMaterial.Peso,
                              Distrito = distrito.Nombre,
                              Clasificacion = clasificacion.Nombre,
                              Material = material.Nombre,
                              Fecha = puntoRecMaterial.Fecha
                          }).ToList();
            lista = listaPunto;
            return View(listaPunto);

        }
        private void CargarClasificacion()
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
            ViewBag.ListaTClasificacion = listaClasificacion;
        }

        private void CargarDistrito()
        {
            List<SelectListItem> listaDistrito = new List<SelectListItem>();
            listaDistrito = (from distrito in _db.Distrito
                                  orderby distrito.Nombre
                                  select new SelectListItem
                                  {
                                      Text = distrito.Nombre,
                                      Value = distrito.DistritoId.ToString()
                                  }
                                   ).ToList();
            ViewBag.ListaTDistrito = listaDistrito;
        }
        private void CargarMaterial()
        {
            List<SelectListItem> listaMaterial= new List<SelectListItem>();
            listaMaterial = (from material in _db.Materiales
                                  orderby material.Nombre
                                  select new SelectListItem
                                  {
                                      Text = material.Nombre,
                                      Value = material.MaterialId.ToString()
                                  }
                                   ).ToList();
            ViewBag.ListaTMaterial = listaMaterial;
        }

        public IActionResult Create()
        {
            CargarMaterial();
            CargarDistrito();
            CargarClasificacion();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PuntoRecMaterial materials)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.PuntoRecMaterial.Where(m => m.PuntosRecMaterialId == materials.PuntosRecMaterialId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este id ya existe!";

                    CargarMaterial();
                    CargarDistrito();
                    CargarClasificacion();
                    return View(materials);
                }
                else
                {


                    PuntoRecMaterial _materials = new PuntoRecMaterial();
                    _materials.PuntosRecMaterialId = materials.PuntosRecMaterialId;
                    _materials.MaterialId = materials.MaterialId;
                    _materials.Peso = materials.Peso;
                    _materials.Fecha = materials.Fecha;
                    _materials.ClasificacionId = materials.ClasificacionId;
                    _materials.DistritoId = materials.DistritoId;

                    _db.PuntoRecMaterial.Add(_materials);
                    _db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            CargarMaterial();
            CargarDistrito();
            CargarClasificacion();
            int recCount = _db.PuntoRecMaterial.Count(e => e.PuntosRecMaterialId == id);
            PuntoRecMaterial _materials = (from p in _db.PuntoRecMaterial
                                     where p.PuntosRecMaterialId == id
                                     select p).DefaultIfEmpty().Single();
            return View(_materials);
        }
        [HttpPost]
        public IActionResult Edit(PuntoRecMaterial materials)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    CargarMaterial();
                    CargarDistrito();
                    CargarClasificacion();
                    return View(materials);
                }
                else
                {
                    _db.PuntoRecMaterial.Update(materials);
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
        public IActionResult Delete(int? Id)
        {
            string Error = "";
            try
            {
                PuntoRecMaterial oCupos = _db.PuntoRecMaterial
                               .Where(m => m.PuntosRecMaterialId == Id).First();
                _db.PuntoRecMaterial.Remove(oCupos);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            CargarMaterial();
            CargarDistrito();
            CargarClasificacion();
            PuntoRecMaterial oEspecialidad = _db.PuntoRecMaterial
                         .Where(e => e.PuntosRecMaterialId == id).First();
            return View(oEspecialidad);
        }
    }
}
