using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.Enumeration;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc8032;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LicensingERP.Controllers
{
    [SessionAuthenticate]
    public class WorkflowController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public ActionResult Index()
        {
            return View(new WfProcessLicenceType
            {
                licenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                wfprocess = new WfProcessLogic(BllCommonLogic).GetWfProcess()
            });
        }

        [HttpGet]
        public PartialViewResult BindWFProcess()
        {
            WfProcessLicenceType model = new WfProcessLicenceType();
            if (string.IsNullOrEmpty(id))
            {
                model.wfprocess = new WfProcessLogic(BllCommonLogic).GetWfProcess();
            }
            else
            {
                model.wfprocess = new WfProcessLogic(BllCommonLogic).GetWfProcess(Convert.ToInt32(id));
            }
            return PartialView("_PartialWFProcessGrid", model);
        }

        [HttpPost]
        public ActionResult Index(WfProcess WFProcess)
        {
            int flag = 0;
            #region Maker Checker
            DataOnHold<WfProcess> dataOnHold = new DataOnHold<WfProcess>(BllCommonLogic)
            {
                CreatedUserId = SessionPerson.UserId,
                CreatedUserTypeId = SessionPerson.UserTypeId,
                eCaseType = eDataOnHoldCaseType.WFProcess,
                ePurpose = eDataOnHoldPurpose.Insert,
                tEffectedData = WFProcess
            };
            dataOnHold.ToString();
            flag = new DataOnHoldLogic<WfProcess>(BllCommonLogic).Insert(dataOnHold);
            if ( flag > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Data Submitted. Waiting for approval !!"
                };
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Error To Submit !!"
                };
            }
            #endregion



            //WfProcessLogic WFProLogic = new WfProcessLogic(BllCommonLogic);
            //if (WFProLogic.Insert(WFProcess) > 0)
            //{
            //    ReturnMessage = new ReturnObject
            //    {
            //        Status = true,
            //        Message = "Data Saved !!"
            //    };
            //}
            //else
            //{
            //    ReturnMessage = new ReturnObject
            //    {
            //        Status = false,
            //        Message = "Error to Save !!"
            //    };
            //}
            return RedirectToAction("Index");
        }

        public ActionResult Acknowledgement()
        {
            return View();
        }

        public ActionResult Assign()
        {
            WorkflowAssign WorkAssignViewModel;
            if (string.IsNullOrEmpty(id))
            {
                WorkAssignViewModel = new WorkflowAssign
                {
                    licenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                    wfAssigns = new WfProcessAssignLogic(BllCommonLogic).GetWfProcessAssigns()
                };
            }
            else
            {
                WorkAssignViewModel = new WorkflowAssign
                {
                    wfAssigns = new WfProcessAssignLogic(BllCommonLogic).GetWfProcessAssigns(Convert.ToInt32(id)),
                    userTypes = new UserTypeLogic(BllCommonLogic).GetUserType(),
                    wfProcesses = new WfProcessLogic(BllCommonLogic).GetWfProcess().Where(a => a.LicenceTypeId == Convert.ToInt32(id)).ToList(),
                    state = new WfStateLogic(BllCommonLogic).GetWfState(),//.Where(a => a.IsPositive || (a.IsHold)).ToList(),
                    licenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                };
                WorkAssignViewModel.licenceType = WorkAssignViewModel.licenceTypes
                    .Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(WorkAssignViewModel);
        }

        [HttpPost]
        public ActionResult Assign(WfProcessAssign WFAsn)
        {
            int flag;
            DataOnHold<WfProcessAssign> dataOnHold = new DataOnHold<WfProcessAssign>(BllCommonLogic)
            {
                CreatedUserId = SessionPerson.UserId,
                CreatedUserTypeId = SessionPerson.UserTypeId,
                eCaseType = eDataOnHoldCaseType.WFAssign,
                ePurpose = eDataOnHoldPurpose.Insert,
                tEffectedData = WFAsn
            };
            dataOnHold.ToString();
            flag = new DataOnHoldLogic<WfProcessAssign>(BllCommonLogic).Insert(dataOnHold);
            WfProcessAssignLogic WFProLogic = new WfProcessAssignLogic(BllCommonLogic);
            //WFProLogic.Insert(WFAsn);
            //ReturnMessage = new ReturnObject
            //{
            //    Status = true,
            //    Message = "Data Assigned !!"
            //};
            if (flag > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Data Saved Waiting for Approval!!"
                };
            }
            else if (flag == 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "You can't proceed for this data untill previous approval move on !!"
                };
            }

            return RedirectToAction("Assign");
        }

        public ActionResult Diagram()
        {
            WorkflowAssign WorkAssignViewModel;
            if (string.IsNullOrEmpty(id))
            {
                WorkAssignViewModel = new WorkflowAssign
                {
                    licenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                };
            }
            else
            {
                WorkAssignViewModel = new WorkflowAssign
                {
                    licenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                    wfDiagram = new WfProcessAssignLogic(BllCommonLogic).GetWfProcessAssignDiagram(Convert.ToInt32(id)),
                };
                WorkAssignViewModel.licenceType = WorkAssignViewModel.licenceTypes
                    .Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View("Diagram", WorkAssignViewModel);
        }

        [HttpGet]
        public JsonResult GetFeaturesModule()
        {
            return Json(new ProductFeaturesModule
            {
                Features = new ProductFeaturesLogic(BllCommonLogic).GetDatas(Convert.ToInt32(id)),
                Modules = new ProductModuleLogic(BllCommonLogic).GetDatas(Convert.ToInt32(id))
            });
        }
    }
}