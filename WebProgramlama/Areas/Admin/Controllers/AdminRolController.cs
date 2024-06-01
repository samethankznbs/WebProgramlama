
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yazlabyeto.Areas.Admin.Models;
using yazlabyeto.Models;

namespace yazlabyeto.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize (Roles="ADMİN")]
    public class AdminRolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;


       // AntrenorManager ant = new AntrenorManager(new EFAntrenorRepository());

        public AdminRolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
           var rolvalues= _roleManager.Roles.ToList();
            return View(rolvalues);
        }

        [HttpGet]
        public IActionResult RolEkleme()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> RolEkleme(RolModel rol)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name =rol.name,
                    //IsDelete = 0
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(rol);
        }
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> RolAtama(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RolAtamaModel> model = new List<RolAtamaModel>();
            foreach (var item in roles)
            {
                RolAtamaModel r = new RolAtamaModel();
                r.RoleID = item.Id;
                r.Name = item.Name;
                r.Exists = userRoles.Contains(item.Name);
                model.Add(r);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RolAtama(List<RolAtamaModel> m)
        {

            var kullaniciId = (int)TempData["UserId"];
            //kullaniciId sisteme  otantike olan kullaniciyi tutacak.
            var kullanici = _userManager.Users.FirstOrDefault(x => x.Id == kullaniciId);
            // eger itemin tiki seciliyse onu kullanıcının rolune ekle
            foreach (var item in m)
            {
                if (item.Exists)
                {
                    //o kullanıcıya sistemden secilen rolu ekliyor.
                    await _userManager.AddToRoleAsync(kullanici, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(kullanici, item.Name);
                }
            }
            return RedirectToAction("Index","Admin");

        }

     }


}
