using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yazlabyeto.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace yazlabyeto.Controllers
{
    public class MesajController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        MesajManager mesajManager = new MesajManager(new EFMesajRepository());
        private readonly Context _context;

        public MesajController(UserManager<AppUser> userManager, Context context)
        {

            _userManager = userManager;
            _context = context;
        }
        [HttpPost]
        public IActionResult TumKullanicilar(int id)
        {
            List<AppUser> kullanicilar= _userManager.Users.ToList();
            var viewmodel = new AppUserViewModel
            {
                Users = kullanicilar
            };

            ViewBag.Id = id;

            return View(viewmodel);
        }


        public IActionResult MesajEkrani(int gonderen_id, int alici_id)
        {
          
          
            
            ViewBag.gonderen_id = gonderen_id;
            ViewBag.alici_id = alici_id;


            List<mesaj> mesajlarim = _context.mesajlar.Where(m => (m.gonderen_id == gonderen_id && m.durum_kontrol == true && m.alici_id == alici_id) || (m.alici_id == gonderen_id && m.durum_kontrol == false && m.gonderen_id == alici_id))
  .ToList();

       
            var model = new MesajViewModel
            {
                Mesajlar = mesajlarim
            };





            return View(model);
        }
        [HttpPost]
        public IActionResult MesajGonder(int kullanici_id, int antrenor_id, string mesaj)
        {
            Context _context = new Context();
            var yenimesaj = new mesaj
            {

                gonderen_id = kullanici_id,
                text = mesaj,
                alici_id = antrenor_id,
                durum_kontrol = false

            };

            // Veritabanına yeni veriyi ekle
            _context.mesajlar.Add(yenimesaj);
            _context.SaveChanges();


            return RedirectToAction("MesajEkrani", new { gonderen_id = antrenor_id, alici_id = kullanici_id });

        }



    }
}
