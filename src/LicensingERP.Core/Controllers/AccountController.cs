using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.Model.Class;
using LicensingERP.Models;
using LicensingERP.StateManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LicensingERP.Controllers
{
    public class AccountController(IAppSettingsService appSettingsService) : BaseController(appSettingsService)
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formCollection)
        {
            LoginCredentials loginCredentials = new LoginCredentials()
            {
                UserName = formCollection["UserName"],
                PasswordText = formCollection["PasswordText"],
            };
            LoginManagment loginManagment = new LoginManagment(BllCommonLogic);
            loginCredentials = loginManagment.Authenticate(loginCredentials);
            if(loginCredentials != null)
            {
                List<MenuGroup> menuLists = new MenuAccessLogic(BllCommonLogic).GetMenuForUser(loginCredentials.UserTypeId);

                AuthticateCredential credential = new AuthticateCredential
                {
                    UserId = loginCredentials.UserId,
                    FullName = loginCredentials.FullName,
                    UserName = loginCredentials.UserName,
                    UserTypeId = loginCredentials.UserTypeId,
                    Email = loginCredentials.Email,
                };

                this.HttpContext.SetCookie(credential, "User", BllCommonLogic.DefaultEncryptionKey);
                this.HttpContext.SetSession(menuLists, "Menu");

                if (!loginCredentials.IsChangeable)
                    TempData["Url"] = Url.Action("Index", "Home");
                else
                    TempData["Url"] = Url.Action("ResetPassword", "Profile");

                return RedirectToAction("OAuth", "Account");
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Invalid Credentials!!"
                };
            }
            return RedirectToAction("Index");
        }

        public ActionResult OAuth()
        {
            if (TempData["Url"] != null)
            {
                RedirectModels models = new RedirectModels { _redirectUrl = TempData["Url"]?.ToString() };
                return View(models);
            }
            else
                return RedirectToAction("Index");
        }

        [SessionAuthenticate]
        public ActionResult Menu()
        {
            List<MenuGroup> menuLists = this.HttpContext.GetSession<List<MenuGroup>>("Menu");
            return PartialView("_PartialMenu", menuLists);
        }

        public ActionResult Logout(string returnURL)
        {
            AbandonSession();
            return RedirectToAction("Index", "Account", new { returnURL = returnURL });
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(IFormCollection formCollection)
        {
            User user = new UserLogic(BllCommonLogic).GetUser(formCollection["UserName"]);
            if (user == null)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "User Name is invalid!!"
                };
                return RedirectToAction("ForgotPassword");
            }

            PasswordLogic passwordLogic = new PasswordLogic(BllCommonLogic);

            PasswordSecurity passwordSecurity = passwordLogic.GetePasswordSecurityQuestions(user.Id);
            if(passwordSecurity != null)
            {
                if (!(passwordSecurity.QuestionEnumNo == Convert.ToInt32(formCollection["QuestionEnumNo"]) &&
                passwordSecurity.Answer == formCollection["Answer"].ToString()))
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "Invalid Answer of Security Question!!"
                    };
                    return RedirectToAction("ForgotPassword");
                }

                if (passwordLogic.InsertPasswordResetRequest(user.UserName) == 0)
                {
                    ReturnMessage = new ReturnObject
                    {
                        Status = false,
                        Message = "You are already requested to reset your password!!"
                    };
                    return RedirectToAction("ForgotPassword");
                }

                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "Your request successfully inserted!!"
                };
                return RedirectToAction("ForgotPassword");
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Your request is invaild  "
                };
                return RedirectToAction("ForgotPassword");
            }
            
        }
    }
}