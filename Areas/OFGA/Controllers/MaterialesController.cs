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
    public class MaterialesController : Controller
    {
        private readonly DBSygestContext _db;
        List<MaterialesClasificacionViewModel> listaMedico = new List<MaterialesClasificacionViewModel>();
        static List<MaterialesClasificacionViewModel> lista = new List<MaterialesClasificacionViewModel>();
        public MaterialesController(DBSygestContext db)
        {
            _db = db;
        }
        public List<MaterialesClasificacionViewModel> BuscarMaterialesClasificacion(string nombreEspecialidad)
        {
            List<MaterialesClasificacionViewModel> listaMedicoEspecialidad = new List<MaterialesClasificacionViewModel>();
            if (nombreEspecialidad == null || nombreEspecialidad.Length == 0)
            {
                listaMedico = (from medico in _db.Materiales
                               join especialidad in _db.Clasificacion
                               on medico.ClasificacionId equals especialidad.ClasificacionId
                               select new MaterialesClasificacionViewModel
                               {
                                   MaterialId = medico.MaterialId,
                                   Nombre = medico.Nombre,
                                   Clasificacion = especialidad.Nombre,
                                   Color = medico.Color
                               }).ToList();
                ViewBag.Especialidad = "";
            }
            else
            {
                listaMedico = (from medico in _db.Materiales
                               join especialidad in _db.Clasificacion
                               on medico.ClasificacionId equals especialidad.ClasificacionId
                               where especialidad.Nombre.Contains(nombreEspecialidad)
                               select new MaterialesClasificacionViewModel
                               {
                                   MaterialId = medico.MaterialId,
                                   Nombre = medico.Nombre,
                                   Clasificacion = especialidad.Nombre,
                                   Color = medico.Color
                               }).ToList();
                ViewBag.Especialidad = nombreEspecialidad;
            }
            lista = listaMedico;
            return listaMedico;
        }
        private void cargarClasificacion()
        {
            List<SelectListItem> listaMaterial = new List<SelectListItem>();
            listaMaterial = (from especialidad in _db.Clasificacion
                                   orderby especialidad.Nombre
                                   select new SelectListItem
                                   {
                                       Text = especialidad.Nombre,
                                       Value = especialidad.ClasificacionId.ToString()
                                   }
                                   ).ToList();
            ViewBag.ListaTMaterial = listaMaterial;
        }

        public IActionResult Index()
        {
            listaMedico = (from medico in _db.Materiales
                           join especialidad in _db.Clasificacion
                           on medico.ClasificacionId equals especialidad.ClasificacionId
                           select new MaterialesClasificacionViewModel
                           {
                               MaterialId = medico.MaterialId,
                               Nombre = medico.Nombre,
                               Clasificacion = especialidad.Nombre,
                               Color = medico.Color
                           }).ToList();
            lista = listaMedico;
            return View(listaMedico);
        }

        public IActionResult Create()
        {
            cargarClasificacion();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Materiales materials)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.Materiales.Where(m => m.MaterialId == materials.MaterialId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Este id ya existe!";

                    cargarClasificacion();
                    return View(materials);
                }
                else
                {
                    Materiales _materials = new Materiales();
                    _materials.MaterialId = materials.MaterialId;
                    _materials.Nombre = materials.Nombre;
                    _materials.Color = materials.Color;
                    _materials.ClasificacionId = materials.ClasificacionId;

                    _db.Materiales.Add(_materials);
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
            cargarClasificacion();
            int recCount = _db.Materiales.Count(e => e.MaterialId == id);
            Materiales _materials = (from p in _db.Materiales
                                    where p.MaterialId == id
                                    select p).DefaultIfEmpty().Single();
            return View(_materials);
        }
        [HttpPost]
        public IActionResult Edit(Materiales materials)
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
                    _db.Materiales.Update(materials);
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
            Materiales materiales = _db.Materiales
                       .Where(e => e.MaterialId == id).First();
            return View(materiales);
        }

        [HttpPost]
        public IActionResult Delete(int? MaterialId)
        {
            var Error = "";
            try
            {
                Materiales oMateriales = _db.Materiales
                             .Where(e => e.MaterialId == MaterialId).First();
                _db.Materiales.Remove(oMateriales);
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
