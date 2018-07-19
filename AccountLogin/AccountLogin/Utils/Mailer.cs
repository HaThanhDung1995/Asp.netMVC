using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AccountLogin.Utils
{
    public class Mailer
    {
        public static void Send(String to, String subject, String content)
        {
            var mail = new MailMessage();
            mail.From=new MailAddress("dunghtgs14003@fpt.edu.vn","Ha Thanh Dung");
            mail.Subject = subject;
            mail.To.Add(to);
            mail.Body=content;
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