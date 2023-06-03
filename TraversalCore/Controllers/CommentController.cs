using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Controllers
{
    public class CommentController : Controller
    {
        private readonly IGenericService<Comment> _commentService;

        public CommentController(IGenericService<Comment> commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            p.DestinationID = 3;
            p.CommentUser = "Faruk Bulut";
            _commentService.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
    }
}
