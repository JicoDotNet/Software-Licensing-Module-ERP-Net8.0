using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.Model.Class;
using LicensingERP.StateManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Mvc
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PermissionAuthenticate : ActionFilterAttribute
    {
        private string controller;
        private string action;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RouteValueDictionary LogoutRouteObj = null;

            #region Get Route Value
            this.controller = filterContext.RouteData.Values["controller"].ToString();
            this.action = filterContext.RouteData.Values["action"].ToString();
            #endregion
            LogoutRouteObj =
                    new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "Home" },
                        { "returnUrl", filterContext.HttpContext.Request.Path.Value }
                    };
            ////object mc = filterContext.HttpContext.RequestServices.GetService(filterContext.HttpContext.RequestServices);
            //CacheManagement cacheManagement = new CacheManagement(filterContext.HttpContext. .RequestServices.GetService<IMemoryCache>());
            //List<MenuGroup> menuLists = cacheManagement.GetCache<List<MenuGroup>>("Menu");
            List<MenuGroup> menuLists = SessionManagement.GetSession<List<MenuGroup>>(filterContext.HttpContext.Session, "Menu");

            if (menuLists == null)
            {
                ReturnObject returnObject = new ReturnObject()
                {
                    Status = false,
                    Message ="You are no authorised to access this scope!"
                };
                ((Controller)filterContext.Controller).TempData.Add("ReturnMessage", returnObject);
                filterContext.Result =
                            new RedirectToRouteResult(LogoutRouteObj);
                return;
            }
            else if (menuLists.Where(a => a.Controller == controller && a.ActionResult == action).FirstOrDefault() == null)
            {
                ReturnObject returnObject = new ReturnObject()
                {
                    Status = false,
                    Message = "You are no authorised to access this scope!"
                };
                ((Controller)filterContext.Controller).TempData.Add("ReturnMessage", returnObject);
                filterContext.Result =
                            new RedirectToRouteResult(LogoutRouteObj);
                return;
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}