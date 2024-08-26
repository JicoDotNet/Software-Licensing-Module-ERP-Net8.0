using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using LicensingERP.Logic.DTO.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LicensingERP.Controllers
{
    public class EmailController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        //[HttpPost]
        public IActionResult Index(Email email)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            var Config = builder.Build();

            Email emailConfig = new Email();

            emailConfig.Domain = Config.GetSection("Email").GetSection("Domain").Value;
            emailConfig.Port = Int32.Parse(Config.GetSection("Email").GetSection("Port").Value);
            emailConfig.UserName = Config.GetSection("Email").GetSection("UserName").Value;
            emailConfig.Password = Config.GetSection("Email").GetSection("Password").Value;
            emailConfig.FromEmail = Config.GetSection("Email").GetSection("FromEmail").Value;

            

            //emailConfig.To = "waitforu00@gmail.com";// email.To;
            //emailConfig.Subject = "Test Subject";// email.Subject;
            //emailConfig.Body = "This is for testing";// email.Body;

            //email.Cc = "";
            //email.Bcc = "";

            //emailConfig.Cc = string.IsNullOrEmpty(email.Cc) ? email.Cc : "";
            //emailConfig.Bcc = string.IsNullOrEmpty(email.Bcc) ? email.Bcc : "";
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.To.Add(emailConfig.To);
            //mailMessage.Subject = emailConfig.Subject;
            //mailMessage.Body = emailConfig.Body;
            //mailMessage.From = new MailAddress(emailConfig.FromEmail);
            //mailMessage.IsBodyHtml = false;

            //SmtpClient smtp = new SmtpClient(emailConfig.Domain);
            //smtp.Port = emailConfig.Port;
            //smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = true;
            //smtp.Credentials = new System.Net.NetworkCredential(emailConfig.UserName, emailConfig.Password);
            //smtp.Send(mailMessage);

            return View();
        }
    }
}
