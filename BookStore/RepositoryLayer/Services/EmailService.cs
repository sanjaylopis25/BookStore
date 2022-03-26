using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailService
    {
        public static void sendmail(string EmailId, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("lopezsanjay2@gmail.com", "Sanjay123");

                MailMessage msgobj = new MailMessage();
                msgobj.To.Add(EmailId);
                msgobj.From = new MailAddress("lopezsanjay2@gmail.com");
                msgobj.Subject = "password reset link";
                //msgobj.Body = $"BookStoreApplication/{token}";
                msgobj.Body = $"www.BookStoreApplication.com/reset-password/{token}";
                client.Send(msgobj);
            }
        }
        //public static void sendMail(string EmailId, string token)
        //{
        //    using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
        //    {

        //        client.EnableSsl = true;
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.UseDefaultCredentials = true;
        //        client.Credentials = new NetworkCredential("lopezsanjay2@gmail.com", "Sanjay123");

        //        MailMessage msgObj = new MailMessage();
        //        msgObj.To.Add(EmailId);
        //        msgObj.From = new MailAddress("lopezsanjay2@gmail.com");
        //        msgObj.Subject = "Password Reset Link";
        //        msgObj.Body = $"Bookstore/{token}";
        //        client.Send(msgObj);
        //    }
        //}
    }
}
