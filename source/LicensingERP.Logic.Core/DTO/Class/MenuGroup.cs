using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Logic.DTO.Class
{
    public class MenuGroup : MenuList, IMenuGroup, ISession, IStatus, IActivity
    {
    //    public int Id { get; set; }
    //    public string Icon { get; set; }
    //    public string DisplayText { get; set; }
    //    public bool IsDisplayable { get; set; }

    //    public DateTime TransactionDate { get; set; }
    //    public string CreatedBy { get; set; }
    //    public string SessionId { get; set; }
    //    public bool IsActive { get; set; }

        public List<MenuList> menuLists { get; set; }
    }
}