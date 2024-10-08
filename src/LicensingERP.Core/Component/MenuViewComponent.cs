﻿using LicensingERP.Logic.DTO.Class;
using LicensingERP.StateManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Component
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<MenuGroup> menuLists = this.HttpContext.GetSession<List<MenuGroup>>("Menu");
            return View("_PartialMenu", menuLists);
        }
    }
}
