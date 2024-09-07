using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LicensingERP.Models;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Logic.Enumeration;

namespace LicensingERP.Core.Controllers
{
    public class FormController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public ActionResult Manage()
        {
            _Parameter _Parameter = new _Parameter
            {
                parameters = new ParameterLogic(BllCommonLogic).GetParameter()
            };
            if (!string.IsNullOrEmpty(id))
            {
                _Parameter.parameter = _Parameter.parameters.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(_Parameter);            
        }
        [HttpPost]
        public ActionResult Manage(Parameter parameter)
        {
            ParameterLogic parameterLogic = new ParameterLogic(BllCommonLogic);
            //if(dynamicFieldMaster.DataType != eDataType.List.ToString())
            //{
            //    dynamicFieldMaster.ListData = null;
            //}
            parameter.FieldName = parameter.FieldName.Replace(" ", "");
            if (parameter.Fieldlength == null)
                parameter.Fieldlength = null;
            int result;
            if (string.IsNullOrEmpty(id))
            {
                #region Maker Checker
                DataOnHold<Parameter> dataOnHold = new DataOnHold<Parameter>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    eCaseType = eDataOnHoldCaseType.Parameter,
                    ePurpose = eDataOnHoldPurpose.Insert,
                    tEffectedData = parameter
                };
                dataOnHold.ToString();
                result = new DataOnHoldLogic<Parameter>(BllCommonLogic).Insert(dataOnHold);
                if(result > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Submitted. Waiting for approval !!"
                    };
                }
                else if (result == 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "You can't proceed for this data untill previous approval move on !!"
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
                // result = parameterLogic.Insert(parameter);
            }
            else
            {
                parameter.Id = Convert.ToInt32(id);
                // result = parameterLogic.Update(parameter);
                #region Maker Checker
                DataOnHold<Parameter> dataOnHold = new DataOnHold<Parameter>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = Logic.Enumeration.eDataOnHoldCaseType.Parameter,
                    ePurpose = Logic.Enumeration.eDataOnHoldPurpose.Update,
                    tEffectedData = parameter
                };
                dataOnHold.ToString();
                result = new DataOnHoldLogic<Parameter>(BllCommonLogic).Insert(dataOnHold);
                if (result > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Updated. Waiting for approval!!"
                    };
                }
                else if (result == 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "You can't proceed for this data untill previous approval move on !!"
                    };
                }
                else
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Error To Update !!"
                    };
                }
                #endregion
            }
            return RedirectToAction("Manage", new { id = string.Empty });
        }

        [HttpGet]
        public PartialViewResult Deactivate()
        {
            Parameter parameter = new ParameterLogic(BllCommonLogic).GetParameter(Convert.ToInt32(id));
            return PartialView("_PartialParameterDeactivate", parameter);
        }

        [HttpPost]
        public JsonResult Deactivate(string Context)
        {
            LoginCredentials loginCredentials = new LoginCredentials()
            {
                UserName = SessionPerson.UserName,
                PasswordText = Context,
            };
            LoginManagment loginManagment = new LoginManagment(BllCommonLogic);
            loginCredentials = loginManagment.Authenticate(loginCredentials);
            if (loginCredentials != null)
            {
                #region Maker Checker
                DataOnHold<Parameter> dataOnHold = new DataOnHold<Parameter>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eDataOnHoldCaseType.Parameter,
                    ePurpose = eDataOnHoldPurpose.Deactivate,
                    tEffectedData = new ParameterLogic(BllCommonLogic).GetParameter(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new DataOnHoldLogic<Parameter>(BllCommonLogic).Insert(dataOnHold));
                #endregion
                //return Json(new ParameterLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
            }
            else
            {
                return Json(-1);
            }
        }
    }
}