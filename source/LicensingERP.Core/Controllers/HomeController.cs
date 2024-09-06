using LicensingERP.Logic.BLL;
using LicensingERP.Logic.BLL.Dashboard;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Controllers
{
    [SessionAuthenticate]
    public class HomeController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new DashboardAccessLogic(BllCommonLogic).GetAccessPermission(SessionPerson.UserTypeId));
        }

        public PartialViewResult GroupWiseUser()
        {
            return PartialView("_PartialDSUserGroup", new DSGroupWiseUserLogic(BllCommonLogic).GetGraphData());
        }

        public PartialViewResult Master()
        {
            return PartialView("_PartialDSMaster", new MasterLogic(BllCommonLogic).Get());
        }

        public PartialViewResult LicenseRequest()
        {
            return PartialView("_PartialDSLicenseRequest", new DSRequestWiseLicenseLogic(BllCommonLogic).GetGraphData());
        }

        public PartialViewResult ClientWiseLicenseRequest()
        {
            DSClientWiseLicense dSClientWiseLicense = new DSClientWiseLicense
            {
                LicenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                ClientWiseLicenseRequests = new DSClientWiseLicenseRequestLogic(BllCommonLogic).GetGraphData()
            };
            return PartialView("_PartialDSClientWiseLicenseRequest", dSClientWiseLicense);
        }

        public PartialViewResult LicenseExpiringOn()
        {
            return PartialView("_PartialDSLicenseExpiringOn", new DSLicenseExpiringOnLogic(BllCommonLogic).GetGraphData());
        }
        
        public PartialViewResult ApprovalPending()
        {
            return PartialView("_PartialDSApprovalPending", new DSApprovalPendingLogic(BllCommonLogic).GetGraphData());
        }
    }
}