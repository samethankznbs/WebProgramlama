using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using yazlabyeto.Areas.Admin.Models;
using yazlabyeto.Models;

namespace yazlabyeto.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ADMİN")]
    public class AdminUserController : Controller
    {
      
        private readonly UserManager<AppUser> _userManager;

        public AdminUserController( UserManager<AppUser> userManager)
        {
           
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
            


        }

        [HttpGet]
        public IActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciEkle(KayitModel model)
        {
           
                AppUser user = new AppUser
                {
                   ad = model.ad,
                   soyad = model.soyad,
                   dogumTarihi = model.dogumTarihi,
                   cinsiyet = model.cinsiyet,
                   telefonNumarasi = model.telefonNumarasi,
                   UserName = model.UserName,
                   Email = model.Email,

                    ConfirmCodee = 0
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Admin");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            
            return View(model);
        

        }


        [HttpGet]
        public IActionResult KullaniciGuncelle(int id)
        {
            var values = _userManager.Users.FirstOrDefault(x => x.Id == id);
            KullaniciGuncelleModel model = new KullaniciGuncelleModel
            {
                Id= values.Id,
                ad = values.ad,
                soyad=values.soyad,
                dogumTarihi=values.dogumTarihi,
                cinsiyet=values.cinsiyet,
                telefonNumarasi=values.telefonNumarasi,
                Email=values.Email,
                UserName=values.UserName,
                ConfirmCodee = values.ConfirmCodee


            };
            return View(model);
         
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciGuncelle(KullaniciGuncelleModel model)
        {
            var values = _userManager.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            values.ad = model.ad;
            values.soyad = model.soyad;
            values.dogumTarihi = model.dogumTarihi;
            values.cinsiyet = model.cinsiyet;
            values.telefonNumarasi = model.telefonNumarasi;
            values.Email = model.Email;
            values.UserName = model.UserName;
            values.ConfirmCodee = model.ConfirmCodee;

            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Admin");
            }
            return View(model);
        }


       
        public async Task<IActionResult> KullaniciSilme(int id)
        {
            var values = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var result = await _userManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Admin");
            }
            return View();
        }

    }
}
