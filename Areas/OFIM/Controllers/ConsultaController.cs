using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
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

    public class ConsultaController : Controller
    {
        private readonly DBSygestContext _db;
        List<ConsultaViewModel> listaConsulta = new List<ConsultaViewModel>();
        static List<ConsultaViewModel> lista = new List<ConsultaViewModel>();
        public ConsultaController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            listaConsulta = (from consulta in _db.Consulta
                               
                             join persona in _db.Persona
                             on consulta.PersonaId equals
                             persona.Id

                             join tipoConsulta in _db.TipoConsulta
                             on consulta.TipoConsultaId equals
                             tipoConsulta.TipoConsultaId

                             join estadoCivil in _db.EstadoCivil
                             on consulta.EstadoCivilId equals
                             estadoCivil.EstadoCivilId

                             join nacionalidad in _db.Nacionalidad
                             on consulta.NacionalidadId equals
                             nacionalidad.NacionalidadId

                             join nivelAcademico in _db.NivelAcademico
                             on consulta.NivelAcademicoId equals
                             nivelAcademico.NivelAcademicoId

                             join ocupacion in _db.Ocupacion
                             on consulta.OcupacionId equals
                             ocupacion.OcupacionId

                             join seguro in _db.Seguro
                             on consulta.SeguroId equals
                             seguro.SeguroId

                             //join ingreso in _db.IngresoPersona
                             //on consulta.IngresoPersonaId equals
                             //ingreso.IngresoPersonaId


                             select new ConsultaViewModel
                                 {
                                 ConsultaId = consulta.ConsultaId, 
                                 Motivo = consulta.Motivo,
                                 Fecha = consulta.Fecha,
                                 HoraInicio = consulta.HoraInicio,
                                 HoraFin = consulta.HoraFin,
                                 Descripcion = consulta.Descripcion,
                                 Respuesta = consulta.Respuesta,
                                 Remitir = consulta.Remitir,
                                 TipoConsultaId = tipoConsulta.TipoConsultaId,
                                 TipoConsulta = tipoConsulta.Nombre,
                                 PersonaId = persona.Id,
                                 
                                 NombrePersona = persona.Nombre + " " + persona.Ape1 + " " + persona.Ape2

                                 }).ToList();
            ViewBag.Controlador = "Consulta";
            ViewBag.Accion = "Index";
            return View(listaConsulta);
        }
        private void cargarPersona()
        {
            List<SelectListItem> listaPersona = new List<SelectListItem>();
            listaPersona = (from persona in _db.Persona
                            orderby persona.Nombre
                            select new SelectListItem
                            {
                                Text = persona.Nombre + " " + persona.Ape1 + " " + persona.Ape2,
                                Value = persona.Id.ToString()
                            }
                                ).ToList();
            ViewBag.ListaPersona = listaPersona;
        }

        private void cargarTipoConsulta()
        {
            List<SelectListItem> listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta = (from tipoConsulta in _db.TipoConsulta
                            orderby tipoConsulta.Nombre
                            select new SelectListItem
                            {
                                Text = tipoConsulta.Nombre,
                                Value = tipoConsulta.TipoConsultaId.ToString()
                            }
                                ).ToList();
            ViewBag.ListaTipoConsulta = listaTipoConsulta;
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

        private void cargarIngresoPersona()
        {
            List<SelectListItem> listaIngresoPersona = new List<SelectListItem>();
            listaIngresoPersona = (from ingresoPersona in _db.IngresoPersona
                                   orderby ingresoPersona.MontoMensual
                                   select new SelectListItem
                                   {
                                       Text = ingresoPersona.MontoMensual.ToString(),
                                       Value = ingresoPersona.IngresoPersonaId.ToString()
                                   }
                                ).ToList();
            ViewBag.ListaIngresoPersona = listaIngresoPersona;
        }

        private void Buscar(string PersonaId)
        {
            Persona oPersona = _db.Persona
          .Where(p => p.Id == PersonaId).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonaID = oPersona.Id;
                ViewBag.NombrePersona = oPersona.Nombre + " " + oPersona.Ape1 + " " + oPersona.Ape2;
            }
            else
            {
                ViewBag.Error = "Persona no registrada, intente de nuevo!";
            }
        }

        public IActionResult Create(string PersonaId)
        {
            cargarPersona();
            cargarTipoConsulta();
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            cargarIngresoPersona();

            if (PersonaId != null)
            {
                Buscar(PersonaId);
            }
            ViewBag.Controlador = "Consulta";
            ViewBag.Accion = "Create";
            return View();
        }



        public async Task<IActionResult> Created(Consulta consulta)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(consulta);
                }
                else
                {

                    Consulta _consulta = new Consulta();

                    _consulta.ConsultaId = consulta.ConsultaId;
                    _consulta.Motivo = consulta.Motivo;
                    _consulta.PersonaId = consulta.PersonaId;              
                    _consulta.Fecha = consulta.Fecha;
                    _consulta.HoraInicio = consulta.HoraInicio;
                    _consulta.HoraFin = consulta.HoraFin;
                    _consulta.Descripcion = consulta.Descripcion;
                    _consulta.Respuesta = consulta.Respuesta;
                    _consulta.Remitir = consulta.Remitir;
                    _consulta.Discapacidad = consulta.Discapacidad;
                    _consulta.Padecimiento = consulta.Padecimiento;              
                    _consulta.TipoConsultaId = consulta.TipoConsultaId;
                    _consulta.NacionalidadId = consulta.NacionalidadId;
                    _consulta.SeguroId = consulta.SeguroId;
                    _consulta.EstadoCivilId = consulta.EstadoCivilId;
                    _consulta.OcupacionId = consulta.OcupacionId;
                    _consulta.NivelAcademicoId = consulta.NivelAcademicoId;
                    _consulta.IngresoPersonaId = consulta.IngresoPersonaId;
                    _db.Consulta.Add(_consulta);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            cargarPersona();
            cargarTipoConsulta();
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            cargarIngresoPersona();
            Consulta oConsulta = _db.Consulta
                .Where(e => e.ConsultaId == Id).FirstOrDefault();
            return View(oConsulta);
        }

        [HttpPost]
        public IActionResult Edit(Consulta consulta)
        {
            string error = "";
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(consulta);
                }
                else
                {
                    _db.Consulta.Update(consulta);
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
            cargarPersona();
            cargarTipoConsulta();
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            cargarIngresoPersona();

            Consulta consulta = _db.Consulta
                       .Where(e => e.ConsultaId == id).First();
            return View(consulta);
        }
        public IActionResult Delete(int Id)
        {
            cargarPersona();
            cargarTipoConsulta();
            cargarEstadoCivil();
            cargarOcupacion();
            cargarNacionalidad();
            cargarNivelAcademico();
            cargarSeguro();
            cargarIngresoPersona();

            Consulta oConsulta = _db.Consulta
                 .Where(m => m.ConsultaId == Id).First();
            return View(oConsulta);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int ConsultaId)
        {
            string Error = "";
            try
            {
                Consulta oConsulta = _db.Consulta
                     .Where(c => c.ConsultaId == ConsultaId).First();
                if (oConsulta != null)
                {
                    _db.Consulta.Remove(oConsulta);
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
