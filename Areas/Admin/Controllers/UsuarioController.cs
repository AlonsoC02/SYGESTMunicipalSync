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
   // [ServiceFilter(typeof(Seguridad))]
    public class UsuarioController : Controller
    {
        private readonly DBSygestContext _db;
        List<RegistroExternoVM> listaUsuario = new List<RegistroExternoVM>();
        

        public UsuarioController(DBSygestContext db)
        {
            _db = db;
        }
        //INDEX
        public IActionResult Index()
        {
            listaUsuario = (from usuario in _db.Usuario

                            join _Persona in _db.Persona
                            on usuario.PersonaId
                            equals _Persona.CedulaPersona

                            join _Rol in _db.Rol
                            on usuario.RolId
                            equals _Rol.RolId

                            select new RegistroExternoVM
                            {
                                UsuarioId = usuario.UsuarioId,
                                NombreUsuario = usuario.NombreUsuario,
                                Password = usuario.NombreUsuario,
                                PersonaId = _Persona.CedulaPersona,
                                NombrePersona = _Persona.Nombre +
                                          " " + _Persona.Ape1 +
                                          " " + _Persona.Ape2,
                                NombreRol = _Rol.Nombre
                            }).ToList();
            ViewBag.Controlador = "Usuario";
            ViewBag.Accion = "Index";
            return View(listaUsuario);
        }

        private void cargarRol()
        {
            List<SelectListItem> listaRol = new List<SelectListItem>();
            listaRol = (from _Rol in _db.Rol
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

       
        public IActionResult ListarPersona()
        {
            List<Persona> listaPersona = new List<Persona>();

            listaPersona = (from persona in _db.Persona 
                            select new Persona
                                {
                                CedulaPersona = persona.CedulaPersona,
                                Nombre = persona.Nombre,
                                Ape1= persona.Ape1,
                                Ape2= persona.Ape2,
                                Email = persona.Email,
                                FechaNac = persona.FechaNac,
                                TelMovil = persona.TelMovil
                            }).ToList();
            return View(listaPersona);
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
                              NombrePersona = _persona.Nombre + " " + _persona.Ape1+ " " + _persona.Ape2,
                              RolId = _usuario.RolId,
                              NombreRol = _rol.Nombre,
                              
                          }).ToList();
        }

        public IActionResult Details(int Id)
        {
            buscarUsuario(Id);
            return View(listaUsuario);
        }
     
        public async Task<IActionResult> Created(RegistroExternoVM usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    cargarRol();
                }
                else
                {
                   
                    Usuario _usuario = new Usuario();
                  
                    _usuario.NombreUsuario = usuario.NombreUsuario;
                    _usuario.Password = usuario.Password;
                    _usuario.PersonaId = usuario.PersonaId;
                    _usuario.RolId = usuario.RolId;
                    _db.Usuario.Add(_usuario);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            
            return RedirectToAction(nameof(Index));

        }





    }
}
