using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.ReportClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class NotificationLogic : ConnectionString
    {
        public NotificationLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<ReportOfRequest> GetLicenseExpiry(int Duration)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_Duration", Duration),
                new NameValuePair("p_QueryType","All")
            };
            return new List<ReportOfRequest>();
            //return mySqlDBAccess.GetData(StoreProcedure.GetLicenceExpiry, NameValuePairs).ToList<ReportOfRequest>();
        }
    }
}
