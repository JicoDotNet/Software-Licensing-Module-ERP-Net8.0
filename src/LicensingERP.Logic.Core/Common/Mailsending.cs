using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace LicensingERP.Logic.Common
{
    public class Mailsending
    {
        public void SendMailToUser(Email email)
        {
            try
            {
                //email.To = "waitforu00@gmail.com";// email.To;
                email.Subject = "Test Subject";// email.Subject;
                email.Body = "This is for testing";// email.Body;

                email.Cc = "";
                email.Bcc = "";

                email.Cc = string.IsNullOrEmpty(email.Cc) ? email.Cc : "";
                email.Bcc = string.IsNullOrEmpty(email.Bcc) ? email.Bcc : "";

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(email.To);
                mailMessage.Subject = email.Subject;
                mailMessage.Body = email.Body;
                mailMessage.From = new MailAddress(email.FromEmail);
                mailMessage.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient(email.Domain);
                smtp.Port = email.Port;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(email.UserName, email.Password);
                smtp.Send(mailMessage);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
