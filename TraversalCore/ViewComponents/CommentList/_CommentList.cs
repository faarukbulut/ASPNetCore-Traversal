using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.CommentList
{
    public class _CommentList : ViewComponent
    {
        private readonly IGenericService<Comment> _commentService;

        public _CommentList(IGenericService<Comment> commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetFilterById(id, "");
            return View(values);
        }
    }
}
