using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Logic.DTO.Class
{
    public class MenuGroup : IMenuGroup
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string DisplayText { get; set; }

        public List<MenuList> menuLists { get; set; }
    }
}