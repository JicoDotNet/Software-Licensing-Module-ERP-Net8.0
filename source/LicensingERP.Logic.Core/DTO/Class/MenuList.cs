using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Logic.DTO.Class
{
    public class MenuList : IMenuList, ISession, IStatus, IActivity
    {
        public int Id { get; set; }
        public int MenuGroupId { get; set; }
        public string Icon { get; set; }
        public string DisplayText { get; set; }
        public string Controller { get; set; }
        public string RouteId { get; set; }
        public string ActionResult { get; set; }
        public string QueryString { get; set; }
        public string HttpType { get; set; }
        public bool IsReport { get; set; }
        public bool HasRouteId { get; set; }

        public bool IsDisplayable { get; set; }
        public bool IsForAdmin { get; set; }

        public string Description { get; set; }
        public bool IsForWorkflow { get; set; }

        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}