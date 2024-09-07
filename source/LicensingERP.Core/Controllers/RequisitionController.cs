using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LicensingERP.Core.Controllers
{
    [SessionAuthenticate]
    public class RequisitionController : BaseController
    {
        private readonly IRequestRestrictMetaValueService _restrictMetaValueService;

        public RequisitionController(
            IAppSettingsService appSettingsService,
            IRequestRestrictMetaValueService restrictMetaValueService) : base(appSettingsService)
        {
            _restrictMetaValueService = restrictMetaValueService;
        }

        public IActionResult Index()
        {
            if (id == null)
            {
                LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(BllCommonLogic);
                ClientLogic clientLogic = new ClientLogic(BllCommonLogic);
                ProductLogic productLogic = new ProductLogic(BllCommonLogic);
                UserLogic ULogic = new UserLogic(BllCommonLogic);
                _LicencetypeClientProduct _licencetypeClientProduct = new _LicencetypeClientProduct
                {
                    restrictMetaData = _restrictMetaValueService.GetRestrictMetaValues(),
                    licenceType = licenceTypeLogic.GetLicenceType(),
                    client = clientLogic.GetClients(),
                    product = productLogic.GetProuct(),
                    users = ULogic.GetUser(SessionPerson.UserId)
                };
                return View(_licencetypeClientProduct);
            }
            else
            {
                LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(BllCommonLogic);
                ClientLogic clientLogic = new ClientLogic(BllCommonLogic);
                ProductLogic productLogic = new ProductLogic(BllCommonLogic);
                UserLogic ULogic = new UserLogic(BllCommonLogic);
                _LicencetypeClientProduct _licencetypeClientProduct = new _LicencetypeClientProduct
                {
                    licenceType = licenceTypeLogic.GetLicenceType(),
                    client = clientLogic.GetClients(),
                    product = productLogic.GetProuct(),
                    users = ULogic.GetUser(SessionPerson.UserId),
                    compareLList = new LicenceCompareLogic(BllCommonLogic).CompareLicenceDisplay(id)
                };
                return View(_licencetypeClientProduct);
            }
        }

        public PartialViewResult BindRestrictMetaData(int noOfLicence = 1)
        {
            RequestRestrictsMeta requestRestrictMetas = _restrictMetaValueService.GetRestrictMetaValues();
            IList<RequestRestrictsMeta> requestRestrictMet = new List<RequestRestrictsMeta>();
            for (int i = 0; i < noOfLicence; i++)
            {
                requestRestrictMet.Add(requestRestrictMetas);
            }
            return PartialView("_PartialRestrictMetaData", requestRestrictMet);
        }

        public JsonResult GetRestrictMetaData()
        {
            return Json(_restrictMetaValueService.GetRestrictMetaValues());
        }

        //[HttpPost]
        //public ActionResult Index(Request request)
        //{
        //    RequestLogic requestLogic = new RequestLogic(BllCommonLogic);
        //    request.RequestNo = GenericLogic.IstNow.TimeStamp().ToString();
        //    int flag = 0;
        //    flag = requestLogic.Insert(request);
        //    if(flag >0)
        //    {
        //        ReturnMessage = new ReturnObject
        //        {
        //            Status = true,
        //            Message = "Data Submitted Successfully !!"
        //        };
        //    }

        //    else
        //    {
        //        ReturnMessage = new ReturnObject
        //        {
        //            Status = false,
        //            Message = "Error To Submit!!"
        //        };
        //    }
        //    return RedirectToAction("LicenseRequest", "Requisition", new { id = flag });
        //}
        //public ActionResult LicenseRequest()
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        ReturnMessage = new ReturnObject
        //        {
        //            Status = false,
        //            Message = "Request Id Not Found!!"
        //        };
        //        return RedirectToAction("Index", "Requisition");
        //    }

        //    return View(new RequestLogic(BllCommonLogic).GetRequest(Convert.ToInt32(id)));
        //}

        public PartialViewResult GetParameter([FromBody] ParameterOfLicence parameterOfLicence)
        {
            RequestLogic requestLogic = new RequestLogic(BllCommonLogic);
            return PartialView("_PartialParameter", new LicencetypeParameterLogic(BllCommonLogic).GetLicenceofParameter(parameterOfLicence.LicenseTypeId));
        }

        [HttpGet]
        public JsonResult GetWFStatus()
        {
            return Json(new WfStateLogic(BllCommonLogic)
                .GetWfState(SessionPerson.UserTypeId, Convert.ToInt32(id), true).FirstOrDefault());
        }

        [HttpGet]
        public JsonResult GetProductFeature()
        {
            return Json(new ProductFeaturesModule
            {
                Features = new ProductFeaturesLogic(BllCommonLogic).GetDatas(Convert.ToInt32(id))
            });
        }

        [HttpPost]
        public JsonResult SubmitRequest([FromBody] object requestObject)
        {
            RequisitionRequest request = JsonConvert.DeserializeObject<RequisitionRequest>(requestObject.ToString());
            request.ToDateObject();
            request.UserId = SessionPerson.UserId;
            request.UserTypeId = SessionPerson.UserTypeId;
            request.RequestNo = GenericLogic.IstNow.TimeStamp().ToString("X");
            RequestLogic requestLogic = new RequestLogic(BllCommonLogic);
            int result = requestLogic.Insert(request);


            #region Mail Config
            //List<User> users = new MailUserListLogic(BllCommonLogic).MailUserRequisition(SessionPerson.UserTypeId);
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            //var Config = builder.Build();

            //Email emailConfig = new Email();

            //emailConfig.Domain = Config.GetSection("Email").GetSection("Domain").Value;
            //emailConfig.Port = Int32.Parse(Config.GetSection("Email").GetSection("Port").Value);
            //emailConfig.UserName = Config.GetSection("Email").GetSection("UserName").Value;
            //emailConfig.Password = Config.GetSection("Email").GetSection("Password").Value;
            //emailConfig.FromEmail = Config.GetSection("Email").GetSection("FromEmail").Value;

            //foreach (User user in users)
            //{
            //    emailConfig.To = user.Email;
            //    new Mailsending().SendMailToUser(emailConfig);
            //}
            #endregion

            return Json(result);
        }
        [HttpPost]
        public ActionResult AdminProceed(ByPassRequisitionClaim byPass)
        {
            bool result = new RequestLogic(BllCommonLogic).ClaimUserExits(Convert.ToInt32(id));
            if (result)
            {
                int flag = new RequestLogic(BllCommonLogic).Claim(Convert.ToInt32(id), byPass.BUserId, byPass.BNextUserTypeId, true);
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "You have claimed this request Successfully !!"
                };
            }

            RequestProceed requestProceed = new RequestProceed
            {
                LicenseRequest =
                new RequestLogic(BllCommonLogic)
                    .GetRequest(Convert.ToInt32(id), byPass.BUserId, byPass.BNextUserTypeId, true)
            };
            requestProceed.WfStates = new WfStateLogic(BllCommonLogic).GetWfState(byPass.BNextUserTypeId, requestProceed.LicenseRequest.LicenceTypeId, false);
            requestProceed.RequestAcknowledgements = new RequestAcknowledgementLogic(BllCommonLogic).GetDatas(Convert.ToInt32(id));

            return View(requestProceed);
        }
        public ActionResult Pending()
        {
            if (SessionPerson.UserId == 1)
            {
                if (string.IsNullOrEmpty(id))
                    return View(new RequestLogic(BllCommonLogic).AdminRequisitionList());
                else
                {
                    RequisitionClaim requisition = new RequestLogic(BllCommonLogic).GetRequisitionClaimDetails(Convert.ToInt32(id));
                    // SessionPerson.BUsertypeId = requisition.NextUserTypeId;
                    return View("SinglePending", new RequestLogic(BllCommonLogic).GetRequest(Convert.ToInt32(id), requisition.ClaimUserId, requisition.NextUserTypeId, true));
                }
            }
            else
            {
                if (string.IsNullOrEmpty(id))
                    return View(new RequestLogic(BllCommonLogic).GetRequests(SessionPerson.UserId, SessionPerson.UserTypeId));
                else
                    return View("SinglePending", new RequestLogic(BllCommonLogic).GetRequest(Convert.ToInt32(id), SessionPerson.UserId, SessionPerson.UserTypeId));
            }
        }

        public ActionResult Status()
        {
            return View(new RequestLogic(BllCommonLogic).GetRequests(SessionPerson.UserId));
        }

        public FileResult Download()
        {
            try
            {
                XmlDownload xmlDownload = new XmlDownload(BllCommonLogic);
                string RequestNo = "Empty";
                MemoryStream memoryStreamOfLicense = xmlDownload.GetDownloadData(SessionPerson.UserId, SessionPerson.UserTypeId, 
                    Convert.ToInt32(id), Convert.ToInt32(id2), out RequestNo);


                if (memoryStreamOfLicense != null)
                    return File(memoryStreamOfLicense, "text/xml", RequestNo + "-" + id2 + ".lic");
                else
                    return File(new MemoryStream(), "text", "Error.log");
            }
            catch (Exception ex)
            {
                MemoryStream memoryStream = new MemoryStream();
                StreamWriter writer = new StreamWriter(memoryStream);
                writer.Write(JsonConvert.SerializeObject(ex, Newtonsoft.Json.Formatting.Indented));
                writer.Flush();
                memoryStream.Position = 0;
                return File(memoryStream, "text/plain", "Error.log");
            }
        }

        [HttpPost]
        public ActionResult Claim()
        {
            if (SessionPerson.UserId == 1)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "For Bypass Process Click On View Button !!"
                };
                return RedirectToAction("Pending", new { id = string.Empty });
            }
            int flag = new RequestLogic(BllCommonLogic).Claim(Convert.ToInt32(id), SessionPerson.UserId, SessionPerson.UserTypeId);
            if (flag > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "You have claimed this request Successfully !!"
                };
                return RedirectToAction("Proceed", new { id });
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "You Don't have permission to claim!!"
                };
            }
            return RedirectToAction("Pending", new { id = string.Empty });
        }

        public ActionResult Proceed()
        {
            RequestProceed requestProceed = new RequestProceed
            {
                LicenseRequest =
                new RequestLogic(BllCommonLogic)
                    .GetRequest(Convert.ToInt32(id), SessionPerson.UserId, SessionPerson.UserTypeId)
            };

            if (requestProceed.LicenseRequest == null)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "You Don't have permission to claim!!"
                };
                return RedirectToAction("Pending", new { id = string.Empty });
            }
            else if (!requestProceed.LicenseRequest.IsClaimed)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "You have not claimed yet!!"
                };
                return RedirectToAction("Pending", new { id = string.Empty });
            }
            requestProceed.WfStates = new WfStateLogic(BllCommonLogic).GetWfState(SessionPerson.UserTypeId, requestProceed.LicenseRequest.LicenceTypeId, false);
            requestProceed.RequestAcknowledgements = new RequestAcknowledgementLogic(BllCommonLogic).GetDatas(Convert.ToInt32(id));

            return View(requestProceed);
        }

        public ActionResult AcknowledgementDocsDownload()
        {
            RequestAcknowledgement requestAcknowledgement =
                new RequestAcknowledgementLogic(BllCommonLogic)
                .GetDatas(Convert.ToInt32(id))
                .Where(a => a.Id == Convert.ToInt32(id2))
                .FirstOrDefault();

            return File(requestAcknowledgement.FileData, requestAcknowledgement.MimeType, requestAcknowledgement.FileName);
        }

        [HttpPost]
        public ActionResult Proceed(RequestAcknowledgement requestAcknowledgement, IFormFile FData)
        {
            if (SessionPerson.UserId == 1)
            {
                requestAcknowledgement.UserId = requestAcknowledgement.BUserId;
                requestAcknowledgement.UserTypeId = requestAcknowledgement.BNextUserTypeId;
                requestAcknowledgement.RequestId = Convert.ToInt32(id);
                requestAcknowledgement.RequestNo = new RequestLogic(BllCommonLogic)
                        .GetRequest(Convert.ToInt32(id), requestAcknowledgement.BUserId, requestAcknowledgement.BNextUserTypeId).RequestNo;
            }
            else
            {
                requestAcknowledgement.UserId = SessionPerson.UserId;
                requestAcknowledgement.UserTypeId = SessionPerson.UserTypeId;
                requestAcknowledgement.RequestId = Convert.ToInt32(id);
                requestAcknowledgement.RequestNo = new RequestLogic(BllCommonLogic)
                        .GetRequest(Convert.ToInt32(id), SessionPerson.UserId, SessionPerson.UserTypeId).RequestNo;
            }


            if (FData != null)
            {
                requestAcknowledgement.MimeType = FData.ContentType;
                requestAcknowledgement.FileName = Path.GetFileName(FData.FileName);

                Stream sm = FData.OpenReadStream();
                BinaryReader bm = new BinaryReader(sm);
                byte[] byteimage = bm.ReadBytes((Int32)sm.Length);
                requestAcknowledgement.FileData = byteimage;
                requestAcknowledgement.Description = "LicensingERP";
            }


            int flag = new RequestAcknowledgementLogic(BllCommonLogic).Insert(requestAcknowledgement);
            if (flag > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Your remarks has been submitted to next viewer!!"
                };
                return RedirectToAction("Pending", new { id = string.Empty });
            }
            else if (flag == 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "File Size Is to Big !!"
                };
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "You Don't have permission to claim!!"
                };
            }
            if (SessionPerson.UserId == 1)
            {
                return RedirectToAction("Pending", new { id = string.Empty });
            }
            else
            {
                return RedirectToAction("Proceed", new { id });
            }

        }

        //[HttpPost]
        //public PartialViewResult GetCompareList([FromBody] Request request)
        //{
        //    if (request != null)
        //    {
        //        return PartialView("_PartialCompare", new LicenceCompareLogic(BllCommonLogic).CompareLicenceGet(request.ClientId, request.LicenceTypeId));
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        [HttpGet]
        public ActionResult DisplayCompareLicence()
        {
            return View(new LicenceCompareLogic(BllCommonLogic).CompareLicenceDisplay(id));
        }

        public ActionResult FollowUp()
        {
            RequestLogic rl = new RequestLogic(BllCommonLogic);

            List<FollowUp> followUps = new List<FollowUp>();
            followUps = rl.GetFollowUpList();

            //return View(new RequestLogic(BllCommonLogic).GetFollowUpList());
            return View(followUps);
        }

        [HttpPost]
        public JsonResult SendFollowUpMail([FromBody] FollowUp followUp)
        {
            if (followUp.UserId == 0)
            {
                RequestLogic requestLogic = new RequestLogic(BllCommonLogic);
                List<User> users = new MailUserListLogic(BllCommonLogic).MailUserRequisition(followUp.UserTypeId);

                #region Mail Sending

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
                var Config = builder.Build();

                Email emailConfig = new Email();

                emailConfig.Domain = Config.GetSection("Email").GetSection("Domain").Value;
                emailConfig.Port = Int32.Parse(Config.GetSection("Email").GetSection("Port").Value);
                emailConfig.UserName = Config.GetSection("Email").GetSection("UserName").Value;
                emailConfig.Password = Config.GetSection("Email").GetSection("Password").Value;
                emailConfig.FromEmail = Config.GetSection("Email").GetSection("FromEmail").Value;

                foreach (User user in users)
                {
                    emailConfig.To = user.Email;
                    new Mailsending().SendMailToUser(emailConfig);
                }

                #endregion

                #region Save Follow Up record



                FollowUp fu = new FollowUp();
                fu.RequestNo = followUp.RequestNo;
                //fu.FollowUpDoneBy = SessionPerson.Email;

                RequestLogic logic = new RequestLogic(BllCommonLogic);
                int flag = logic.InsertFollowUp(fu);


                #endregion
            }
            else  // mail to a particuler user of a group
            {
                RequestLogic requestLogic = new RequestLogic(BllCommonLogic);
                List<User> users = new MailUserListLogic(BllCommonLogic).MailUserRequisition(followUp.UserTypeId).Where(a => a.Id == followUp.UserId).ToList();

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
                var Config = builder.Build();

                Email emailConfig = new Email();

                emailConfig.Domain = Config.GetSection("Email").GetSection("Domain").Value;
                emailConfig.Port = Int32.Parse(Config.GetSection("Email").GetSection("Port").Value);
                emailConfig.UserName = Config.GetSection("Email").GetSection("UserName").Value;
                emailConfig.Password = Config.GetSection("Email").GetSection("Password").Value;
                emailConfig.FromEmail = Config.GetSection("Email").GetSection("FromEmail").Value;

                foreach (User user in users)
                {
                    emailConfig.To = user.Email;
                    new Mailsending().SendMailToUser(emailConfig);
                }

                #region Save Follow Up record


                FollowUp fu = new FollowUp();
                fu.RequestNo = followUp.RequestNo;
                //fu.FollowUpDoneBy = SessionPerson.Email;

                RequestLogic logic = new RequestLogic(BllCommonLogic);
                int flag = logic.InsertFollowUp(fu);


                #endregion
            }

            return Json(true);
        }

    }
}