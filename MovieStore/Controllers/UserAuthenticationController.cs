using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.DTO;
using MovieStore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;

        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }

        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Email = "admin@gmail.com",
        //        Username = "admin",
        //        Name = "Developer",
        //        Password = "12345",
        //        PasswordConfirm = "12345",
        //        Role = "Admin",
        //    };
        //    var result = await authService.RegisterAsync(model);
        //    return Ok(result.Message);
        //}

        public IActionResult Login()  //public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if (result.StatusCode==1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Could not logged in...";
                return RedirectToAction(nameof(Login));
            }
        }
    }
}
