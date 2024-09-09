using LicensingERP.Logic.Model.Class;
using LicensingERP.StateManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace Microsoft.AspNetCore.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SessionAuthenticate : ActionFilterAttribute
    {
        public string SessionKey { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string _SessionKey = "User";// SessionKey;
            #region RouteValueDictionary
            RouteValueDictionary LogoutRouteObj = null;

            LogoutRouteObj =
                    new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "Account" },
                        { "returnUrl", filterContext.HttpContext.Request.Path.Value }
                    };

            #endregion
            try
            {
                // If session exists
                if (filterContext.HttpContext.Session != null)
                {
                    //Login Session Check
                    //if (SessionManagement.GetSession<AuthticateCredential>(filterContext.HttpContext.Session, _SessionKey) != null)
                    if (filterContext.HttpContext.CookieAvailable<AuthticateCredential>(_SessionKey))
                    {
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                        filterContext.Result =
                            new RedirectToRouteResult(LogoutRouteObj);
                        return;
                    }
                }
                else
                {
                    //otherwise continue with action
                    base.OnActionExecuting(filterContext);
                }
            }
            catch (Exception e)
            {
                LogoutRouteObj.Add("Ex", e);
                filterContext.Result =
                            new RedirectToRouteResult(LogoutRouteObj);
                return;
            }
        }
    }
}