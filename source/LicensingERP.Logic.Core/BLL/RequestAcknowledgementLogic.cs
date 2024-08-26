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
    public class RequestAcknowledgementLogic : ConnectionString
    {
        public RequestAcknowledgementLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(RequestAcknowledgement acknowledgement)
        {
            try {
                mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

                nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_RequestId", acknowledgement.RequestId),
                new nameValuePair("p_RequestNo", acknowledgement.RequestNo),
                new nameValuePair("p_UserId", acknowledgement.UserId),
                new nameValuePair("p_UserTypeId", acknowledgement.UserTypeId),
                new nameValuePair("p_Remarks", acknowledgement.Remarks),
                new nameValuePair("p_StateId", acknowledgement.StateId),
                new nameValuePair("p_SessionId", CommonObj.SessionId),

                #region file upload
                new nameValuePair("p_FileName", acknowledgement.FileName),
                new nameValuePair("p_MimeType", acknowledgement.MimeType),
                new nameValuePair("p_Description", acknowledgement.Description),
                new nameValuePair("p_FileData", acknowledgement.FileData),
                #endregion

                new nameValuePair("p_QueryType", "INSERT")
            };

                return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequestAcknowledgement, nvp, "Out_Param"));
            }
            catch(Exception ex)
            {
                return 0;
            }
           
        }

        public List<RequestAcknowledgement> GetDatas(int RequestId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_RequestId", RequestId),
                new nameValuePair("p_QueryType", "FORREQUEST")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetRequestAcknowledgement, nvp).ToList<RequestAcknowledgement>();
        }
    }
}
