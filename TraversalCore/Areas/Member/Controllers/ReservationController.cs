using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IGenericService<Destination> _destinationService;
        private readonly IGenericService<Reservation> _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IGenericService<Destination> destinationService, IGenericService<Reservation> reservationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.i = id;

            var itemList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Aktif Rezervasyonlarım" },
                new SelectListItem { Value = "2", Text = "Onay Bekleyen Rezervasyonlarım" },
                new SelectListItem { Value = "3", Text = "Geçmiş Rezervasyonlarım" }
            };

            ViewBag.val1 = itemList;

            var uservalues = await _userManager.FindByNameAsync(User.Identity.Name);

            if (id == 1 || id == 0)
            {
                ViewBag.RezervasyonBaslik = itemList[0].Text;
                var valuesList = _reservationService.TGetFilterWithIncludeById(uservalues.Id, "Onaylandı");
                return View(valuesList);
            }
            else if(id == 2)
            {
                ViewBag.RezervasyonBaslik = itemList[1].Text;
                var valuesList = _reservationService.TGetFilterWithIncludeById(uservalues.Id, "Onay Bekliyor");
                return View(valuesList);
            }
            else if(id == 3)
            {
                ViewBag.RezervasyonBaslik = itemList[2].Text;
                var valuesList = _reservationService.TGetFilterWithIncludeById(uservalues.Id, "Geçmiş Rezervasyon");
                return View(valuesList);
            }

            return View();
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationService.TGetList()
                select new SelectListItem
                {
                    Text = x.City,
                    Value = x.DestinationID.ToString(),
                }).ToList();

            ViewBag.v = values;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var uservalues = await _userManager.FindByNameAsync(User.Identity.Name);

            p.AppUserId = uservalues.Id;
            p.Status = "Onay Bekliyor";

            _reservationService.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }

    }
}
