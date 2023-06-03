using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.AdminDashboard
{
    public class _Card1Statistic : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.V1 = c.Destinations.Count();
            ViewBag.V2 = c.Users.Count();
            return View();
        }
    }
}
