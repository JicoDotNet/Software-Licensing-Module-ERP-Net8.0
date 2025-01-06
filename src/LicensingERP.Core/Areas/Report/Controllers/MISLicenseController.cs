using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicensingERP.Areas.Report.Models;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.BLL.Report;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using LicensingERP.Logic.DTO.ReportClass;
using Microsoft.AspNetCore.Mvc;

namespace LicensingERP.Core.Controllers
{
    [Area("Report")]
    [SessionAuthenticate]
    public class MISLicenseController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public IActionResult Requests()
        {
            UserClientLicenceProduct userClientLicenceProduct = new UserClientLicenceProduct
            {
                client = new ClientLogic(BllCommonLogic).GetClients(),
                licenceType = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                product = new ProductLogic(BllCommonLogic).GetProuct(),
                user = new UserLogic(BllCommonLogic).GetUsers()
            };
            return View(userClientLicenceProduct);
        }

        [HttpPost]
        public PartialViewResult GetLicenseReportInfo([FromBody]ReportOfRequest request)
        {
            request.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfRequest> requests = new List<ReportOfRequest>();
            requests = reportLogic.GetLicenseInfo(request);

            return PartialView("_PartialRequestView",requests);
        }

        public ActionResult RequestMovement()
        {
            UsertypeState usertypeState = new UsertypeState
            {
                UserTypes = new UserTypeLogic(BllCommonLogic).GetUserType(),
                WfStates = new WfStateLogic(BllCommonLogic).GetWfState()
            };

            return View(usertypeState);
        }

        [HttpPost]
        public PartialViewResult GetLicenseMovementReportInfo([FromBody]ReportOfRequestMovement reqMov )
        {
            reqMov.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfRequestMovement> reqMovs = new List<ReportOfRequestMovement>();
            reqMovs = reportLogic.GetRequestMovementInfo(reqMov);

            return PartialView("_PartialRequestMovementView", reqMovs);
        }

        public ActionResult Status()
        {
            return View();
        }

        public ActionResult TAT()
        {
            List<RequestStatus> global = new TurnAroundTimeLogic(BllCommonLogic).Calculate(id);
            return View(global);
        }

        [HttpPost]
        public PartialViewResult TAT([FromBody]RequisitionRequest request)
        {
            List<RequestStatus> global = new TurnAroundTimeLogic(BllCommonLogic).Calculate(request.RequestNo);
            return PartialView("_PartialTATView", global);
        }

        public ActionResult RequestMakerChecker()
        {
            LicenceTypeUserType licenceTypeUserType = new LicenceTypeUserType
            {
                licenceType = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                userTypes = new UserTypeLogic(BllCommonLogic).GetUserType()
            };

            return View(licenceTypeUserType);
        }

        [HttpPost]
        public PartialViewResult GetRequestMakerCheckerInfo([FromBody]ReportOfRequestMakerChecker reportOfRequestMakerChecker)
        {
            reportOfRequestMakerChecker.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfRequestMakerChecker> reportOfRequestMakerCheckers = new List<ReportOfRequestMakerChecker>();
            reportOfRequestMakerCheckers = reportLogic.GetRequestMakerChecker(reportOfRequestMakerChecker);

            return PartialView("_PartialRequestMakerCheckerView", reportOfRequestMakerCheckers);
        }

        public ActionResult XMLDownload()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetXMLDownloadInfo([FromBody]ReportOfXmlDownload reportOfXmlDownload)
        {
            reportOfXmlDownload.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfXmlDownload> reportOfXmlDownloads = new List<ReportOfXmlDownload>();
            reportOfXmlDownloads = reportLogic.GetXmlDownloadInfo(reportOfXmlDownload);

            return PartialView("_PartialXmlDownloadView", reportOfXmlDownloads);
        }

        public IActionResult Pending()
        {
            UserClientLicenceProduct userClientLicenceProduct = new UserClientLicenceProduct
            {
                client = new ClientLogic(BllCommonLogic).GetClients(),
                licenceType = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                product = new ProductLogic(BllCommonLogic).GetProuct(),
                user = new UserLogic(BllCommonLogic).GetUsers()
            };
            return View(userClientLicenceProduct);
        }

        [HttpPost]
        public PartialViewResult GetLicensePendingInfo([FromBody]ReportOfRequest request)
        {
            request.ToDateObject();
            ReportLogic reportLogic = new ReportLogic(BllCommonLogic);
            List<ReportOfRequest> requests = new List<ReportOfRequest>();
            requests = reportLogic.GetPendingInfo(request);

            return PartialView("_PartialRequestPendingView", requests);
        }
    }
}