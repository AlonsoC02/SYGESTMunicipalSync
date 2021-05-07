using Microsoft.AspNetCore.Mvc;
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
    }
}
