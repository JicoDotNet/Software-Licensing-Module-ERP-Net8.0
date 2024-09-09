using System;
using System.Collections.Generic;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.BLL.Report;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.ReportClass;
using Microsoft.AspNetCore.Mvc;

namespace LicensingERP.Core.Areas.Report.Controllers
{
    [Area("Report")]
    [SessionAuthenticate]
    public class MISUserController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public ActionResult UserReport()
        {
            UserTypeLogic usertypelogic = new UserTypeLogic(BllCommonLogic);
            List<UserType> userType = usertypelogic.GetUserType();

            return View(userType);
        }
        
        [HttpPost]
        public PartialViewResult GetUsersList([FromBody]ReportOfUser user)
        {
            user.UserTypeId = Convert.ToInt32(user.UserTypeId);
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfUser> users = new List<ReportOfUser>();
            users = reportLogic.GetUsertype(user);

            return PartialView("_PartialReportView", users);
        }

        [HttpPost]
        public PartialViewResult GetLoginReportInfo([FromBody]ReportOfUserLogin userlogin)
        {
            userlogin.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfUserLogin> userLogins = new List<ReportOfUserLogin>();
            userLogins = reportLogic.GetLoginInfo(userlogin);

            return PartialView("_PartialLoginView", userLogins);
        }

        [HttpPost]
        public PartialViewResult GetActivityReportInfo([FromBody]ReportOfActivity reportOfActivity)
        {
            reportOfActivity.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfActivity> reportOfActivities = new List<ReportOfActivity>();
            reportOfActivities = reportLogic.GetActivityInfo(reportOfActivity);

            return PartialView("_PartialActivityView", reportOfActivities);
        }

        public ActionResult Activity()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult MakerCheckerReport()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetMakerCheckerReportInfo([FromBody]ReportOfMakerChecker reportOfMakerChecker)
        {
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfMakerChecker> reportOfMakerCheckers = new List<ReportOfMakerChecker>();
            reportOfMakerCheckers = reportLogic.GetMakerCheckerInfo(reportOfMakerChecker);

            return PartialView("_PartialMakerCheckerView", reportOfMakerCheckers);
        }

        [HttpPost]
        public PartialViewResult GetStatusReportInfo([FromBody]ReportOfStatus reportOfStatus)
        {
            reportOfStatus.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfStatus> reportOfStatuses = new List<ReportOfStatus>();
            reportOfStatuses = reportLogic.GetStatusInfo(reportOfStatus);

            return PartialView("_PartialStatusView", reportOfStatuses);
        }
    }
}