using Microsoft.AspNetCore.Mvc;
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
        List<RegistroExternoVM> listaRegistro = new List<RegistroExternoVM>();
        static List<RegistroExternoVM> lista = new List<RegistroExternoVM>();

        public RegistroController(DBSygestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
