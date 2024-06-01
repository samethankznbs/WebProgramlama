using Azure.Core;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using yazlabyeto.Models;
using DataAccessLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace yazlabyeto.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
       // private readonly RoleManager<AppRole> _roleManager;
        Context c = new Context();
        UserManager userManager = new UserManager(new EFUserRepository());

     

        public LoginController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager=userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(new LoginModel());
        }


        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model)
        {
            /*   var user = await _userManager.FindByNameAsync(model.UserName);
               if (user == null)
               {
                   return View(model);
               }*/

           var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

            var user = await _userManager.FindByNameAsync(model.UserName);
          
           
           var id = c.Users.Where(x => x.Email == user.UserName).Select(y => y.Id).FirstOrDefault();

            if (result.Succeeded )
            {
             

              var deger=  c.UserRoles.Where(x => x.UserId == id).Select(y => y.RoleId).FirstOrDefault();

                if (deger == 10)
                {
                    return RedirectToAction("Index", "Admin");
                }

                else if(deger==11)
                {
                    return RedirectToAction("Index", "Antrenor");
                }

                else
                {
                    return RedirectToAction("Index", "Danisan");
                }

            /*    var antrenorid = c.Antrenors.FirstOrDefault(x => x.AppUserId == id);

                if ( antrenorid!=null )
                {
                    return RedirectToAction("Index", "Antrenor");
                }

                else  
                {
                    var danisanid = c.Danisans.FirstOrDefault(x => x.AppUserId == id);
                    if (danisanid != null)
                    {
                        return RedirectToAction("Index", "Danisan");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    
                }*/

              

            }
                else
              {
                 TempData["ErrorMessage"] = "Kullanıcı adınız veya parolanız hatalı lütfen tekrar deneyiniz.";
                return View(model);
              }

            return View();
        }

       
    }
}
