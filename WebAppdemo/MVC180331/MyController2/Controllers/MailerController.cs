using MyController2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class MailerController : Controller
    {
        // GET: Mailer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send(Mail model)
        {
            // Tạo thư
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(model.From, model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.ReplyToList.Add(mail.From);

            try
            {
                // Kết nối bưu điện
                var smtp = new SmtpClient("smtp.gmail.com", 25)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("javapostoffice@gmail.com", "javapostoffice@2000")
                };

                // Gửi thư
                smtp.Send(mail);

                ViewBag.Message = "Gửi mail thành công";
            }
            catch
            {
                ViewBag.Message = "Gửi mail thất bại";
            }

            return View("Index");
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Send2(Mail model)
        {
            var f = Request.Files["Attach"];
            var path = Server.MapPath("~/Files/" + f.FileName);
            f.SaveAs(path);

            // Tạo thư
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(model.From, model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.ReplyToList.Add(mail.From);
            mail.Attachments.Add(new Attachment(path));

            try
            {
                // Kết nối bưu điện
                var smtp = new SmtpClient("smtp.gmail.com", 25)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("javapostoffice@gmail.com", "javapostoffice@2000")
                };

                // Gửi thư
                smtp.Send(mail);

                ViewBag.Message = "Gửi mail thành công";
            }
            catch
            {
                ViewBag.Message = "Gửi mail thất bại";
            }

            return View("Index2");
        }
    }
}