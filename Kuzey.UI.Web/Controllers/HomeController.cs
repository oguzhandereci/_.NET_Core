using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Kuzey.BLL.Repository;
using Kuzey.MODELS.Entities;
using Microsoft.AspNetCore.Mvc;
using Kuzey.UI.Web.Models;
using Kuzey.BLL.Repository.Abstracts;
using Microsoft.AspNetCore.Identity;
using Kuzey.MODELS.IdentityEntities;

namespace Kuzey.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category, int> _categoryRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(IRepository<Category, int> categoryRepo, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _categoryRepo = categoryRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (!_categoryRepo.Queryable().Any())
            {
                _categoryRepo.Insert(new Category()
                {
                    CategoryName = "Beverages"
                });

                _categoryRepo.Insert(new Category()
                {
                    CategoryName = "Condiments"
                });

            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
