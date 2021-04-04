using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.Admin.Models.ViewModel;
using SYGESTMunicipalSync.Filter;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(Seguridad))]
    public class UsuarioController : Controller
    {
        private readonly DBSygestContext _db;
        List<PersonaUsuario> listaUsuario = new List<PersonaUsuario>();
        List<Usuario> lista = new List<Usuario>();

        public UsuarioController(DBSygestContext db)
        {
            _db = db;
        }

        public List<PersonaUsuario> listarUsuarios()
        {
            listaUsuario = (from usuario in _db.Usuario
                            join _Persona in _db.Persona
                            on usuario.PersonaId
                            equals _Persona.CedulaPersona

                            select new PersonaUsuario
                            {
                                UsuarioId = usuario.UsuarioId,
                                NombreUsuario = usuario.NombreUsuario,
                                Password = usuario.NombreUsuario,
                                ConfirmarContrasena = usuario.Password,
                                PersonaId = _Persona.CedulaPersona +
                                          " " + _Persona.Nombre +
                                          " " + _Persona.Ape1,
                                }).ToList();
            return listaUsuario;
        }

        private void cargarPersona()
        {
            List<SelectListItem> listaPersona = new List<SelectListItem>();
            listaPersona = (from _Persona in _db.Persona
                            orderby _Persona.CedulaPersona
                            select new SelectListItem
                                {
                                    Text = _Persona.CedulaPersona + ", " 
                                    + _Persona.Nombre + " - " + _Persona.Ape1
                                    ,
                                    Value = _Persona.CedulaPersona.ToString()
                                }).ToList();
            ViewBag.ListaPersona = listaPersona;
        }
       




        public IActionResult Index()
        {
            return View();
        }
    }
}
