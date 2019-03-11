using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity_.NETCore.Data;
using Identity_.NETCore.Models.Enums;
using Identity_.NETCore.Models.IdentityModels;
using Identity_.NETCore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_.NETCore.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager, ApplicationDbContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "Kayıt işlemi başarısız";
                return View(model);
            }

            var user = new AppUser()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await CreateRoles();
                if (_userManager.Users.Count() == 1)
                {
                    await _userManager.AddToRoleAsync(user, IdentityRoles.Admin.ToString());
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, IdentityRoles.User.ToString());
                }
                return RedirectToAction(nameof(Login));
            }
            else
            {
                var errorMsg = "";
                foreach (var error in result.Errors)
                {
                    errorMsg += error.Description;
                }

                ModelState.AddModelError(String.Empty, errorMsg);
                return View(model);
            }


        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(String.Empty, "Kullanıcı adı veya şifre hatalı");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task CreateRoles()
        {
            var roles = Enum.GetNames(typeof(IdentityRoles));
            foreach (var role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    await _roleManager.CreateAsync(new AppRole()
                    {
                        Name = role
                    });
                }
            }
        }
    }
}