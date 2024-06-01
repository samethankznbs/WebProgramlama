
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using yazlabyeto.Areas.Admin.Models;
using yazlabyeto.Models;

namespace yazlabyeto.Controllers
{
    
    [Authorize(Roles = "ANTRENOR,ADMİN")]

    public class AntrenorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();

       AntrenorManager antrenorManager = new AntrenorManager(new EFAntrenorRepository());
       UserManager userManager = new UserManager(new EFUserRepository());
       EgzersizProgramiManager egzersizProgramiManager = new EgzersizProgramiManager(new EFEgzersizProgramiRepository());
       BeslenmePlaniManager beslenmePlaniManager = new BeslenmePlaniManager(new EFBeslenmePlaniRepository());


        public AntrenorController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
           // var usermail= c.Users.Where(x => x.UserName == username).Select(y => y.Email).ToList();
           // ViewBag.mailName = usermail;
           var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();

            var ad = c.Users.Where(x => x.Email == username).Select(y => y.ad).FirstOrDefault();

            //bu kısım o ide göre veri getirmek için sanırım

            var values= userManager.TGetById(id);
            ViewBag.id = id;
            ViewBag.ad = ad;

            return View(values);
           // return View(values);
        }

        public PartialViewResult AntrenorNavbarPartial()
        {
            return PartialView();
        }
      
       

        [HttpGet]
        public IActionResult EgzersizProgrami(int id)
        {

            TempData["DanisanId"] = id;

            return View();
        }



        [HttpPost]
        public IActionResult EgzersizProgrami(EgzersizProgramiModel model)
        {

            var danisanId = (int)TempData["DanisanId"];
            EgzersizProgrami e = new EgzersizProgrami
            {
                egzersizAdi=model.egzersizAdi,
                hedef=model.hedef,
                setSayisi=model.setSayisi,
                tekrarSayisi=model.tekrarSayisi,
                programBaslangicTarihi=model.programBaslangicTarihi,
                programSuresi=model.programSuresi,
                AppDanisanId=danisanId


            };

            egzersizProgramiManager.TAdd(e);

            return View(model);
        }

        [HttpGet]
        public IActionResult BeslenmePlani(int id)
        {

            TempData["DanisanId"] = id;

            return View();
        }


        [HttpPost]
        public IActionResult BeslenmePlani(BeslenmePlaniModel model)
        {
            var danisanId = (int)TempData["DanisanId"];
            BeslenmePlani b = new BeslenmePlani
            {
                hedef=model.hedef,
                gunlukOgun=model.gunlukOgun,
                kaloriHedef=model.kaloriHedef,
                beslenmePlanBaslangicTarihi=model.beslenmePlanBaslangicTarihi,
                planSuresi=model.planSuresi,
                AppDanisanId=danisanId
                
            };
            beslenmePlaniManager.TAdd(b);
            return View(model);
        }

        public IActionResult AntrenorBilgiList()
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            var values = antrenorManager.GetAntrenorByAppUserId(id);
            return View(values);
        }

        public IActionResult EgzersizBilgiList()
        {
            var values = egzersizProgramiManager.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult EgzersizGuncelle(int id)
        {
            var value = c.EgzersizProgramis.FirstOrDefault(x => x.Id == id);
            EgzersizProgramiModel model = new EgzersizProgramiModel
            {
                Id = value.Id,
                egzersizAdi = value.egzersizAdi,
                hedef = value.hedef,
                setSayisi = value.setSayisi,
                tekrarSayisi = value.tekrarSayisi,
                programBaslangicTarihi = value.programBaslangicTarihi,
                programSuresi = value.programSuresi,
              
                


            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EgzersizGuncelle(EgzersizProgramiModel model)
        {
            var values = c.EgzersizProgramis.Where(x => x.Id== model.Id).FirstOrDefault();
            values.egzersizAdi = model.egzersizAdi;
            values.hedef = model.hedef;
            values.setSayisi = model.setSayisi;
            values.tekrarSayisi = model.tekrarSayisi;
            values.programBaslangicTarihi = model.programBaslangicTarihi;
            values.programSuresi = model.programSuresi;
          
           

            egzersizProgramiManager.TUpdate(values);
            return View(model);
        }

        public IActionResult BeslenmeBilgiList()
        {
         
            var values = beslenmePlaniManager.TGetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult BeslenmeGuncelle(int id)
        {
            var value = c.BeslenmePlanis.FirstOrDefault(x => x.Id == id);
            BeslenmePlaniModel model = new BeslenmePlaniModel
            {
                Id = value.Id,
                hedef = value.hedef,
                gunlukOgun = value.gunlukOgun,
                kaloriHedef = value.kaloriHedef,
                beslenmePlanBaslangicTarihi = value.beslenmePlanBaslangicTarihi,
                planSuresi = value.planSuresi




            };

            return View(model);
        }

        [HttpPost]
        public IActionResult BeslenmeGuncelle(BeslenmePlaniModel model)
        {
            var values = c.BeslenmePlanis.Where(x => x.Id == model.Id).FirstOrDefault();
            values.hedef = model.hedef;
            values.gunlukOgun = model.gunlukOgun;
            values.kaloriHedef = model.kaloriHedef;
            values.beslenmePlanBaslangicTarihi = model.beslenmePlanBaslangicTarihi;
            values.planSuresi = model.planSuresi;



            beslenmePlaniManager.TUpdate(values);
            return View(model);
        }
        public IActionResult BeslenmeSil(int id)
        {
            //var values = c.BeslenmePlanis.FirstOrDefault(x => x.Id == id);
           var valuess =beslenmePlaniManager.TGetById(id);
            beslenmePlaniManager.TDelete(valuess);
           
            return RedirectToAction("BeslenmeBilgiList", "Antrenor");
           
           
        }

        public IActionResult EgzersizSil(int id)
        {
            //var values = c.BeslenmePlanis.FirstOrDefault(x => x.Id == id);
            var valuess = egzersizProgramiManager.TGetById(id);
            egzersizProgramiManager.TDelete(valuess);

            return RedirectToAction("EgzersizBilgiList", "Antrenor");


        }

        [HttpGet]
        public IActionResult BilgiEkleme()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> BilgiEkleme(AntrenorBilgiModel antrenorBilgiModel)
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            AppAntrenor appAntrenor = new AppAntrenor
            {
                UzmanlikAlani = antrenorBilgiModel.UzmanlikAlani,
                Deneyim = antrenorBilgiModel.Deneyim,
                AppUserId=id
                
            };
            antrenorManager.TAdd(appAntrenor);


          
            return View(antrenorBilgiModel);
        }


        [HttpGet]
        public IActionResult BilgiGuncelle(int id)
        {
            var value = c.Antrenors.FirstOrDefault(x => x.AntrenorId == id);
            AntrenorBilgiModel model = new AntrenorBilgiModel
            {
               AntrenorId=value.AntrenorId,
               UzmanlikAlani=value.UzmanlikAlani,
               Deneyim=value.Deneyim,
               AppUserId = value.AppUserId


            };

            return View(model);
        }

        [HttpPost]
        public IActionResult BilgiGuncelle(AntrenorBilgiModel model)
        {
            var values = c.Antrenors.Where(x => x.AntrenorId == model.AntrenorId).FirstOrDefault();

            values.UzmanlikAlani = model.UzmanlikAlani;
            values.Deneyim = model.Deneyim;
            values.AppUserId = model.AppUserId;

            antrenorManager.TUpdate(values);
            return View(model);
        }

        public IActionResult BilgiSil(int id)
        {
            //var values = c.BeslenmePlanis.FirstOrDefault(x => x.Id == id);
            var valuess = antrenorManager.TGetById(id);
            antrenorManager.TDelete(valuess);

            return RedirectToAction("AntrenorBilgiList", "Antrenor");


        }



        [HttpGet]
        public IActionResult KisiselBilgiGuncelle()
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();

            var values = userManager.TGetById(id);
            KullaniciGuncelleModel model = new KullaniciGuncelleModel
            {
                Id = values.Id,
                ad = values.ad,
                soyad = values.soyad,
                dogumTarihi = values.dogumTarihi,
                cinsiyet = values.cinsiyet,
                telefonNumarasi = values.telefonNumarasi,
                Email = values.Email,
                UserName = values.UserName,
                
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> KisiselBilgiGuncelle(KullaniciGuncelleModel model)
        {
         
            var values = _userManager.Users.Where(x => x.Id == model.Id).FirstOrDefault();

            values.ad = model.ad;
            values.soyad = model.soyad;
            values.dogumTarihi = model.dogumTarihi;
            values.cinsiyet = model.cinsiyet;
            values.telefonNumarasi = model.telefonNumarasi;
            values.Email = model.Email;
            values.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Antrenor");
            }

            return View(model);
        }


    }
}
