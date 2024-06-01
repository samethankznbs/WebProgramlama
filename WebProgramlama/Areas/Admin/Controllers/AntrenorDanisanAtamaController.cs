using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata;
using yazlabyeto.Areas.Admin.Models;
using yazlabyeto.Models;

namespace yazlabyeto.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ADMİN")]
    public class AntrenorDanisanAtamaController : Controller
    {
        Context c = new Context();

        AntrenorManager antrenorManager = new AntrenorManager(new EFAntrenorRepository());
        DanisanManager danisanManager = new DanisanManager(new EFDanisanRepository());

        UserManager userManager = new UserManager(new EFUserRepository());


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DanisanList()
        {
           
            var list=danisanManager.TGetAll().ToList();
            
            return View(list);
        }


        [HttpGet]
        public IActionResult Eslestirme(int id)
        {
            TempData["AntrenorId"] = id;
            var danisanid =(int) TempData["danisanId"];
            var dan=c.Danisans.Find(danisanid);
            //var dan=danisanManager.GetDanisanById(danisanid).FirstOrDefault();
            dan.AppAntrenorId = id;
            c.SaveChanges();
            RedirectToAction("Index", "Admin");
           // danisanManager.TAdd(model);
            return View();
           
        }


        
        public async Task<IActionResult> Atamaİslemi(int id)
        {
            
          var danisan= c.Danisans.FirstOrDefault(x => x.DanisanId == id);
            TempData["danisanId"] = danisan.DanisanId;
            var listtt= antrenorManager.GetAntrenorByUzmanlikALani(danisan.hedef);
          
            return View(listtt);

    

        }

   

        }
    }
