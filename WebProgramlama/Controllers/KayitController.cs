using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using yazlabyeto.Models;

namespace yazlabyeto.Controllers
{
    [AllowAnonymous]
    public class KayitController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public KayitController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
           
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new KayitModel());
        }

        [HttpPost]
     
        public async Task<IActionResult> Index(KayitModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = new AppUser
                {
                    ad = model.ad,
                    soyad = model.soyad,
                    dogumTarihi = model.dogumTarihi,
                    cinsiyet = model.cinsiyet,
                    telefonNumarasi= model.telefonNumarasi,
                    Email = model.Email,
                    UserName=model.UserName
                    

                };
            
          var result = await _userManager.CreateAsync(user, model.Password);
            /*if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }*/
            if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            
            
            return View(model);
        }
     
    }
}
