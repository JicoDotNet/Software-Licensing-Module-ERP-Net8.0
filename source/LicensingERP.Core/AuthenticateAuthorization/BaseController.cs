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

namespace Microsoft.AspNetCore.Mvc
{
    public abstract class BaseController : Controller
    {
        private string _ConnectionString;
        ActionExecutingContext _filteringContext;
        ActionExecutedContext _filteredContext;

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
                
                if (SessionManagement.SessionAvailable<LoginCredentials>(filterContext.HttpContext.Session, "User"))
                {
                    SessionPerson = SessionManagement.GetSession<LoginCredentials>(filterContext.HttpContext.Session, "User");
                }

                ReturnMessage = SessionManagement.GetSession<ReturnObject>(filterContext.HttpContext.Session, "ReturnMessage");
                SessionManagement.RemoveSession<ReturnObject>(filterContext.HttpContext.Session, "ReturnMessage");

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

                #region Menu
                //if (((SessionManagement.GetSession<List<MenuGroup>>(filterContext.HttpContext.Session, "Menu") != null)?
                //    SessionManagement.GetSession<List<MenuGroup>>(filterContext.HttpContext.Session, "Menu")
                //    .Where(a => a.Controller == this.controller && a.ActionResult == this.action).Where(a => a.IsDisplayable).Count(): -1) > 0)
                //{
                //    MenuGroup activeMenu = new MenuGroup { Controller = this.controller, ActionResult = this.action };
                //    SessionManagement.SetSession(filterContext.HttpContext.Session, activeMenu, "ActiveMenu");
                //}                
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

            TempData.Put<ReturnObject>("ReturnMessage", ReturnMessage);
            TempData.Put<LoginCredentials>("SessionPerson", SessionPerson);
            if(ReturnMessage != null)
                SessionManagement.SetSession(filterContext.HttpContext.Session, ReturnMessage, "ReturnMessage");
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
            _filteringContext.HttpContext.Session.Remove("User");
            
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
        
        //[DllImport("Iphlpapi.dll")]
        //private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        //[DllImport("Ws2_32.dll")]
        //private static extern Int32 inet_addr(string ip);
        //public string GetClientMac(HttpContextBase context)
        //{
        //    try
        //    {
        //        string userip = context.Request.UserHostAddress;
        //        string strClientIP = context.Request.UserHostAddress.ToString().Trim();
        //        Int32 ldest = inet_addr(strClientIP);
        //        Int32 lhost = inet_addr("");
        //        Int64 macinfo = new Int64();
        //        Int32 len = 6;
        //        int res = SendARP(ldest, 0, ref macinfo, ref len);
        //        string mac_src = macinfo.ToString("X");
        //        if (mac_src == "0")
        //        {
        //            return null;
        //        }

        //        while (mac_src.Length < 12)
        //        {
        //            mac_src = mac_src.Insert(0, "0");
        //        }

        //        string mac_dest = "";

        //        for (int i = 0; i < 11; i++)
        //        {
        //            if (0 == (i % 2))
        //            {
        //                if (i == 10)
        //                {
        //                    mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
        //                }
        //                else
        //                {
        //                    mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
        //                }
        //            }
        //        }
        //        return mac_dest;
        //    }
        //    catch (Exception err)
        //    {
        //        return err.Message;
        //    }
        //}

        //--- Property
        public string controller { get; set; }
        public string action { get; set; }
        public string id { get; set; }
        public string id2 { get; set; }

        public LoginCredentials SessionPerson { get; private set; }
        public string SessionID { get; private set; }

        public ReturnObject ReturnMessage { get; set; }
        public sCommonDto BllCommonLogic { get; private set; }
    }
}