using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCore.Models;
using TraversalCore.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();

            // Gönderecek kişinin bilgileri
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "gondericimail@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            // Alacak kişinin bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.ReceiverMail);
            mimeMessage.From.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = p.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = p.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("gondericimail@gmail.com", "sifre");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }




    }
}
