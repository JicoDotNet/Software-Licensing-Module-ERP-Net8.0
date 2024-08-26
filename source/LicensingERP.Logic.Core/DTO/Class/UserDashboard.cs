using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class UserDashboard: IUserDashboard, IStatus, IActivity, ISession
    {
        public int DashboardId { get; set; }
        public int UserTypeId { get; set; }

        public string DashboardName { get; set; }
        public string DashboardUserType { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
