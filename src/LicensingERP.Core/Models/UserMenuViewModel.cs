using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Models
{
    public class UserMenuViewModel
    {
        public IReadOnlyList<UserType> UserTypes { get; set; }
        public UserType userType { get; set; }

        public IReadOnlyList<MenuList> MenuLists { get; set; }
        public IReadOnlyList<UserMenu> UserMenus { get; set; }
        public IReadOnlyList<Dashboard> dashboards { get; set; }
        public List<UserDashboard> userDashboards { get; set; }

    }
}