using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.Encryption;
using LicensingERP.Logic.Enumeration;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Controllers
{
    [SessionAuthenticate]
    public class UserController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        // GET: User
        public ActionResult Index()
        {
            UserTypeLogic usertypeLogic = new UserTypeLogic(BllCommonLogic);
            UserLogic userLogic = new UserLogic(BllCommonLogic);
            UserTypeUserModel userTypeUserModel = new UserTypeUserModel
            {
                UserTypes = usertypeLogic.GetUserType(),
                Users = userLogic.GetUsers()
            };
            if (!string.IsNullOrEmpty(id))
            {
                userTypeUserModel.user = userTypeUserModel.Users.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(userTypeUserModel);
        }

        [HttpPost]
        public ActionResult Index(UserWithPassword user)
        {
            int UserId;
            user.Address = user?.Address?.Trim();
            user.Email = user.Email + user.UserName;
            user.UserName = user.Email;
            UserLogic userLogic = new UserLogic(BllCommonLogic);
            if (string.IsNullOrEmpty(id))
            {
                if (userLogic.GetUser(user.UserName) == null)
                {
                    #region Maker Checker
                    /* -- Password Encrypt -- */
                    user.Password = new CryptoEngine(BllCommonLogic.DefaultEncryptionKey).Encrypt(user.Password);
                    /* -- End -- */
                    MakerCheckerData<UserWithPassword> makerChecker = new MakerCheckerData<UserWithPassword>(BllCommonLogic)
                    {
                        CreatedUserId = SessionPerson.UserId,
                        CreatedUserTypeId = SessionPerson.UserTypeId,
                        eCaseType = eMakerCheckerCaseType.User,
                        ePurpose = eMakerCheckerPurpose.Insert,
                        tEffectedData = user
                    };
                    makerChecker.ToString();
                    UserId = new MakerCheckerLogic<UserWithPassword>(BllCommonLogic).Insert(makerChecker);
                    #endregion
                }
                else
                    UserId = -1;
            }
            else
            {
                user.Id = Convert.ToInt32(id);

                #region Maker Checker
                MakerCheckerData<User> dataOnHold = new MakerCheckerData<User>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = eMakerCheckerCaseType.User,
                    ePurpose = eMakerCheckerPurpose.Update,
                    tEffectedData = user
                };
                dataOnHold.ToString();
                UserId = new MakerCheckerLogic<User>(BllCommonLogic).Insert(dataOnHold);
                #endregion
            }
            if (UserId > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Data Saved Waiting for Approval!!"
                };
            }
            else if (UserId == -1)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    ResponseStatus = UserId,
                    Message = "<b>User Name or Email: <i>" + user.UserName + "</i></b> is already exsist !!",
                    ReturnData = user
                };
            }
            else if (UserId == 0)
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
                    Message = "Data Not Saved !!"
                };
            }
            return RedirectToAction("Index", new { id = string.Empty });
        }

        /// <summary>
        /// This method binding and create custom models and write the linq query in line ..
        /// </summary>
        /// <returns></returns>
        public ActionResult Type()
        {
            UserTypeLogic UTypeLogic = new UserTypeLogic(BllCommonLogic);
            _UserTypes _userTypes = new _UserTypes
            {
                UserTypes = UTypeLogic.GetUserType()
            };
            if (!string.IsNullOrEmpty(id))
            {
                _userTypes.UserType = _userTypes.UserTypes.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
            }
            return View(_userTypes);
        }

        /// <summary>
        /// insert and update in one action method using id.and flag contain the output of the result
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Type(UserType userType)
        {
            userType.UserTypeDetails = userType.UserTypeDetails?.Trim();
            UserTypeLogic userTypeLogic = new UserTypeLogic(BllCommonLogic);
            int flag = 0;
            if (string.IsNullOrEmpty(id))
            {
                #region Maker Checker
                MakerCheckerData<UserType> dataOnHold = new MakerCheckerData<UserType>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    eCaseType = eMakerCheckerCaseType.UserGroup,
                    ePurpose = eMakerCheckerPurpose.Insert,
                    tEffectedData = userType
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<UserType>(BllCommonLogic).Insert(dataOnHold);
                #endregion

                #region Normal Flow - deprecated
                //flag = UTypeLogic.Insert(Utype);
                #endregion

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
            }
            else
            {
                userType.Id = Convert.ToInt32(id);

                #region Maker Checker
                MakerCheckerData<UserType> dataOnHold = new MakerCheckerData<UserType>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = Logic.Enumeration.eMakerCheckerCaseType.UserGroup,
                    ePurpose = Logic.Enumeration.eMakerCheckerPurpose.Update,
                    tEffectedData = userType
                };
                dataOnHold.ToString();
                flag = new MakerCheckerLogic<UserType>(BllCommonLogic).Insert(dataOnHold);
                #endregion

                #region Normal Flow - deprecated
                //flag = UTypeLogic.Update(Utype);
                #endregion

                if (flag > 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = true,
                        Message = "Data Updated. Waiting for approval!!"
                    };
                }
                else
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Data Update Error!!"
                    };
                }
            }

            //ReturnMessage = new ReturnObject
            //{
            //    Status = (flag > 0) ? true : false,
            //    Message = (flag > 0) ? "Data Saved !!" : ""
            //};
            return RedirectToAction("Type", new { id = string.Empty });
        }

        public ActionResult Get()
        {
            UserLogic userlogic = new UserLogic(BllCommonLogic);
            List<User> user = userlogic.GetUsers(Convert.ToInt32(id));
            return Json(user);
        }
        
        [HttpPost]
        public JsonResult Permission([FromBody] List<UserMenu> userMenus)
        {
            int flag = 0;

            MakerCheckerData<List<UserMenu>> dataOnHold = new MakerCheckerData<List<UserMenu>>(BllCommonLogic)
            {
                CreatedUserId = SessionPerson.UserId,
                CreatedUserTypeId = SessionPerson.UserTypeId,
                eCaseType = eMakerCheckerCaseType.UserMenuPermission,
                ePurpose = eMakerCheckerPurpose.Insert,
                tEffectedData = userMenus
            };
            dataOnHold.ToString();
            flag = new MakerCheckerLogic<List<UserMenu>>(BllCommonLogic).Insert(dataOnHold);
            //MenuAccessLogic menuAccessLogic = new MenuAccessLogic(BllCommonLogic);
            //menuAccessLogic.SetAccessPermission(userMenus, Convert.ToInt32(id));
            return Json(flag);
        }

        public ActionResult PasswordChangeRequest()
        {
            PasswordLogic passwordLogic = new PasswordLogic(BllCommonLogic);
            return View(passwordLogic.GetResetRequests());
        }

        [HttpPost]
        public ActionResult ResetPassword(IFormCollection formCollection)
        {
            string CurrentPassword = formCollection["Password"];
            LoginCredentials PasswordCheck = new LoginCredentials()
            {
                UserName = SessionPerson.UserName,
                PasswordText = CurrentPassword,
            };
            LoginManagment loginManagment = new LoginManagment(BllCommonLogic);
            PasswordCheck = loginManagment.Authenticate(PasswordCheck);
            if (PasswordCheck == null)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Your Current Password is wrong !!"
                };
                return RedirectToAction("PasswordChangeRequest");
            }

            Password password = new Password
            {
                UserId = Convert.ToInt32(id),
                PasswordText = formCollection["NewPassword"]
            };
            PasswordLogic passwordLogic = new PasswordLogic(BllCommonLogic);
            int val = passwordLogic.SetPassword(password, true);
            if (val > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "User's password successfully changed !!"
                };
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Something went wrong !!"
                };
            }
            return RedirectToAction("PasswordChangeRequest");
        }
        #region Emailaddress checking
        [HttpPost]
        public JsonResult UserNameCheck([FromBody] User UserName)
        {
            UserLogic userLogic = new UserLogic(BllCommonLogic);
            User userObj = userLogic.GetUser(UserName.UserName);
            if (userObj != null)
                return Json(false);
            else
                return Json(true);
        }
        #endregion

        [HttpGet]
        public PartialViewResult Deactivate()
        {
            User user = (id == SessionPerson.UserId.ToString()) ? null : new UserLogic(BllCommonLogic).GetUser(Convert.ToInt32(id));
            return PartialView("_PartialUserDeactivate", user);
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
                MakerCheckerData<User> dataOnHold = new MakerCheckerData<User>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = Logic.Enumeration.eMakerCheckerCaseType.User,
                    ePurpose = Logic.Enumeration.eMakerCheckerPurpose.Deactivate,
                    tEffectedData = new UserLogic(BllCommonLogic).GetUser(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new MakerCheckerLogic<User>(BllCommonLogic).Insert(dataOnHold));
                #endregion

                #region Normal Flow - deprecated
                //return Json(new UserLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
                #endregion
            }
            else
            {
                return Json(-1);
            }
        }

        public ActionResult Permission(string id)
        {
            UserMenuViewModel userMenuViewModel = new UserMenuViewModel
            {
                MenuLists = new MenuAccessLogic(BllCommonLogic).GetMenuList(),
                UserTypes = new UserTypeLogic(BllCommonLogic).GetUserType(),
                dashboards = new DashboardAccessLogic(BllCommonLogic).DashboardList()
            };
            if (!string.IsNullOrEmpty(id))
            {
                userMenuViewModel.userType = userMenuViewModel.UserTypes.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
                userMenuViewModel.UserMenus = new MenuAccessLogic(BllCommonLogic).GetAccessPermission(Convert.ToInt32(id));
                userMenuViewModel.userDashboards = new UserDashBoardLogic(BllCommonLogic).GetAccessdashBoard(Convert.ToInt32(id));
            }
            return View(userMenuViewModel);
        }

        //[HttpPost]
        //public JsonResult Permission1([FromBody] List<UserMenu> userMenus)
        //{
        //    MenuAccessLogic menuAccessLogic = new MenuAccessLogic(BllCommonLogic);
        //    menuAccessLogic.SetAccessPermission(userMenus, 1);
        //    return Json(Url.Action("Permission1", "User", new { id = "View" }));
        //}

        public ActionResult Details()
        {
            UserTypeLogic usertypeLogic = new UserTypeLogic(BllCommonLogic);
            UserLogic userLogic = new UserLogic(BllCommonLogic);
            UserTypeUserModel userTypeUserModel = new UserTypeUserModel
            {
                UserTypes = usertypeLogic.GetUserType(),
                Users = userLogic.GetUsers()
            };

            return View(userTypeUserModel);
        }

        [HttpGet]
        public PartialViewResult TypeDeactivate()
        {
            UserType userType = new UserTypeLogic(BllCommonLogic).GetUserType(Convert.ToInt32(id));
            return PartialView("_PartialUserTypeDeactivate", userType);
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
                MakerCheckerData<UserType> dataOnHold = new MakerCheckerData<UserType>(BllCommonLogic)
                {
                    CreatedUserId = SessionPerson.UserId,
                    CreatedUserTypeId = SessionPerson.UserTypeId,
                    EffectedRowId = Convert.ToInt32(id),
                    eCaseType = Logic.Enumeration.eMakerCheckerCaseType.UserGroup,
                    ePurpose = Logic.Enumeration.eMakerCheckerPurpose.Deactivate,
                    tEffectedData = new UserTypeLogic(BllCommonLogic).GetUserType(Convert.ToInt32(id))
                };
                dataOnHold.ToString();
                return Json(new MakerCheckerLogic<UserType>(BllCommonLogic).Insert(dataOnHold));
                #endregion

                #region Normal Flow - deprecated
                //return Json(new UserTypeLogic(BllCommonLogic).Deactivate(Convert.ToInt32(id)));
                #endregion
            }
            else
            {
                return Json(-1);
            }
        }

        public JsonResult DashboardPermission([FromBody] List<UserDashboard> userDashboards)
        {
            int flag = 0;

            MakerCheckerData<List<UserDashboard>> dataOnHold = new MakerCheckerData<List<UserDashboard>>(BllCommonLogic)
            {
                CreatedUserId = SessionPerson.UserId,
                CreatedUserTypeId = SessionPerson.UserTypeId,
                eCaseType = eMakerCheckerCaseType.UserDashboardPermission,
                ePurpose = eMakerCheckerPurpose.Insert,
                tEffectedData = userDashboards
            };
            dataOnHold.ToString();
            flag = new MakerCheckerLogic<List<UserDashboard>>(BllCommonLogic).Insert(dataOnHold);
            return Json(flag);
            //new UserDashBoardLogic(BllCommonLogic).Insert(userDashboards,Convert.ToInt32(id));
            //return Json(true);
        }
    }
}