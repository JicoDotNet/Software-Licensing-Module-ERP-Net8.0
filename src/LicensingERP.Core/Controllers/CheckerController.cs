using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.Encryption;
using LicensingERP.Logic.Enumeration;
using LicensingERP.Logic.Model.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LicensingERP.Core.Controllers
{
    [SessionAuthenticate]
    public class CheckerController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public IActionResult Index()
        {
            DataOnHoldLogic<object> dataOnHoldLogic = new DataOnHoldLogic<object>(BllCommonLogic);
            List<DataOnHold<object>> dataOnHolds = dataOnHoldLogic.GetPendingDatas(SessionPerson.UserId, SessionPerson.UserTypeId);

            return View(dataOnHolds);
        }

        public PartialViewResult Pending()
        {
            DataOnHoldLogic<object> dataOnHoldLogic = new DataOnHoldLogic<object>(BllCommonLogic);
            List<DataOnHold<object>> dataOnHolds = dataOnHoldLogic.GetPendingDatas(SessionPerson.UserId, SessionPerson.UserTypeId);
            return PartialView("_PartialCheckerApproval", dataOnHolds);
        }

        [HttpPost]
        public ActionResult Approve(IFormCollection form)
        {
            LoginCredentials loginCredentials = new LoginCredentials()
            {
                UserName = SessionPerson.UserName,
                PasswordText = form["Password"],
            };
            LoginManagment loginManagment = new LoginManagment(BllCommonLogic);
            loginCredentials = loginManagment.Authenticate(loginCredentials);
            if (loginCredentials != null)
            {
                DataOnHoldLogic<object> dataOnHoldLogic = new DataOnHoldLogic<object>(BllCommonLogic);
                DataOnHold<object> dataOnHold = dataOnHoldLogic.GetPendingData(SessionPerson.UserId, SessionPerson.UserTypeId, Convert.ToInt32(id));
                if (dataOnHold != null)
                {
                    DataOnHold<object> dataOnHoldnw = new DataOnHold<object>(BllCommonLogic)
                    {
                        Id = Convert.ToInt32(id),
                        ApproveRejectUserId = SessionPerson.UserId,
                        ApproveRejectUserTypeId = SessionPerson.UserTypeId,
                        ApproveRejectRemarks = form["ApproveRejectRemarks"]
                    };
                    if (dataOnHoldLogic.Approve(dataOnHoldnw) > 0)
                        if (Update(dataOnHold) > 0)
                            ReturnMessage = new ReturnObject
                            {
                                Status = true,
                                Message = "Data Submited !!"
                            };
                        else
                            ReturnMessage = new ReturnObject
                            {
                                Status = false,
                                Message = "Error to Save !!"
                            };
                }
                else
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Invalid Password"
                    };
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Invalid Password"
                };
            }

            return RedirectToAction("Index", new { id = string.Empty });
        }

        [HttpPost]
        public ActionResult Decline(IFormCollection form)
        {
            LoginCredentials loginCredentials = new LoginCredentials()
            {
                UserName = SessionPerson.UserName,
                PasswordText = form["Password"],
            };
            LoginManagment loginManagment = new LoginManagment(BllCommonLogic);
            loginCredentials = loginManagment.Authenticate(loginCredentials);
            if (loginCredentials != null)
            {
                DataOnHoldLogic<object> dataOnHoldLogic = new DataOnHoldLogic<object>(BllCommonLogic);
                DataOnHold<object> dataOnHold = dataOnHoldLogic.GetPendingData(SessionPerson.UserId, SessionPerson.UserTypeId, Convert.ToInt32(id));
                if (dataOnHold != null)
                {
                    DataOnHold<object> dataOnHoldnw = new DataOnHold<object>(BllCommonLogic)
                    {
                        Id = Convert.ToInt32(id),
                        ApproveRejectUserId = SessionPerson.UserId,
                        ApproveRejectUserTypeId = SessionPerson.UserTypeId,
                        ApproveRejectRemarks = form["ApproveRejectRemarks"]
                    };
                    if (dataOnHoldLogic.Decline(dataOnHoldnw) > 0)
                        ReturnMessage = new ReturnObject
                        {
                            Status = true,
                            Message = "Data Submited as you Decline to save!!"
                        };
                    else
                        ReturnMessage = new ReturnObject
                        {
                            Status = false,
                            Message = "Error to Save !!"
                        };
                }
                else
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "You are not Authorized!!"
                    };
            }
            else
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Invalid Password!!"
                };

            return RedirectToAction("Index", new { id = string.Empty });
        }

        private int Update(DataOnHold<object> dataOnHold)
        {
            switch (dataOnHold.eCaseType)
            {
                case eDataOnHoldCaseType.UserGroup:
                    if(dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new UserTypeLogic(BllCommonLogic).Insert((UserType)dataOnHold.GetT());
                    if(dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return new UserTypeLogic(BllCommonLogic).Update((UserType)dataOnHold.GetT());
                    if(dataOnHold.ePurpose== eDataOnHoldPurpose.Deactivate)
                        return new UserTypeLogic(BllCommonLogic).Deactivate(((UserType)dataOnHold.GetT()).Id);
                    break;
                case eDataOnHoldCaseType.User:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new UserLogic(BllCommonLogic).Insert((UserPassword)dataOnHold.GetT(), new Password { PasswordText = new CryptoEngine(BllCommonLogic.DefaultEncryptionKey).Decrypt(((UserPassword)dataOnHold.GetT()).Password) });
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return new UserLogic(BllCommonLogic).Update((User)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return new UserLogic(BllCommonLogic).Deactivate(((User)dataOnHold.GetT()).Id);
                    break;
                case eDataOnHoldCaseType.LicenseType:
                        if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                            return new LicenceTypeLogic(BllCommonLogic).Insert((LicenceType)dataOnHold.GetT());
                        if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                            return new LicenceTypeLogic(BllCommonLogic).Update((LicenceType)dataOnHold.GetT());
                        if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                            return new LicenceTypeLogic(BllCommonLogic).Deactivate(((LicenceType)dataOnHold.GetT()).Id);
                    break;
                case eDataOnHoldCaseType.LicenseParameterLink:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new LicencetypeParameterLogic(BllCommonLogic).Insert((List<ParameterOfLicence>)dataOnHold.GetT());
                    break;
                case eDataOnHoldCaseType.UserMenuPermission:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new MenuAccessLogic(BllCommonLogic).SetAccessPermission((List<UserMenu>)dataOnHold.GetT());
                    break;

                case eDataOnHoldCaseType.UserDashboardPermission:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new UserDashBoardLogic(BllCommonLogic).Insert((List<UserDashboard>)dataOnHold.GetT());
                    break;

                case eDataOnHoldCaseType.Client:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new ClientLogic(BllCommonLogic).Insert((Client)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return new ClientLogic(BllCommonLogic).Update((Client)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return new ClientLogic(BllCommonLogic).Deactivate(((Client)dataOnHold.GetT()).Id);
                        break;
                case eDataOnHoldCaseType.ClientCategory:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new ClientCategoryLogic(BllCommonLogic).Insert((ClientCategory)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return new ClientCategoryLogic(BllCommonLogic).Update((ClientCategory)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return new ClientCategoryLogic(BllCommonLogic).Deactivate(((ClientCategory)dataOnHold.GetT()).Id);
                    break;
                case eDataOnHoldCaseType.Parameter:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return new ParameterLogic(BllCommonLogic).Update((Parameter)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new ParameterLogic(BllCommonLogic).Insert((Parameter)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return new ParameterLogic(BllCommonLogic).Deactivate(((Parameter)dataOnHold.GetT()).Id);
                    break;
                case eDataOnHoldCaseType.Product:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new ProductLogic(BllCommonLogic).Insert((Product)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Update)
                        return new ProductLogic(BllCommonLogic).Update((Product)dataOnHold.GetT());
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Deactivate)
                        return new ProductLogic(BllCommonLogic).Deactivate(((Product)dataOnHold.GetT()).Id);
                    break;
                case eDataOnHoldCaseType.ProductFeatures:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new ProductFeaturesLogic(BllCommonLogic).Insert((ProductFeatures)dataOnHold.GetT());
                    break;
                case eDataOnHoldCaseType.WFProcess:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new WfProcessLogic(BllCommonLogic).Insert((WfProcess)dataOnHold.GetT());
                    break;
                case eDataOnHoldCaseType.WFAssign:
                    if (dataOnHold.ePurpose == eDataOnHoldPurpose.Insert)
                        return new WfProcessAssignLogic(BllCommonLogic).Insert((WfProcessAssign)dataOnHold.GetT());
                    break;
            }
            return 0;
        }
    }
}