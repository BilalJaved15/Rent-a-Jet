using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Jet
{
    public static class SMTP
    {
        public static void mailTo(String senderMail, String subject, String body) {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("rentalJet12345@gmail.com");
                mail.To.Add(senderMail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;
                mail.Attachments.Add(new Attachment("..\\..\\..\\reciept.pdf"));
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("rentalJet12345@gmail.com", "One1Two2Three3");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
