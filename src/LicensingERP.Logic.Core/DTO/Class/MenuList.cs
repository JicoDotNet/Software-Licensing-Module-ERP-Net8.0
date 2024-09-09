using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Logic.DTO.Class
{
    public class MenuList : IMenuList
    {
        public int Id { get; set; }
        public int MenuGroupId { get; set; }
        public string Icon { get; set; }
        public string DisplayText { get; set; }
        public string Controller { get; set; }
        public string ActionResult { get; set; }
        public bool IsReport { get; set; }
        public bool IsForAdmin { get; set; }

        public string Description { get; set; }
        public bool IsForWorkflow { get; set; }
    }
}