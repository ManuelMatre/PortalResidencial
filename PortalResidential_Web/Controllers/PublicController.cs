using PortalResidential_Web.Business.ModelFactory;
using PortalResidential_Web.Business.Services;
using PortalResidential_Web.ExtensionMethods;
using PortalResidential_Web.Models;
using System.Web.Mvc;

namespace PortalResidential_Web.Controllers
{
    public class PublicController : Controller
    {
        DefaultAddressService defaultAddressService = new DefaultAddressService();
        AppUsersService appUsersService = new AppUsersService();

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            var availableAddressList = defaultAddressService.GetAll(availables: false);
            ViewBag.AddessList = availableAddressList.ToSelectItemList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LogInViewModel userLogin)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError("", "Hay un error en sus datos.");
            else
            {
                var appUser = appUsersService.Get(userLogin.id_address, userLogin.password);
                if (appUser == null)
                    ModelState.AddModelError("", "Contraseña incorrecta.");
                else
                {
                    Session["TokenAuth"] = new SessionUser{
                        username = appUser.nombre,
                        userid = appUser.id,
                        roles = "appuser"};//Cambiar...
                    Session["username"] = appUser.nombre;
                    return RedirectToAction("Index", "Home");
                }
            }
            var availableAddressList = defaultAddressService.GetAll(availables: false);
            ViewBag.AddessList = availableAddressList.ToSelectItemList();
            return View(userLogin);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var availableAddressList = defaultAddressService.GetAll();
            ViewBag.AddessList = availableAddressList.ToSelectItemList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel resident)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError("", "Hay un error en sus datos.");
            else
            {
                var saveOk = appUsersService.Save(resident.ToEntityModel());
                if(saveOk)
                {
                    var deleteOk = defaultAddressService.DeleteById(resident.id_address);
                    if (deleteOk)
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Ocurrió un error grave, porfavor contacte al administrador.");
            }
            var availableAddressList = defaultAddressService.GetAll();
            ViewBag.AddessList = availableAddressList.ToSelectItemList();
            return View(resident);
        }

        public ActionResult LogOut()
        {
            Session.Remove("TokenAuth");
            return RedirectToAction("Index", "Public");
        }
    }
}