using LicensingERP.Logic.BLL;
using LicensingERP.Logic.DTO.Class;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LicensingERP.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Group()
        {
            MenuLogic menuLogic = new MenuLogic(BllCommonLogic);
            List<MenuGroup> menuGroups = menuLogic.GetMenuGroup();
            return View(menuGroups);
        }

        [HttpPost]
        public ActionResult Group(MenuGroup MGobj)
        {
            MenuLogic menuLogic = new MenuLogic(BllCommonLogic);
            menuLogic.InsertMenuGroup(MGobj, this.HttpContext.Session.Id);
            return RedirectToAction("Group");
        }

        public ActionResult List()
        {
            MenuLogic menuLogic = new MenuLogic(BllCommonLogic);
            List<MenuGroup> menuGroups = menuLogic.GetMenuGroup();
            ViewBag.MenuLists = menuLogic.GetMenuList();
            return View(menuGroups);
        }

        [HttpPost]
        public ActionResult List(MenuList MLObj)
        {
            MenuLogic menuLogic = new MenuLogic(BllCommonLogic);
            menuLogic.InsertMenuList(MLObj, this.HttpContext.Session.Id);
            return RedirectToAction("List");
        }
    }
}