using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IGenericService<Destination> _destinationService;

        public DestinationController(IGenericService<Destination> destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.i = id;
            var values = _destinationService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult Details(Destination p)
        {
            return View();
        }
    }
}
