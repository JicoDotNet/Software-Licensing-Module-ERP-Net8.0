using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.BLL;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Models;
using LicensingERP.Logic.Enumeration;

namespace LicensingERP.Controllers
{
    /// <summary>
    /// Client display and Edit in single Method using Models 
    /// </summary>
    [SessionAuthenticate]
    public class ClientController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public ActionResult Index()
        {
            ClientLogic client_data = new ClientLogic(BllCommonLogic);
            _Clients _client = new _Clients
            {
                Clients = client_data.GetClients(),
                ClientCategories = new ClientCategoryLogic(BllCommonLogic).GetClientCategory()
            };
            if (!string.IsNullOrEmpty(id))
            {
                _client.Client = _client.Clients.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(_client);
        }
        [HttpPost]
        public ActionResult Index(Client client)
        {
            client.CompanyAddress = client?.CompanyAddress?.Trim();
            int flag = 0;
            if (string.IsNullOrEmpty(id))
            {
                #region Maker Checker
                MakerCheckerData<Client> dataOnHold = new MakerCheckerData<Client>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    eCaseType = eMakerCheckerCaseType.Client,
                    ePurpose = eMakerCheckerPurpose.Insert,
                    tEffectedData = client
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<Client>(BllCommonLogic).Insert(dataOnHold);
                if(flag > 0)
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
                        Message = "Error to Submit Data!!"
                    };
                }
                #endregion

                #region
                //  clientlg.Insert(client);
                #endregion
            }
            else
            {
                client.Id = Convert.ToInt32(id);
                #region Maker Checker
                MakerCheckerData<Client> dataOnHold = new MakerCheckerData<Client>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = Logic.Enumeration.eMakerCheckerCaseType.Client,
                    ePurpose = Logic.Enumeration.eMakerCheckerPurpose.Update,
                    tEffectedData = client
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<Client>(BllCommonLogic).Insert(dataOnHold);
                if(flag > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Update Request Submited Successfully !!"
                    };
                }
                else
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Data Update Request Error !!"
                    };
                }
                #endregion

                #region Old logic
                // clientlg.Update(client);
                #endregion
            }
            return RedirectToAction("Index", new { id = string.Empty });
        }

        [HttpGet]
        public PartialViewResult ClientDeactivate()
        {
            Client client = new ClientLogic(BllCommonLogic).GetClient(Convert.ToInt32(id));
            return PartialView("_PartialClientDeactivate", client);
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
                MakerCheckerData<Client> dataOnHold = new MakerCheckerData<Client>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eMakerCheckerCaseType.Client,
                    ePurpose = eMakerCheckerPurpose.Deactivate,
                    tEffectedData = new ClientLogic(BllCommonLogic).GetClient(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new MakerCheckerLogic<Client>(BllCommonLogic).Insert(dataOnHold));
                #endregion

                #region
                // return Json(new ClientLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
                #endregion
            }
            else
            {
                return Json(-1);
            }
        }

        public ActionResult Category()
        {
            ClientCategoryLogic clientCategoryLogic = new ClientCategoryLogic(BllCommonLogic);
            _ClientCategory _clientcategory = new _ClientCategory
            {
                clientcategories = clientCategoryLogic.GetClientCategory()
            };
            if (!string.IsNullOrEmpty(id))
            {
                _clientcategory.clientcategory = _clientcategory.clientcategories.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }

            return View(_clientcategory);
        }
        [HttpPost]
        public ActionResult Category(ClientCategory clientCategory)
        {
            clientCategory.CategoryDetails = clientCategory.CategoryDetails.Trim();
            ClientCategoryLogic clientCategoryLogic = new ClientCategoryLogic(BllCommonLogic);
            int flag = 0;

            if (string.IsNullOrEmpty(id))
            {
                #region Maker Checker
                MakerCheckerData<ClientCategory> dataOnHold = new MakerCheckerData<ClientCategory>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    eCaseType = eMakerCheckerCaseType.ClientCategory,
                    ePurpose = eMakerCheckerPurpose.Insert,
                    tEffectedData = clientCategory
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<ClientCategory>(BllCommonLogic).Insert(dataOnHold);
                if(flag > 0)
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
                        Message = "Data Submit Request Error!!"
                    };
                }


                #endregion
                #region
                //clientCategoryLogic.Insert(clientCategory);
                #endregion
            }
            else
            {
                clientCategory.Id = Convert.ToInt32(id);
                // clientCategoryLogic.Update(clientCategory);
                #region
                MakerCheckerData<ClientCategory> dataOnHold = new MakerCheckerData<ClientCategory>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eMakerCheckerCaseType.ClientCategory,
                    ePurpose = eMakerCheckerPurpose.Update,
                    tEffectedData = clientCategory
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<ClientCategory>(BllCommonLogic).Insert(dataOnHold);

                if(flag > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Update Request Submit Successfully !!"
                    };
                }
                else
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Data Update Request Submit Error !!"
                    };
                }
                #endregion

               
            }


            return RedirectToAction("Category", new {  id = string.Empty });
        }

        public PartialViewResult ClientCategoryDeactivate()
        {

            ClientCategory clientcategory = new ClientCategoryLogic(BllCommonLogic).GetClientCategory(Convert.ToInt32(id));
            return PartialView("_PartialClientCategoryDeactivate", clientcategory);
        }
        [HttpPost]
        public JsonResult CategoryDeactivate ( string Context)
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
                MakerCheckerData<ClientCategory> dataOnHold = new MakerCheckerData<ClientCategory>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eMakerCheckerCaseType.ClientCategory,
                    ePurpose = eMakerCheckerPurpose.Deactivate,
                    tEffectedData = new ClientCategoryLogic(BllCommonLogic).GetClientCategory(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new MakerCheckerLogic<ClientCategory>(BllCommonLogic).Insert(dataOnHold));
                #endregion
                //return Json(new ClientCategoryLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
            }
            else
            {
                return Json(-1);
            }

        }

    }
}