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
    public class RequestAcknowledgementLogic : ConnectionString
    {
        public RequestAcknowledgementLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(RequestAcknowledgement acknowledgement)
        {
            try {
                mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

                NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_RequestId", acknowledgement.RequestId),
                new NameValuePair("p_RequestNo", acknowledgement.RequestNo),
                new NameValuePair("p_UserId", acknowledgement.UserId),
                new NameValuePair("p_UserTypeId", acknowledgement.UserTypeId),
                new NameValuePair("p_Remarks", acknowledgement.Remarks),
                new NameValuePair("p_StateId", acknowledgement.StateId),
                new NameValuePair("p_SessionId", CommonObj.SessionId),

                #region file upload
                new NameValuePair("p_FileName", acknowledgement.FileName),
                new NameValuePair("p_MimeType", acknowledgement.MimeType),
                new NameValuePair("p_Description", acknowledgement.Description),
                new NameValuePair("p_FileData", acknowledgement.FileData),
                #endregion

                new NameValuePair("p_QueryType", "INSERT")
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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_RequestId", RequestId),
                new NameValuePair("p_QueryType", "FORREQUEST")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetRequestAcknowledgement, nvp).ToList<RequestAcknowledgement>();
        }
    }
}
