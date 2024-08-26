using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL
{
   public class RequestFearuresLogic : ConnectionString
    {
        public RequestFearuresLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public void Insert (List<RequestFeature> requestFeatures, string RequestNo, int RequestId)
        {
            foreach(RequestFeature requestFeature in requestFeatures)
            {
                using (MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
                {
                    nameValuePairs nvp = new nameValuePairs
                    {
                        new nameValuePair("p_RequestId", RequestId),
                        new nameValuePair("p_RequestNo", RequestNo),
                        new nameValuePair("p_FeaturesId", requestFeature.FeaturesId),
                        new nameValuePair("p_ProductId", requestFeature.ProductId),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "INSERT")
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
