using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFGA.Controllers
{
    [Area("OFGA")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexEduquemonos()
        {
            return View();
        }
        public IActionResult Ecoins()
        {
            return View();
        }
        public IActionResult Charlas()
        {
            return View();
        }
        public IActionResult CentroAcopio()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }


        public IActionResult GuardianesNaturaleza()
        {
            return View();
        }

        public IActionResult RecoleccionBasura()
        {
            return View();
        }
    }
}