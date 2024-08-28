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
   public class RequestFearuresLogic : ConnectionString
    {
        public RequestFearuresLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public void Insert (List<RequestFeature> requestFeatures, string RequestNo, int RequestId)
        {
            foreach(RequestFeature requestFeature in requestFeatures)
            {
                using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
                {
                    NameValuePairs nvp = new NameValuePairs
                    {
                        new NameValuePair("p_RequestId", RequestId),
                        new NameValuePair("p_RequestNo", RequestNo),
                        new NameValuePair("p_FeaturesId", requestFeature.FeaturesId),
                        new NameValuePair("p_ProductId", requestFeature.ProductId),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "INSERT")
                    };

                    try
                    {
                        DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequestFeatures, nvp, "Out_Param");

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
