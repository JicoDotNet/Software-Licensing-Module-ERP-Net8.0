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

            List<MenuGroup> menuGroupLists = filterContext.HttpContext.GetSession<List<MenuGroup>>("Menu");

            bool permissionGranted = false;

            if (menuGroupLists != null && menuGroupLists.Count > 0)
            {
                foreach (MenuGroup menuGroup in menuGroupLists)
                {
                    if (menuGroup.menuLists?.FirstOrDefault(a => a.Controller == controller && a.ActionResult == action) != null)
                    {
                        permissionGranted = true;
                        break;
                    }
                }
            }

            if (permissionGranted)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                ReturnObject returnObject = new ReturnObject()
                {
                    Status = false,
                    Message = "You are unuthorised to access this scope!"
                };
                ((Controller)filterContext.Controller).TempData.Add("ReturnMessage", returnObject);
                filterContext.Result =
                            new RedirectToRouteResult(LogoutRouteObj);
                return;
            }
        }
    }
}