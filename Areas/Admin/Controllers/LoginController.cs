using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly DBSygestContext _db;

        public LoginController(DBSygestContext db)
        {
            _db = db;
        }
        public string _Login(string user, string pass)
        {
            string rpta = "";
            string claveCifrada = Utilitarios.CifrarDatos(pass);
            try
            {

                int nVeces = _db.Usuario.Where(u => u.NombreUsuario == user
                && u.Password == claveCifrada).Count();
                if (nVeces != 0)
                {
                    rpta = "OK";
                    Usuario User = _db.Usuario.Where(u => u.NombreUsuario == user
                            && u.Password == claveCifrada).First();
                    HttpContext.Session.SetString("UsuarioId", User.UsuarioId.ToString());
                    HttpContext.Session.SetString("nombreUsuario", User.NombreUsuario);
                    //int idTipo = User.TipoUsuarioId;
                    List<Pagina> lista = new List<Pagina>();
                    lista = (from pgt in _db.RolUsuarioPag
                             join pagina in _db.Pagina
                             on pgt.PaginaId equals pagina.PaginaId
                             where pgt.BotonHabilitado == true
                             && pgt.RolId == User.RolId
                             select new Pagina
                             {
                                 Menu = pagina.Menu,
                                 Controlador = pagina.Controlador,
                                 Accion = pagina.Accion
                             }).ToList();
                    Utilitarios.listaPagina = lista;
                    List<Pagina> ListaBoton = (from pgtb in _db.RolUsuarioPagBoton
                                               join tup in _db.RolUsuarioPag
                                               on pgtb.RolUsuarioPagBotonId
                                               equals tup.RolUsuarioPagId
                                               join pag in _db.Pagina
                                               on tup.PaginaId equals pag.PaginaId
                                               where tup.RolId == User.UsuarioId
                                               && pgtb.BotonHabilitado == true
                                               && tup.BotonHabilitado == true
                                               select new Pagina
                                               {
                                                   PaginaId = (int)tup.PaginaId,
                                                   Controlador = pag.Controlador
                                               }).ToList();
                    Utilitarios.listaBotonesPagina = ListaBoton;

                    Utilitarios.MenuMant = "";
                    Utilitarios.MenuCons = "";
                   
                    Utilitarios.ListaMenu.Clear();
                    Utilitarios.ListaController.Clear();
                    Utilitarios.ListaAccion.Clear();
                    ViewBag.User = User.NombreUsuario;
                    foreach (Pagina _Pagina in lista)
                    {
                        Utilitarios.ListaMenu.Add(_Pagina.Menu);
                        Utilitarios.ListaController.Add(_Pagina.Controlador);
                        Utilitarios.ListaAccion.Add(_Pagina.Accion);
                        if (_Pagina.Controlador == "Especialidad" ||
                            _Pagina.Controlador == "Medico" ||
                            _Pagina.Controlador == "Enfermedad" ||
                            _Pagina.Controlador == "Paciente")

                        {
                            Utilitarios.MenuMant = "Mantenimiento";
                        }
                        if (_Pagina.Controlador == "ConsultaEspecialidades" ||
                            _Pagina.Controlador == "ConsultaCitas" ||
                            _Pagina.Controlador == "ConsultaPacientes" ||
                            _Pagina.Controlador == "ConsultaTipoUsuario")
                        {
                            Utilitarios.MenuCons = "Consultas";
                        }
                        if (_Pagina.Controlador == "TipoUsuarios" ||
                            _Pagina.Controlador == "Usuario" ||
                            _Pagina.Controlador == "AsignaRol" ||
                            _Pagina.Controlador == "DeterminarRol" ||
                            _Pagina.Controlador == "Pagina")
                        {
                            Utilitarios.MenuEmpre = "Accesibilidad";
                        }
                        if (_Pagina.Controlador == "Citas")
                        {
                            Utilitarios.MenuEmpre = "Citas";
                        }

                    }
                    //https://www.tiracodigo.com/index.php/programacion/mvc/formas-de-almacenar-datos-temporales-en-asp-net-mvc-viewdata-viewbag-tempdata-y-session
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Remove("usuarioId");
            return RedirectToAction("Index");
        }

        public ActionResult MuestraNombre()
        {
            string miNombre;
            miNombre = HttpContext.Session.GetString("nombreUsuario");
            return View(miNombre);
        }
        //public ActionResult MuestraNombre(ActionExecutingContext context)
        //{
        //    string miNombre;
        //    miNombre = context.HttpContext.Session.GetString("nombreUsuario"); 
        //    return View(miNombre);
        //}
        //public ActionResult Index()
        //{
        //    System.Web.HttpContext.Current.Session["User "] = User.Nombre;
        //    return RedirectToAction("MuestraNombre");
        //}
    }
}
