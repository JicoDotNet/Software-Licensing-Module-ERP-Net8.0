using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.ReportClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LicensingERP.Controllers
{
    [SessionAuthenticate]
    public class NotificationController : BaseController
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLicenceExpireAlert()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            var Config = builder.Build();

            int duration = Int32.Parse(Config.GetSection("Licence").GetSection("Duration").Value);

            NotificationLogic notificationLogic = new NotificationLogic(BllCommonLogic);
            List<ReportOfRequest> requests = new List<ReportOfRequest>();
            requests = notificationLogic.GetLicenseExpiry(duration);

            return Json(requests.Count());
        }

        public ActionResult ListLicenceExpiry()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            var Config = builder.Build();

            int duration = Int32.Parse(Config.GetSection("Licence").GetSection("Duration").Value);

            NotificationLogic notificationLogic = new NotificationLogic(BllCommonLogic);
            List<ReportOfRequest> requests = new List<ReportOfRequest>();
            requests = notificationLogic.GetLicenseExpiry(duration);

            return View(requests);
        }

    }
}