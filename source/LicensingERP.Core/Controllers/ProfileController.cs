using LicensingERP.Logic.BLL;
using LicensingERP.Logic.BLL.Helper;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.Enumeration;
using LicensingERP.Logic.Model.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LicensingERP.Controllers
{
    [SessionAuthenticate]
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            UserLogic ULogic = new UserLogic(BllCommonLogic);
            User user = ULogic.GetUser(SessionPerson.UserId);
            return View(user);
        }

        public ActionResult Edit()
        {
            UserLogic ULogic = new UserLogic(BllCommonLogic);
            User user = ULogic.GetUser(SessionPerson.UserId);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user, string id)
        {
            user.Id = Convert.ToInt32(id);
            UserLogic ULogic = new UserLogic(BllCommonLogic);
            ULogic.Update(user);
            return RedirectToAction("Index");
        }

        public ActionResult Password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Password(IFormCollection formCollection)
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
                return RedirectToAction("Password");
            }

            Password password = new Password
            {
                UserId = SessionPerson.UserId,
                PasswordText = formCollection["NewPassword"]
            };
            PasswordLogic passwordLogic = new PasswordLogic(BllCommonLogic);
            int val = passwordLogic.SetPassword(password, false);
            if (val > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "your password successfully changed !!"
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
            return RedirectToAction("Password", "Profile");
        }

        public ActionResult ResetPassword()
        {
            return View();
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
            if(PasswordCheck== null)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Your Current Password is wrong !!"
                };
                return RedirectToAction("ResetPassword");
            }

            PasswordSecurity passwordSecurity = new PasswordSecurity
            {
                Answer = formCollection["Answer"],
                QuestionEnumNo = Convert.ToInt32(formCollection["QuestionEnumNo"])
            };
            passwordSecurity.Question = EnumHelper<ePasswordSecurityQuestions>.GetDisplayValue((ePasswordSecurityQuestions)passwordSecurity.QuestionEnumNo);
            passwordSecurity.UserId = SessionPerson.UserId;

            Password password = new Password
            {
                UserId = SessionPerson.UserId,
                PasswordText = formCollection["NewPassword"]
            };

            PasswordLogic passwordLogic = new PasswordLogic(BllCommonLogic);
            int val = passwordLogic.InsertNewPassword(password, passwordSecurity);
            if(val > 0)
            {
                ReturnMessage = new ReturnObject
                {
                    Status = true,
                    Message = "your password successfully changed !!"
                };
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ReturnMessage = new ReturnObject
                {
                    Status = false,
                    Message = "Something went wrong !!"
                };
            }
            return RedirectToAction("ResetPassword");
        }
    }
}