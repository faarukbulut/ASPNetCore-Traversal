using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IGenericService<AppUser> _appUserService;
        private readonly IGenericService<Reservation> _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IGenericService<AppUser> appUserService, IGenericService<Reservation> reservationService, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetById(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }

        public async Task<IActionResult> ReservationUser(int id)
        {
            var uservalues = await _userManager.FindByIdAsync(id.ToString());
            var values = _reservationService.TGetFilterWithIncludeById(uservalues.Id, "Onaylandı");

            return View(values);
        }

    }
}
