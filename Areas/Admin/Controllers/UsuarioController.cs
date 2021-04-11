using Microsoft.AspNetCore.Http;
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
    [Area("Admin")]
    [ServiceFilter(typeof(Seguridad))]
    public class UsuarioController : Controller
    {
        private readonly DBSygestContext _db;
        List<PersonaUsuario> listaUsuario = new List<PersonaUsuario>();
        List<PersonaUsuario> lista = new List<PersonaUsuario>();

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

       //INDEX
        public IActionResult Index()
        {
            listaUsuario = listarUsuarios();
            return View(listaUsuario);
        }

        //GET CREATE
        [HttpGet]
        public IActionResult Create()
        {
            cargarPersona();
            return View();
        }


        //POST CREATE
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            string Error = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }
                else
                {
                    string password = Utilitarios.CifrarDatos(usuario.Password);
                    string ConfirmarContrasena = Utilitarios.CifrarDatos(usuario.ConfirmarContrasena);
                    Usuario _usuario = new Usuario();
                    _usuario.UsuarioId = usuario.UsuarioId;
                    _usuario.NombreUsuario = usuario.NombreUsuario;
                    _usuario.PersonaId = usuario.PersonaId;
                    _usuario.Password = password;
                    _usuario.ConfirmarContrasena = ConfirmarContrasena;
                    _db.Usuario.Add(_usuario);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            cargarPersona();
            int recCount = _db.Usuario.Count(e => e.UsuarioId == id);
            Usuario _usuario = (from u in _db.Usuario
                                where u.UsuarioId == id
                                select u).DefaultIfEmpty().Single();
            _usuario.Password = Utilitarios.DescifrarDatos(_usuario.Password);
            _usuario.ConfirmarContrasena = Utilitarios.DescifrarDatos(_usuario.ConfirmarContrasena);
            return View(_usuario);
        }

        //GET EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int UsuarioId = Int32.Parse(HttpContext.Session.GetString("UsuarioId"));
            if (UsuarioId == id)
            {
                cargarPersona();
                int recCount = _db.Usuario.Count(e => e.UsuarioId == id);
                Usuario _usuario = (from u in _db.Usuario
                                    where u.UsuarioId == id
                                    select u).DefaultIfEmpty().Single();
                _usuario.Password = Utilitarios.DescifrarDatos(_usuario.Password);
                _usuario.ConfirmarContrasena = Utilitarios.DescifrarDatos(_usuario.ConfirmarContrasena);
                return View(_usuario);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        //POST EDIT
        [HttpPost]
        public IActionResult Edit(Usuario _Usuario)
        {
            string rpta = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    //Escribimos nuestra logica
                    var query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();

                    rpta += "<ul class='list-group'>";
                    foreach (var item in query)
                    {
                        rpta += "<li class='list-group-item list-group-item-danger'>";
                        rpta += item;
                        rpta += "</li>";
                    }
                    rpta += "</ul>";
                }
                else
                {
                    rpta = "OK";
                    string pass = Utilitarios.CifrarDatos(_Usuario.Password);
                    string confirm = Utilitarios.CifrarDatos(_Usuario.ConfirmarContrasena);
                    Usuario user = new Usuario();
                    user.UsuarioId = _Usuario.UsuarioId;
                    user.NombreUsuario = _Usuario.NombreUsuario;
                    user.PersonaId = _Usuario.PersonaId;
                    user.Password = pass;
                    user.ConfirmarContrasena = confirm;
                    _db.Usuario.Update(user);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        //DELETE
        [HttpPost]
        public IActionResult Delete(int UsuarioId)
        {
            var Error = "";
            try
            {
                Usuario usuario = _db.Usuario
                             .Where(e => e.UsuarioId == UsuarioId).First();
                _db.Usuario.Remove(usuario);
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
