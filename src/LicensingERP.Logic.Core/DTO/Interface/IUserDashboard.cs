using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IUserDashboard
    {
        int DashboardId { get; set; }
        int UserTypeId { get; set; }
    }
}
