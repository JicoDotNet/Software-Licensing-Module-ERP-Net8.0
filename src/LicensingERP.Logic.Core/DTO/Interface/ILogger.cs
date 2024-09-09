using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface ILogger
    {
        string MacAddress { get; set; }
        string BrowserType { get; set; }
        string Browser { get; set; }
        string BrowserVersion { get; set; }

        string DeviceInfo { get; set; }

        string DNS { get; set; }

        string SessionId { get; set; }

        string IPAddress { get; set; }
        DateTime TransactionDate { get; set; }
        string CreatedBy { get; set; }

        string Controller { get; set; }
        string Action { get; set; }
        string RouteId { get; set; }

        string AbsoluteUri { get; set; }

        string HttpVerbs { get; set; }

        int? UserId { get; set; }
    }
}
