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
   public  class RequestParameterLogic : ConnectionString
    {
        public RequestParameterLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public void Insert(List<RequestParameter> requestParameters,string RequestNo,int RequestId)
        {
            foreach (RequestParameter requestParameter in requestParameters)
            {
                using (MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
                {
                    nameValuePairs nvp = new nameValuePairs
                    {
                        new nameValuePair("p_RequestId", RequestId),
                        new nameValuePair("p_RequestNo", RequestNo),
                        new nameValuePair("p_ParamId", requestParameter.ParamId),
                        new nameValuePair("p_ParamValue", requestParameter.ParamValue),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "INSERT")
                    };

                    try
                    {
                        DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequestParameter, nvp, "Out_Param");

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
