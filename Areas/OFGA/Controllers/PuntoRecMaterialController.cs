using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        static private string _Fecha;
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
                               Distrito=distrito.Nombre,
                               Clasificacion = especialidad.Nombre,
                               Material= material.Nombre,
                               Fecha = medico.Fecha
                           }).ToList();
            lista = listaPunto;
            return View(listaPunto);
        }

        private void cargarClasificacion()
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

        private void cargarDistrito()
        {
            List<SelectListItem> listaClasificacion = new List<SelectListItem>();
            listaClasificacion = (from especialidad in _db.Distrito
                                  orderby especialidad.Nombre
                                  select new SelectListItem
                                  {
                                      Text = especialidad.Nombre,
                                      Value = especialidad.ClasificacionId.ToString()
                                  }
                                   ).ToList();
            ViewBag.ListaTClasificacion = listaClasificacion;
        }
    }
}
