using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Areas.Admin.Models;
using SYGESTMunicipalSync.Areas.Admin.Models.ViewModel;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DBSygestContext _db;
        List<UsuarioTipoUsuario> listaUsuario = new List<UsuarioTipoUsuario>();
        List<Usuario> lista = new List<Usuario>();

        public UsuarioController(DBSygestContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
