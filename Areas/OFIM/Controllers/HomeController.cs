using Microsoft.AspNetCore.Mvc;
using SYGESTMunicipalSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipalSync.Areas.OFIM.Controllers
{
    [Area("OFIM")]
    public class HomeController : Controller
    {
        
        private readonly DBSygestContext _db;
         public HomeController(DBSygestContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index()
        //{
        //    IndexViewModel IndexVM = new IndexViewModel()
        //    {
        //        Actividad = await
        //            _db.Actividad.Where(m => m.IsActive == true).Include(m => m.Category).Include(m => m.Eje).ToListAsync(),
        //        Category = await _db.Category.ToListAsync(),
        //        //Actividad = await _db.Actividad.Where(c => c.IsActive == true).ToListAsync()
        //    };

        //    return View(IndexVM);
        //}

    }
}
