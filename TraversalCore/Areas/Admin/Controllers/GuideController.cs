using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGenericService<Guide> _guideService;

        public GuideController(IGenericService<Guide> guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            guide.Status = true;
            _guideService.TAdd(guide);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            var values = _guideService.TGetById(id);

            if(values.Status == true)
            {
                values.Status = false;
            }
            else
            {
                values.Status = true;
            }

            _guideService.TUpdate(values);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteGuide(int id)
        {
            var values = _guideService.TGetById(id);
            _guideService.TDelete(values);
            return RedirectToAction("Index");
        }


    }
}
