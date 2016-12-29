using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace surplus_auctioneer_console
{
    static class EmailService
    {
        public static int SendEmail(string subject, string body, string password)
        {
            try
            {

                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");

                mySmtpClient.Port = 587;
                mySmtpClient.EnableSsl = true;

                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential("wi.auctioneer", password);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("wi.auctioneer@gmail.com", "WI Auctioneer");
                MailAddress toNick = new MailAddress("nick.heidke@gmail.com", "Nick Heidke");
                MailAddress toJohn = new MailAddress("john.s.kozlowski@gmail.com", "John Koz");
                MailMessage myMail = new MailMessage();

                myMail.To.Add(toNick);
                myMail.To.Add(toJohn);
                myMail.From = from;

                // add ReplyTo
                MailAddress replyTo = new MailAddress("noreply@gmail.com");
                myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = subject;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = body;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
                return 0;
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
