using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstCore.Models;

namespace FirstCore.Controllers
{
    public class HomeController : Controller
    {
        private List<Kisi> kisiler = new List<Kisi>()
        {
            new Kisi()
            {
                Ad = "Abdo",
                Soyad = "Abdo"
            },
            new Kisi()
            {
                Ad = "Keke",
                Soyad = "Keke"
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(kisiler);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
