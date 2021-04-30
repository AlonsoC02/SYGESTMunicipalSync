using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.Admin.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistroController : Controller
    {
        private readonly DBSygestContext _db;
        List<RegistroExternoVM> listaUsuario = new List<RegistroExternoVM>();
        static List<RegistroExternoVM> lista = new List<RegistroExternoVM>();

        public RegistroController(DBSygestContext db)
        {
            _db = db;
        }
        private void buscarUsuario(int Id)
        {
            listaUsuario = (from _usuario in _db.Usuario
                            join _rol in _db.Rol on _usuario.RolId equals _rol.RolId

                            join _persona in _db.Persona on _usuario.PersonaId equals _persona.CedulaPersona
                            where _usuario.UsuarioId == Id
                            select new RegistroExternoVM
                            {
                                UsuarioId = _usuario.UsuarioId,
                                NombreUsuario = _usuario.NombreUsuario,
                                PersonaId = _usuario.PersonaId,
                                NombrePersona = _persona.Nombre + " " + _persona.Ape1 + " " + _persona.Ape2,
                                RolId = _usuario.RolId,
                                NombreRol = _rol.Nombre,
                                Password = Utilitarios.DescifrarDatos(_usuario.Password)

                            }).ToList();
        }
        public IActionResult MiPerfil()
        {
            int UsuarioId = Int32.Parse(HttpContext.Session.GetString("UsuarioId"));
            buscarUsuario(UsuarioId);
            return View();
        }

        private void cargarRol()
        {
            List<SelectListItem> listaRol = new List<SelectListItem>();
            listaRol = (from _Rol in _db.Rol where _Rol.Nombre == "Guest"
                        orderby _Rol.RolId
                        select new SelectListItem
                        {
                            Text = _Rol.Nombre,
                            Value = _Rol.RolId.ToString()
                        }).ToList();
            ViewBag.ListaRol = listaRol;
        }

        public IActionResult Create(string PersonaId)
        {
            cargarRol();
            if (PersonaId != null)
            {
                BuscarPersona(PersonaId);
            }
            ViewBag.Controlador = "Usuario";
            ViewBag.Accion = "Create";
            return View();
        }

        [HttpPost]
        private void BuscarPersona(string PersonaId)
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


        public IActionResult ListarPersona(string PersonaId)
        {
            List<Persona> listaPersona = new List<Persona>();
            listaPersona = (from persona in _db.Persona where persona. CedulaPersona ==PersonaId
                            select new Persona
                            {
                                CedulaPersona = persona.CedulaPersona,
                                Nombre = persona.Nombre,
                                Ape1 = persona.Ape1,
                                Ape2 = persona.Ape2,
                                Email = persona.Email,
                                FechaNac = persona.FechaNac,
                                TelMovil = persona.TelMovil
                            }).ToList();
            return View(listaPersona);
        }


        public async Task<IActionResult> Created(Usuario usuario)
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
                    Usuario _usuario = new Usuario();
                    _usuario.NombreUsuario = usuario.NombreUsuario;
                    _usuario.Password = password;
                    _usuario.PersonaId = usuario.PersonaId;
                    _usuario.RolId = usuario.RolId;
                    _db.Usuario.Add(_usuario);
                    await _db.SaveChangesAsync();
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
