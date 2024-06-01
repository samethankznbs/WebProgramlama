using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yazlabyeto.Areas.Admin.Models;
using yazlabyeto.Models;

namespace yazlabyeto.Controllers
{
   
    [Authorize(Roles = "DANİSAN,ADMİN")]
    public class DanisanController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();

       DanisanManager danisanManager = new DanisanManager(new EFDanisanRepository());
       UserManager userManager = new UserManager(new EFUserRepository());

        EgzersizProgramiManager egzersizProgramiManager = new EgzersizProgramiManager(new EFEgzersizProgramiRepository());
        BeslenmePlaniManager beslenmePlaniManager = new BeslenmePlaniManager(new EFBeslenmePlaniRepository());

        public DanisanController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            var ad = c.Users.Where(x => x.Email == username).Select(y => y.ad).FirstOrDefault();

            //bu kısım o ide göre veri getirmek için sanırım

            var values = userManager.TGetById(id);
            ViewBag.id = id;
            ViewBag.ad = ad;

            return View(values);
           
        }

        public PartialViewResult DanisanNavbarPartial()
        {
           
            return PartialView();
        }

       
        [HttpGet]
        public IActionResult İlerlemeKayitEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult İlerlemeKayitEkle(DanisanİlerlemeKayitModel model)
        {

            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();

            AppDanisan appDanisan = new AppDanisan
            {
               
                hedef=model.hedef,
                kilo=model.kilo,
                boy=model.boy,
                vucutYagOrani=model.vucutYagOrani,
                kasKutlesi=model.kasKutlesi,
                vucutKitleİndex=model.vucutKitleİndex,
                AppUserId = id

            };
            danisanManager.TAdd(appDanisan);
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult AntrenoreGoreDanisanList()
        {

            var username = User.Identity.Name;

            var userid = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            var antrenorID = c.Antrenors.Where(x => x.AppUserId == userid).Select(y => y.AntrenorId).FirstOrDefault();

            var values = danisanManager.GetDanisanListWithAntrenor(antrenorID);

            return View(values);
        }

        public IActionResult DanisanBilgiList()
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            var values = danisanManager.GetDanisanByAppUserId(id);
            return View(values);
        }

        public IActionResult EgzersizProgramList()
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            var idd = c.Danisans.Where(x => x.AppUserId == id).Select(y => y.DanisanId).FirstOrDefault();
            var values=  egzersizProgramiManager.GetEgzersizByAppDanisanId(idd);
           

            return View(values);
        }


        public IActionResult BeslenmePlanList()
        {
            var username = User.Identity.Name;
            var id = c.Users.Where(x => x.Email == username).Select(y => y.Id).FirstOrDefault();
            var idd = c.Danisans.Where(x => x.AppUserId == id).Select(y => y.DanisanId).FirstOrDefault();
            var values = beslenmePlaniManager.GetBeslenmeByAppDanisanId(idd);


            return View(values);
        }


        [HttpGet]
        public IActionResult İlerlemeKayitGuncelle(int id)
        {
            // var value = danisanManager.TGetById(id);
            
         var value = c.Danisans.FirstOrDefault(x => x.DanisanId == id);

        DanisanİlerlemeKayitModel model = new DanisanİlerlemeKayitModel
        {

            
                DanisanId=value.DanisanId,
                hedef=value.hedef,
                kilo=value.kilo,
                boy=value.boy,
                vucutYagOrani=value.vucutYagOrani,
                kasKutlesi=value.vucutKitleİndex,
                vucutKitleİndex=value.vucutKitleİndex,
                AppUserId=value.AppUserId


        };

            return View(model);
        }

        [HttpPost]
        public IActionResult İlerlemeKayitGuncelle(DanisanİlerlemeKayitModel model)
        {

            var values = c.Danisans.Where(x => x.DanisanId == model.DanisanId).FirstOrDefault();

            values.hedef = model.hedef;
            values.kilo = model.kilo;
            values.boy = model.boy;
            values.vucutYagOrani = model.vucutYagOrani;
            values.kasKutlesi = model.kasKutlesi;
            values.vucutKitleİndex = model.vucutKitleİndex;
            values.AppUserId = model.AppUserId;

            danisanManager.TUpdate(values);
            return View(model);
        }
        public IActionResult İlerlemeKayitSil(int id)
        {
            //var values = c.BeslenmePlanis.FirstOrDefault(x => x.Id == id);
            var valuess = danisanManager.TGetById(id);
            danisanManager.TDelete(valuess);

            return RedirectToAction("DanisanBilgiList", "Danisan");


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
                return RedirectToAction("Index", "Danisan");
            }

            return View(model);
        }

    }
}
