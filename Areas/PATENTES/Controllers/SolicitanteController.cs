using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models;
using SYGESTMunicipalSync.Areas.PATENTES.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.PATENTES.Controllers
{
    [Area("PATENTES")]
    public class SolicitanteController : Controller
    {

        private readonly DBSygestContext _db;
        List<SolicitanteViewModel> listaSolicitante = new List<SolicitanteViewModel>();
        static List<SolicitanteViewModel> lista = new List<SolicitanteViewModel>();
        public SolicitanteController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaSolicitante = (from solicitante in _db.Solicitante
                                join persona in _db.Persona
                               on solicitante.PersonaId equals
                               persona.CedulaPersona

                                join contacto in _db.Contacto
                                on solicitante.ContactoId equals
                                contacto.ContactoId

                                join tipoRepresentante in _db.TipoRepresentante
                                on solicitante.TipoRepresentanteId equals
                                tipoRepresentante.TipoRepresentanteId
                                select new SolicitanteViewModel{

                               SolicitanteId = solicitante.SolicitanteId,
                               CedulaJuridica = solicitante.CedulaJuridica,
                               NombreRazonSocial= solicitante.NombreRazonSocial,
                               TipoRepresentante = tipoRepresentante.Nombre,
                               Contacto = contacto.MedioNotificacion,
                               PersonaId = persona.Nombre

                                }).ToList();
            lista = listaSolicitante;
            return View(listaSolicitante);
        }

        private void cargarContacto()
        {
            List<SelectListItem> listaContacto = new List<SelectListItem>();
            listaContacto = (from contacto in _db.Contacto
                             orderby contacto.MedioNotificacion
                             select new SelectListItem
                             {
                                 Text = contacto.MedioNotificacion,
                                 Value = contacto.ContactoId.ToString()
                             }
                                   ).ToList();
            ViewBag.ListaTContacto = listaContacto;
        }

        private void cargarTipoRepresentante()
        {
            List<SelectListItem> listaRepresentante = new List<SelectListItem>();
            listaRepresentante = (from representante in _db.TipoRepresentante
                             orderby representante.Nombre
                             select new SelectListItem
                             {
                                 Text = representante.Nombre,
                                 Value = representante.TipoRepresentanteId.ToString()
                             }
                                   ).ToList();
            ViewBag.ListaTRepresentante = listaRepresentante;
        }
        private void Buscar(string PersonaId)
        {
            Persona oPersona = _db.Persona
          .Where(p => p.CedulaPersona == PersonaId).FirstOrDefault();
            if (oPersona != null)
            {
                ViewBag.PersonaID = oPersona.CedulaPersona;
                ViewBag.NombrePersona = oPersona.Nombre + " " + oPersona.Ape1;
            }
            else
            {
                ViewBag.Error = "Persona no registrada, intente de nuevo!";
            }
        }
        public IActionResult Create(string PersonaId)
        {
            cargarContacto();
            cargarTipoRepresentante();
            if (PersonaId != null)
            {
                Buscar(PersonaId);
            }
            ViewBag.Controlador = "Solicitante";
            ViewBag.Accion = "Create";
            return View();
        }
        public async Task<IActionResult> Created(Solicitante solicitante)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(solicitante);
                }
                else
                {
                    //string password = Utilitarios.CifrarDatos(usuario.Password);
                    Solicitante _usuario = new Solicitante();

                    _usuario.SolicitanteId = solicitante.SolicitanteId;
                    _usuario.PersonaId = solicitante.PersonaId;
                    _usuario.ContactoId = solicitante.ContactoId;
                    _usuario.TipoRepresentanteId = solicitante.TipoRepresentanteId;
                    _usuario.CedulaJuridica = solicitante.CedulaJuridica;
                    _usuario.NombreRazonSocial = solicitante.NombreRazonSocial;
                    _db.Solicitante.Add(_usuario);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
            //return RedirectToAction(Areas.PATENTES.Controllers.SolicitanteController(Index));
        }
        public IActionResult Edit(int? id)
        {
            cargarContacto();
            cargarTipoRepresentante();
            int recCount = _db.Solicitante.Count(e => e.SolicitanteId == id);
            Solicitante _materials = (from p in _db.Solicitante
                                     where p.SolicitanteId == id
                                     select p).DefaultIfEmpty().Single();
            return View(_materials);
        }
        [HttpPost]
        public IActionResult Edit(Solicitante materials)
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
                    _db.Solicitante.Update(materials);
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
