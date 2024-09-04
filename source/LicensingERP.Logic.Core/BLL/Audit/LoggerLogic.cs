using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using DataAccess.MySQL.Net;
using System;
using System.Data;
using System.Threading.Tasks;

namespace LicensingERP.Logic.BLL.Audit
{
    public sealed class LoggerLogic : ILogger, ISession, IActivity
    {
        private sCommonDto CommonObj;
        public LoggerLogic(sCommonDto _CommonObj) { CommonObj = _CommonObj; }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Set()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(() =>
                {
                    MySqlDBAccess mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

                    nameValuePairs nvp = new nameValuePairs();
                    nvp.Add(new nameValuePair("p_AbsoluteUri", this.AbsoluteUri));
                    nvp.Add(new nameValuePair("p_MacAddress", this.MacAddress));
                    nvp.Add(new nameValuePair("p_Action", this.Action));
                    nvp.Add(new nameValuePair("p_Browser", this.Browser));
                    nvp.Add(new nameValuePair("p_BrowserType", this.BrowserType));
                    nvp.Add(new nameValuePair("p_BrowserVersion", this.BrowserVersion));
                    nvp.Add(new nameValuePair("p_Controller", this.Controller));
                    nvp.Add(new nameValuePair("p_DNS", this.DNS));
                    nvp.Add(new nameValuePair("p_HttpVerbs", this.HttpVerbs));
                    nvp.Add(new nameValuePair("p_IPAddress", this.IPAddress));
                    nvp.Add(new nameValuePair("p_RouteId", this.RouteId));
                    nvp.Add(new nameValuePair("p_SessionId", this.SessionId));
                    nvp.Add(new nameValuePair("p_UserId", this.UserId));

                    mySqlDBAccess.InsertUpdateDeleteReturnInt("sp_Log", nvp);
                });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            }
            catch (Exception e)
            {
                return;
            }
        }

        public string MacAddress { get; set; }
        public string BrowserType { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }

        public string DeviceInfo { get; set; }

        public string DNS { get; set; }
        
        public string SessionId { get; set; }

        public string IPAddress { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteId { get; set; }

        public string AbsoluteUri { get; set; }

        public string HttpVerbs { get; set; }

        public int? UserId { get; set; }
    }
}
