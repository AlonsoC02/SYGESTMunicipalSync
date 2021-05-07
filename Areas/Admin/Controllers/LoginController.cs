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
    [Area("Admin")]
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
            int nVeces = _db.Usuario.Where(u => u.NombreUsuario == user
            && u.Password == claveCifrada).Count();

                if (nVeces != 0)
                {
                    rpta = "OK";
                    Usuario User = _db.Usuario.Where(u => u.NombreUsuario == user
                            && u.Password == claveCifrada).First();

                    HttpContext.Session.SetString("usuarioId", User.UsuarioId.ToString());
                    HttpContext.Session.SetString("nombreUsuario", User.NombreUsuario);

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

                    //Utilitarios.MenuADMIN = "";
                    //Utilitarios.MenuDep = "";
                   
                    Utilitarios.ListaMenu.Clear();
                    Utilitarios.ListaController.Clear();
                    Utilitarios.ListaAccion.Clear();

                    ViewBag.User = User.NombreUsuario;
                    foreach (Pagina _Pagina in lista)
                    {
                        Utilitarios.ListaMenu.Add(_Pagina.Menu);
                        Utilitarios.ListaController.Add(_Pagina.Controlador);
                        Utilitarios.ListaAccion.Add(_Pagina.Accion);

                        if (_Pagina.Controlador == "Persona" ||
                            _Pagina.Controlador == "Usuario" ||
                            _Pagina.Controlador == "RolUsuario" ||
                             _Pagina.Controlador == "Pagina"||
                            _Pagina.Controlador == "RolUsuarioPag" ||
                            _Pagina.Controlador == "RolUsuarioPagBoton"
                            )

                        {
                            Utilitarios.MenuADMIN = "Administrador";
                        }

                        if (_Pagina.Controlador == "Home" )
                        {
                            Utilitarios.MenuCons = "Departamentos";
                        }
                        if (_Pagina.Controlador == "Empresariedad" ||
                            _Pagina.Controlador == "Denuncia" ||
                            _Pagina.Controlador == "Home" )
                        {
                            Utilitarios.MenuEmpre = "Servicios Digitales";
                        }
                        

                    }
                    //https://www.tiracodigo.com/index.php/programacion/mvc/formas-de-almacenar-datos-temporales-en-asp-net-mvc-viewdata-viewbag-tempdata-y-session
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
            miNombre = HttpContext.Session.GetString("NombreUsuario");
            return View(miNombre);
        }
    
    }
}
