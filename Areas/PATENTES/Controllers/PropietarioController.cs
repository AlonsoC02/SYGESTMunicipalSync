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
    public class PropietarioController : Controller
    {
        private readonly DBSygestContext _db;
        List<PropietarioViewModel> listaPropietario = new List<PropietarioViewModel>();
        static List<PropietarioViewModel> lista = new List<PropietarioViewModel>();
        public PropietarioController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            listaPropietario = (from propietario in _db.Propietario
                                join persona in _db.Persona
                               on propietario.PersonaId equals
                               persona.Id

                                join contacto in _db.Contacto
                                on propietario.ContactoId equals
                                contacto.ContactoId

                                
                                select new PropietarioViewModel
                                {

                                    PropietarioId = propietario.PropietarioId,
                                    Contacto = contacto.MedioNotificacion,
                                    PersonaId = persona.Nombre

                                }).ToList();
            lista = listaPropietario;
            return View(listaPropietario);
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
            
            if (PersonaId != null)
            {
                Buscar(PersonaId);
            }
            ViewBag.Controlador = "Solicitante";
            ViewBag.Accion = "Create";
            return View();
        }
        public async Task<IActionResult> Created(Propietario propietario)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(propietario);
                }
                else
                {
                    //string password = Utilitarios.CifrarDatos(usuario.Password);
                    Propietario _propietario = new Propietario();

                    _propietario.PropietarioId = propietario.PropietarioId;
                    _propietario.PersonaId = propietario.PersonaId;
                    _propietario.ContactoId = propietario.ContactoId;
                    _db.Propietario.Add(_propietario);
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
    }
}
