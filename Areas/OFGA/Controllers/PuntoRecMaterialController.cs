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
            listaPunto = (from medico in _db.PuntoRecMaterial
                          join especialidad in _db.Clasificacion
                          on medico.ClasificacionId equals especialidad.ClasificacionId

                          join distrito in _db.Distrito
                          on medico.DistritoId equals distrito.DistritoId

                          join material in _db.Materiales
                          on medico.MaterialId equals material.MaterialId

                          select new PuntoRecMaterialMaterialesClasificacionViewModel
                          {
                              PuntosRecMaterialId = medico.PuntosRecMaterialId,
                              Peso = medico.Peso,
                              Distrito = distrito.Nombre,
                              Clasificacion = especialidad.Nombre,
                              Material = material.Nombre,
                              Fecha = medico.Fecha
                          }).ToList();
            lista = listaPunto;
            return View(listaPunto);

        }
        private void CargarClasificacion()
        {
            List<SelectListItem> listaClasificacion = new List<SelectListItem>();
            listaClasificacion = (from especialidad in _db.Clasificacion
                                  orderby especialidad.Nombre
                                  select new SelectListItem
                                  {
                                      Text = especialidad.Nombre,
                                      Value = especialidad.ClasificacionId.ToString()
                                  }
                                   ).ToList();
            ViewBag.ListaTClasificacion = listaClasificacion;
        }

        private void CargarDistrito()
        {
            List<SelectListItem> listaClasificacion = new List<SelectListItem>();
            listaClasificacion = (from especialidad in _db.Distrito
                                  orderby especialidad.Nombre
                                  select new SelectListItem
                                  {
                                      Text = especialidad.Nombre,
                                      Value = especialidad.DistritoId.ToString()
                                  }
                                   ).ToList();
            ViewBag.ListaTDistrito = listaClasificacion;
        }
        private void CargarMaterial()
        {
            List<SelectListItem> listaClasificacion = new List<SelectListItem>();
            listaClasificacion = (from especialidad in _db.Materiales
                                  orderby especialidad.Nombre
                                  select new SelectListItem
                                  {
                                      Text = especialidad.Nombre,
                                      Value = especialidad.MaterialId.ToString()
                                  }
                                   ).ToList();
            ViewBag.ListaTMaterial = listaClasificacion;
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
    }
}
