using LicensingERP.Logic.BLL.Audit;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.Model.Class;
using LicensingERP.StateManagement;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
//using System.Net.Http;
using System.Net;
using System.IO;
using LicensingERP.Logic.DTO.SP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class BaseController : Controller
    {
        //--- Property
        public string controller { get; set; }
        public string action { get; set; }
        public string id { get; set; }
        public string id2 { get; set; }

        public AuthticateCredential SessionPerson { get; private set; }
        public string SessionID { get; private set; }

        public ReturnObject ReturnMessage { get; set; }
        public sCommonDto BllCommonLogic { get; private set; }

        private string _ConnectionString;
        private ActionExecutingContext _filteringContext;
        private ActionExecutedContext _filteredContext;

        public BaseController()
        {
            var Config = GetConfiguration();
            _ConnectionString = Config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            Email email = new Email();
            email.Domain = Config.GetSection("Email").GetSection("Domain").Value;
        }
        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);
            return builder.Build();
        }        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                #region Set Global Varible
                _filteringContext = filterContext;
                #endregion

                #region Get Route Value
                this.controller = filterContext.RouteData.Values["controller"].ToString();
                this.action = filterContext.RouteData.Values["action"].ToString();
                this.id = filterContext.RouteData.Values["id"]?.ToString();
                this.id2 = filterContext.RouteData.Values["id2"]?.ToString();
                #endregion

                #region Set Private value
                this.SessionID = filterContext.HttpContext.Session.Id;
                this.BllCommonLogic = new sCommonDto
                {
                    ConnectionString = _ConnectionString,
                    SessionId = SessionID,// + "-#-" + Guid.NewGuid().ToString().Replace("-", "").ToUpper(),
                    TransactionDate = GenericLogic.IstNow,
                    IsActive = true
                };
                SessionPerson = null;
                
                if (filterContext.HttpContext.CookieAvailable<AuthticateCredential>("User"))
                {
                    //SessionPerson = SessionManagement.GetSession<AuthticateCredential>(filterContext.HttpContext.Session, "User");
                    SessionPerson = filterContext.HttpContext.GetCookie<AuthticateCredential>("User");
                }

                ReturnMessage = filterContext.HttpContext.GetSession<ReturnObject>("ReturnMessage");
                filterContext.HttpContext.RemoveSession<ReturnObject>("ReturnMessage");

                #endregion

                #region Logger Activity
                bool _ApplicableLog = true; //!(filterContext.HttpContext.Request.Url.AbsoluteUri.Contains("localhost:")
                        //|| filterContext.HttpContext.Request.Url.AbsoluteUri.Contains("azure"));
                if (_ApplicableLog)
                {
                    LoggerLogic LogObj = new LoggerLogic(BllCommonLogic)
                    {
                        IPAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                        DNS = Dns.GetHostName().ToString(),
                        HttpVerbs = HttpContext.Request.Method.ToString(),
                        Browser = Request.Headers["User-Agent"].ToString(),
                        BrowserType = string.Empty,
                        BrowserVersion = string.Empty,
                        AbsoluteUri = HttpContext.Request.Host.ToString() + HttpContext.Request.Path.ToString(),
                        MacAddress = string.Empty,
                        Action = action,
                        Controller = controller,
                        RouteId = id + "/" + id2,
                        SessionId = SessionID,
                        UserId = SessionPerson?.UserId
                    };
                    LogObj.Set();
                }
                #endregion

                #region View Bag for Rezor View
                ViewBag.controller = this.controller;
                ViewBag.action = this.action;
                ViewBag.id = this.id;
                ViewBag.id2 = this.id2;
                ViewBag.SessionPerson = this.SessionPerson; 
                #endregion

                base.OnActionExecuting(filterContext);
                return;
            }
            catch (Exception e)
            {
                filterContext.Result =
                                    RedirectToAction("Index", "Error", new { returnUrl = filterContext.HttpContext.Request.Path.Value, Ex = e });
                return;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            #region Set Global Varible
            _filteredContext = filterContext;
            #endregion

            TempData.Put("ReturnMessage", ReturnMessage);
            TempData.Put("SessionPerson", SessionPerson);
            if(ReturnMessage != null)
                filterContext.HttpContext.SetSession(ReturnMessage, "ReturnMessage");
            base.OnActionExecuted(filterContext);
        }

        public bool IsSessionAvailable()
        {
            if (SessionPerson != null)
                return true;
            else
                return false;
        }
        public void AbandonSession()
        {
            _filteringContext.HttpContext.Session.Clear();
            _filteringContext.HttpContext.DeleteCookie("User");
            _filteringContext.HttpContext.RemoveSession<List<MenuGroup>>("Menu");
            
            if (_filteringContext.HttpContext.Request.Cookies["ASP.NET_SessionId"] != null)
            {
                _filteringContext.HttpContext.Response.Cookies.Delete("ASP.NET_SessionId");
            }
        }
        public string GetIPAddress()
        {
            //string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //if (!string.IsNullOrEmpty(ipAddress))
            //{
            //    string[] addresses = ipAddress.Split(',');
            //    if (addresses.Length != 0)
            //    {
            //        return addresses[0];
            //    }
            //}

            //return context.Request.ServerVariables["REMOTE_ADDR"];
            return "LOCAL";
        }        
    }
}