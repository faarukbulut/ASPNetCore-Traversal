using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalAPI.DAL.Context;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        Context c = new Context();

        [HttpGet]
        public IActionResult VisitorList()
        {
            var values = c.Visitors.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            c.Add(visitor);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            var values = c.Visitors.Find(id);

            if(values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            var values = c.Visitors.Find(id);

            if (values == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            var values = c.Find<Visitor>(visitor.VisitorID);

            if(values == null)
            {
                return NotFound();
            }
            else
            {
                values.NameSurname = visitor.NameSurname;
                values.City = visitor.City;
                values.Country = visitor.Country;
                values.Mail = visitor.Mail;

                c.Update(values);
                c.SaveChanges();

                return Ok();
            }




        }

    }
}
