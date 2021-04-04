using Microsoft.AspNetCore.Mvc;
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

        //public List<PersonaUsuario> listarUsuarios()
        //{
        //    listaUsuario = (from usuario in _db.Usuario
        //                    join _Persona in _db.Persona
        //                    on usuario.PersonaId 
        //                    equals _Persona.CedulaPersona

        //                    join _Distrito in _db.Distrito
        //                    on usuario.DistritoId equals
        //                    _Distrito.DistritoId

        //                    select new PersonaUsuario
        //                    {
        //                        UsuarioId = usuario.UsuarioId,
        //                        NombreUsuario = usuario.NombreUsuario,
        //                        Password = usuario.NombreUsuario,
        //                        ConfirmarContrasena = usuario.Password,
        //                        NombrePersona = _Persona.Nombre,
        //                        Distrito = _Distrito.DistritoId,
        //                    }).ToList();
        //    return listaUsuario;
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
