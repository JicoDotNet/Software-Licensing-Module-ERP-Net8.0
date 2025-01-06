using System;
using System.Collections.Generic;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.Encryption;
using LicensingERP.Logic.Enumeration;
using LicensingERP.Logic.Model.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LicensingERP.Core.Controllers
{
    [SessionAuthenticate]
    public class CheckerController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public IActionResult Index()
        {
            MakerCheckerLogic<object> makerCheckerLogic = new MakerCheckerLogic<object>(BllCommonLogic);
            List<MakerCheckerData<object>> makerCheckerDatas = makerCheckerLogic.GetPendingDatas(SessionPerson.UserId, SessionPerson.UserTypeId);

            return View(makerCheckerDatas);
        }

        public PartialViewResult Pending()
        {
            MakerCheckerLogic<object> makerCheckerLogic = new MakerCheckerLogic<object>(BllCommonLogic);
            List<MakerCheckerData<object>> makerCheckerDatas = makerCheckerLogic.GetPendingDatas(SessionPerson.UserId, SessionPerson.UserTypeId);
            return PartialView("_PartialCheckerApproval", makerCheckerDatas);
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
                MakerCheckerLogic<object> makerCheckerLogic = new MakerCheckerLogic<object>(BllCommonLogic);
                MakerCheckerData<object> makerCheckerData = makerCheckerLogic.GetPendingData(SessionPerson.UserId, SessionPerson.UserTypeId, Convert.ToInt32(id));
                if (makerCheckerData != null)
                {
                    MakerCheckerData<object> makerCheckerDatanw = new MakerCheckerData<object>(BllCommonLogic)
                    {
                        Id = Convert.ToInt32(id),
                        ApproveRejectUserId = SessionPerson.UserId,
                        ApproveRejectUserTypeId = SessionPerson.UserTypeId,
                        ApproveRejectRemarks = form["ApproveRejectRemarks"]
                    };
                    if (makerCheckerLogic.Approve(makerCheckerDatanw) > 0)
                        if (Update(makerCheckerData) > 0)
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
                MakerCheckerLogic<object> makerCheckerLogic = new MakerCheckerLogic<object>(BllCommonLogic);
                MakerCheckerData<object> makerCheckerData = makerCheckerLogic.GetPendingData(SessionPerson.UserId, SessionPerson.UserTypeId, Convert.ToInt32(id));
                if (makerCheckerData != null)
                {
                    MakerCheckerData<object> makerCheckernw = new MakerCheckerData<object>(BllCommonLogic)
                    {
                        Id = Convert.ToInt32(id),
                        ApproveRejectUserId = SessionPerson.UserId,
                        ApproveRejectUserTypeId = SessionPerson.UserTypeId,
                        ApproveRejectRemarks = form["ApproveRejectRemarks"]
                    };
                    if (makerCheckerLogic.Decline(makerCheckernw) > 0)
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

        private int Update(MakerCheckerData<object> makerCheckerData)
        {
            switch (makerCheckerData.eCaseType)
            {
                case eMakerCheckerCaseType.UserGroup:
                    if(makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new UserTypeLogic(BllCommonLogic).Insert((UserType)makerCheckerData.GetT());
                    if(makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                        return new UserTypeLogic(BllCommonLogic).Update((UserType)makerCheckerData.GetT());
                    if(makerCheckerData.ePurpose== eMakerCheckerPurpose.Deactivate)
                        return new UserTypeLogic(BllCommonLogic).Deactivate(((UserType)makerCheckerData.GetT()).Id);
                    break;
                case eMakerCheckerCaseType.User:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new UserLogic(BllCommonLogic).Insert((UserWithPassword)makerCheckerData.GetT(), new Password { PasswordText = new CryptoEngine(BllCommonLogic.DefaultEncryptionKey).Decrypt(((UserWithPassword)makerCheckerData.GetT()).Password) });
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                        return new UserLogic(BllCommonLogic).Update((User)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Deactivate)
                        return new UserLogic(BllCommonLogic).Deactivate(((User)makerCheckerData.GetT()).Id);
                    break;
                case eMakerCheckerCaseType.LicenseType:
                        if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                            return new LicenceTypeLogic(BllCommonLogic).Insert((LicenceType)makerCheckerData.GetT());
                        if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                            return new LicenceTypeLogic(BllCommonLogic).Update((LicenceType)makerCheckerData.GetT());
                        if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Deactivate)
                            return new LicenceTypeLogic(BllCommonLogic).Deactivate(((LicenceType)makerCheckerData.GetT()).Id);
                    break;
                case eMakerCheckerCaseType.LicenseParameterLink:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new LicencetypeParameterLogic(BllCommonLogic).Insert((List<ParameterOfLicence>)makerCheckerData.GetT());
                    break;
                case eMakerCheckerCaseType.UserMenuPermission:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new MenuAccessLogic(BllCommonLogic).SetAccessPermission((List<UserMenu>)makerCheckerData.GetT());
                    break;

                case eMakerCheckerCaseType.UserDashboardPermission:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new UserDashBoardLogic(BllCommonLogic).Insert((List<UserDashboard>)makerCheckerData.GetT());
                    break;

                case eMakerCheckerCaseType.Client:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new ClientLogic(BllCommonLogic).Insert((Client)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                        return new ClientLogic(BllCommonLogic).Update((Client)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Deactivate)
                        return new ClientLogic(BllCommonLogic).Deactivate(((Client)makerCheckerData.GetT()).Id);
                        break;
                case eMakerCheckerCaseType.ClientCategory:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new ClientCategoryLogic(BllCommonLogic).Insert((ClientCategory)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                        return new ClientCategoryLogic(BllCommonLogic).Update((ClientCategory)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Deactivate)
                        return new ClientCategoryLogic(BllCommonLogic).Deactivate(((ClientCategory)makerCheckerData.GetT()).Id);
                    break;
                case eMakerCheckerCaseType.Parameter:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                        return new ParameterLogic(BllCommonLogic).Update((Parameter)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new ParameterLogic(BllCommonLogic).Insert((Parameter)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Deactivate)
                        return new ParameterLogic(BllCommonLogic).Deactivate(((Parameter)makerCheckerData.GetT()).Id);
                    break;
                case eMakerCheckerCaseType.Product:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new ProductLogic(BllCommonLogic).Insert((Product)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Update)
                        return new ProductLogic(BllCommonLogic).Update((Product)makerCheckerData.GetT());
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Deactivate)
                        return new ProductLogic(BllCommonLogic).Deactivate(((Product)makerCheckerData.GetT()).Id);
                    break;
                case eMakerCheckerCaseType.ProductFeatures:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new ProductFeaturesLogic(BllCommonLogic).Insert((ProductFeatures)makerCheckerData.GetT());
                    break;
                case eMakerCheckerCaseType.WFProcess:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new WfProcessLogic(BllCommonLogic).Insert((WfProcess)makerCheckerData.GetT());
                    break;
                case eMakerCheckerCaseType.WFAssign:
                    if (makerCheckerData.ePurpose == eMakerCheckerPurpose.Insert)
                        return new WfProcessAssignLogic(BllCommonLogic).Insert((WfProcessAssign)makerCheckerData.GetT());
                    break;
            }
            return 0;
        }
    }
}