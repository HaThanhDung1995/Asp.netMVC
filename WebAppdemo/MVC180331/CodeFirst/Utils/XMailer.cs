using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CodeFirst.Utils
{
    public class XMailer
    {
        public static void Send(String To, String Subject, String Content)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("songlong2k@gmail.com", "Nhat Nghe");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Content;
            mail.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com", 25)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("javapostoffice@gmail.com", "javapostoffice@2000")
            };

            smtp.Send(mail);
        }
    }
}