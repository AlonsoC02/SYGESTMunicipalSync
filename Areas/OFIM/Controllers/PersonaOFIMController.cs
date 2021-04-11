using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.OFIM.Models;
using SYGESTMunicipalSync.Areas.OFIM.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class PersonaOFIMController : Controller
    {
        private readonly DBSygestContext _db;

        List<PerOFIMViewModel> listaPersonas = new List<PerOFIMViewModel>();
        static List<PerOFIMViewModel> lista = new List<PerOFIMViewModel>();
        public PersonaOFIMController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaPersonas = (from personaOFIM in _db.PersonaOFIM
                             join persona in _db.Persona
                            on personaOFIM.PersonaId equals
                            persona.CedulaPersona

                             join estadoCivil in _db.EstadoCivil
                             on personaOFIM.EstadoCivilId equals
                             estadoCivil.EstadoCivilId

                             join nacionalidad in _db.Nacionalidad
                             on personaOFIM.NacionalidadId equals
                             nacionalidad.NacionalidadId

                             join nivelAcademico in _db.NivelAcademico
                             on personaOFIM.NivelAcademicoId equals
                             nivelAcademico.NivelAcademicoId

                             join ocupacion in _db.Ocupacion
                             on personaOFIM.OcupacionId equals
                             ocupacion.OcupacionId

                             join seguro in _db.Seguro
                             on personaOFIM.SeguroId equals
                             seguro.SeguroId

                             join discapacidad in _db.Discapacidades
                             on personaOFIM.DiscapacidadId equals
                             discapacidad.DiscapacidadId

                             join padecimiento in _db.Padecimientos
                             on personaOFIM.PadecimientoId equals
                             padecimiento.PadecimientoId

                             join ingreso in _db.IngresoPersona
                             on personaOFIM.IngresoPersonaId equals
                             ingreso.IngresoPersonaId

                             select new PerOFIMViewModel
                             {
                                 PersonaOFIMId = personaOFIM.PersonaOFIMId,
                                 PersonaId = persona.CedulaPersona,
                                 Persona= persona.Nombre,
                                 Ocupacion = ocupacion.Nombre,
                                 Seguro= seguro.Nombre,
                                 Nacionalidad = nacionalidad.Nombre,
                                 NivelAcademico = nivelAcademico.Nombre,
                                 EstadoCivil = estadoCivil.Nombre,
                                 Padecimiento = padecimiento.Nombre,
                                 Discapacidad = discapacidad.Nombre,
                                 IngresoPersona = ingreso.IngresoMensual

                             }).ToList();
            ViewBag.Controlador = "PersonaOFIM";
            ViewBag.Accion = "Index";
            return View(listaPersonas);
        }
        private void cargarEstadoCivil()
        {
            List<SelectListItem> listaEstadoCivil = new List<SelectListItem>();
            listaEstadoCivil = (from estadoCivil in _db.EstadoCivil
                                orderby estadoCivil.Nombre
                                select new SelectListItem
                                {
                                    Text = estadoCivil.Nombre,
                                    Value = estadoCivil.EstadoCivilId.ToString()
                                }
                                ).ToList();
            ViewBag.ListaEstadoCivil = listaEstadoCivil;
        }

        private void cargarOcupacion()
        {
            List<SelectListItem> listaOcupacion = new List<SelectListItem>();
            listaOcupacion = (from ocupacion in _db.Ocupacion
                              orderby ocupacion.Nombre
                              select new SelectListItem
                              {
                                  Text = ocupacion.Nombre,
                                  Value = ocupacion.OcupacionId.ToString()
                              }
                                ).ToList();
            ViewBag.ListaOcupacion = listaOcupacion;
        }

        private void cargarNacionalidad()
        {
            List<SelectListItem> listaNacionalidad = new List<SelectListItem>();
            listaNacionalidad = (from nacionalidad in _db.Nacionalidad
                                 orderby nacionalidad.Nombre
                                 select new SelectListItem
                                 {
                                     Text = nacionalidad.Nombre,
                                     Value = nacionalidad.NacionalidadId.ToString()
                                 }
                                ).ToList();
            ViewBag.ListaNacionalidad = listaNacionalidad;
        }

        private void cargarNivelAcademico()
        {
            List<SelectListItem> listaNivelAcademico = new List<SelectListItem>();
            listaNivelAcademico = (from nivelAcademico in _db.NivelAcademico
                                   orderby nivelAcademico.Nombre
                                   select new SelectListItem
                                   {
                                       Text = nivelAcademico.Nombre,
                                       Value = nivelAcademico.NivelAcademicoId.ToString()
                                   }
                                ).ToList();
            ViewBag.ListaNivelAcademico = listaNivelAcademico;
        }

        private void cargarSeguro()
        {
            List<SelectListItem> listaSeguro = new List<SelectListItem>();
            listaSeguro = (from seguro in _db.Seguro
                           orderby seguro.Nombre
                           select new SelectListItem
                           {
                               Text = seguro.Nombre,
                               Value = seguro.SeguroId.ToString()
                           }
                                ).ToList();
            ViewBag.ListaSeguro = listaSeguro;
        }

        public IActionResult Create()
        {
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonaOFIM personaOFIM)
        {
            int nVeces = 0;

            try
            {
                nVeces = _db.PersonaOFIM.Where(m => m.PersonaOFIMId == personaOFIM.PersonaOFIMId).Count();
                if (!ModelState.IsValid || nVeces >= 1)
                {
                    if (nVeces >= 1) ViewBag.Error = "Esta cédula de persona ya existe!";
                    cargarEstadoCivil();
                    cargarOcupacion();
                    cargarNacionalidad();
                    cargarNivelAcademico();
                    cargarSeguro();
                    return View(personaOFIM);
                }
                else
                {
                    PersonaOFIM _personaOFIM = new PersonaOFIM();
                    _personaOFIM.PersonaOFIMId = personaOFIM.PersonaOFIMId;
                    _personaOFIM.PersonaId = personaOFIM.PersonaId;
                    _personaOFIM.OcupacionId = personaOFIM.OcupacionId;
                    _personaOFIM.SeguroId = personaOFIM.SeguroId;
                    _personaOFIM.NacionalidadId = personaOFIM.NacionalidadId;
                    _personaOFIM.NivelAcademicoId = personaOFIM.NivelAcademicoId;
                    _personaOFIM.EstadoCivilId = personaOFIM.EstadoCivilId;
                    _personaOFIM.PadecimientoId = personaOFIM.PadecimientoId;
                    _personaOFIM.DiscapacidadId = personaOFIM.DiscapacidadId;
                    _personaOFIM.IngresoPersonaId = personaOFIM.IngresoPersonaId;

                    
                    _db.PersonaOFIM.Add(_personaOFIM);
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
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            int recCount = _db.PersonaOFIM.Count(e => e.PersonaOFIMId == id);
            PersonaOFIM _personaOFIM = (from p in _db.PersonaOFIM
                                        where p.PersonaOFIMId == id
                                        select p).DefaultIfEmpty().Single();
            return View(_personaOFIM);
        }
        [HttpPost]
        public IActionResult Edit(PersonaOFIM personaOFIM)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarEstadoCivil();
                    cargarOcupacion();
                    cargarNacionalidad();
                    cargarNivelAcademico();
                    cargarSeguro();
                    return View(personaOFIM);
                }
                else
                {
                    _db.PersonaOFIM.Update(personaOFIM);
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
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            PersonaOFIM personaOFIM = _db.PersonaOFIM
                       .Where(e => e.PersonaOFIMId == id).First();
            return View(personaOFIM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var personaOFIM = await _db.PersonaOFIM.FindAsync(id);
            if (personaOFIM == null)
            {
                return NotFound();

            }
            return View(personaOFIM);
        }
        //POST - DELETE    //si se realiza una operacion es un POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var personaOFIM = await _db.PersonaOFIM.FindAsync(id);
            if (personaOFIM == null)
            {
                return View();
            }
            _db.PersonaOFIM.Remove(personaOFIM);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       



    }
}
