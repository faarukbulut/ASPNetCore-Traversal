using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        private readonly IGenericService<Guide> _guideService;

        public _GuideList(IGenericService<Guide> guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
    }
}
