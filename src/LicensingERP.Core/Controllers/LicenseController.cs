using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Models;
using LicensingERP.Logic.Enumeration;

namespace LicensingERP.Core.Controllers
{
    [SessionAuthenticate]
    public class LicenseController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public ActionResult Index()
        {
            LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(BllCommonLogic);
            _LicenceType _licenceType = new _LicenceType
            {
                licenceTypes = licenceTypeLogic.GetLicenceType()
            };
            if (!string.IsNullOrEmpty(id))
            {
                _licenceType.licenceType = _licenceType.licenceTypes.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(_licenceType);
            //return View(new LicenceTypeLogic(BllCommonLogic).GetLicenceType());
        }

        [HttpPost]
        public ActionResult Index(LicenceType licence)
        {
            licence.LicenceTypeDetails = licence.LicenceTypeDetails.ToNullOrTrim();
            LicenceTypeLogic licenceTypeLogic = new LicenceTypeLogic(BllCommonLogic);
            int flag = 0;
            if (string.IsNullOrEmpty(id))
            {
                #region Maker Checker
                MakerCheckerData<LicenceType> dataOnHold = new MakerCheckerData<LicenceType>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    eCaseType = eMakerCheckerCaseType.LicenseType,
                    ePurpose = eMakerCheckerPurpose.Insert,
                    tEffectedData = licence
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<LicenceType>(BllCommonLogic).Insert(dataOnHold);
                #endregion


                #region Previous Logic for insert
                //flag = licenceTypeLogic.Insert(licence);
                #endregion
            }

            else
            {
                #region Maker Checker
                MakerCheckerData<LicenceType> dataOnHold = new MakerCheckerData<LicenceType>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eMakerCheckerCaseType.LicenseType,
                    ePurpose = eMakerCheckerPurpose.Update,
                    tEffectedData = licence
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<LicenceType>(BllCommonLogic).Insert(dataOnHold);
                #endregion

                #region
                //licence.Id = Convert.ToInt32(id);
                //flag =  licenceTypeLogic.Update(licence);
                #endregion
            }

            if (flag > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Data Submitted. Waiting for approval !!"
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
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Data Submitted. Waiting for approval !!"
                };
            }
            return RedirectToAction("Index", new { id = string.Empty });

        }       
        public ActionResult Requests()
        {
            return View();
        }
        public PartialViewResult TypeDeactivate()
        {
            LicenceType licenceType = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(Convert.ToInt32(id));
            return PartialView("_PartialLicenceTypeDeactivate", licenceType);
        }
        [HttpPost]
        public JsonResult TypeDeactivate(string Context)
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
                MakerCheckerData<LicenceType> dataOnHold = new MakerCheckerData<LicenceType>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = Logic.Enumeration.eMakerCheckerCaseType.LicenseType,
                    ePurpose = Logic.Enumeration.eMakerCheckerPurpose.Deactivate,
                    tEffectedData = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new MakerCheckerLogic<LicenceType>(BllCommonLogic).Insert(dataOnHold));
                #endregion

                #region
                // return Json(new LicenceTypeLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
                #endregion
            }
            else
            {
                return Json(-1);
            }
        }





















        public ActionResult Parameter()
        {
            LicencetypeParameter licencetypeParameter = new LicencetypeParameter
            {
                parameters = new ParameterLogic(BllCommonLogic).GetParameter(),
                licenceTypes = new LicenceTypeLogic(BllCommonLogic).GetLicenceType(),
                //
            };
            if(!string.IsNullOrEmpty(id))
            {
                licencetypeParameter.licenceType = licencetypeParameter.licenceTypes.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
                licencetypeParameter.parameterOfLicence = new LicencetypeParameterLogic(BllCommonLogic).GetLicenceofParameter(Convert.ToInt32(id));
            }
            return View(licencetypeParameter);
        }
        [HttpPost]
        public JsonResult Parameter([FromBody] List<ParameterOfLicence> parameterOfLicence)
        {
            int flag = -1; ;
            LicencetypeParameterLogic licencetypeParameterLogic = new LicencetypeParameterLogic(BllCommonLogic);

            MakerCheckerData<List<ParameterOfLicence>> dataOnHold = new MakerCheckerData<List<ParameterOfLicence>>(BllCommonLogic)
            {
                CreatedUserId = SessionPerson.UserId,
                CreatedUserTypeId = SessionPerson.UserTypeId,
                eCaseType = eMakerCheckerCaseType.LicenseParameterLink,
                ePurpose = eMakerCheckerPurpose.Insert,
                tEffectedData = parameterOfLicence
            };
            dataOnHold.ToString();

            flag = new MakerCheckerLogic<List<ParameterOfLicence>>(BllCommonLogic).Insert(dataOnHold);


            if (flag > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Data Submitted. Waiting for approval !!"
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
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Error To Submit !!"
                };
            }
           // licencetypeParameterLogic.Insert(parameterOfLicence, Convert.ToInt32(id));
            return Json(Url.Action("Parameter", "License", new { id = string.Empty }));
        }
    }
}