using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class RequestRestrictLogic : ConnectionString
    {
        public RequestRestrictLogic(sCommonDto CommonObj) : base(CommonObj) { }
        public void Insert(List<RequestRestrict> requestRestricts, string RequestNo, int RequestId)
        {
            foreach (RequestRestrict requestRestrict in requestRestricts)
            {
                using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
                {
                    NameValuePairs nvp = new NameValuePairs
                    {
                        new NameValuePair("p_RequestId", RequestId),
                        new NameValuePair("p_RequestNo", RequestNo),
                        new NameValuePair("p_RestrictTo", requestRestrict.RestrictTo),
                        new NameValuePair("p_RestrictVal", requestRestrict.RestrictVal),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "INSERT")
                    };

                    try
                    {
                        DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequestRestrict, nvp, "Out_Param");

                        //return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProductFeatures, nvp, "Out_Param"));
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
