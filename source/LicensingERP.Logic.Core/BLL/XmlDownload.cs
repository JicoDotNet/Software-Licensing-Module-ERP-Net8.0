using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class XmlDownload : ConnectionString
    {
        public XmlDownload(sCommonDto CommonObj) : base(CommonObj) { }

        public Request GetDownloadData(int UserId, int UserTypeId, int RequestId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_RequestId", RequestId),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "XML")
            };
            DataSet dataSet = mySqlDBAccess.GetDataSet(StoreProcedure.GetXml, NameValuePairs);
            Request request = dataSet.Tables[0].ToList<Request>().FirstOrDefault();
            request.RequestParameters = dataSet.Tables[1].ToList<RequestParameter>();
            request.RequestRestricts = dataSet.Tables[2].ToList<RequestRestrict>();
            request.RequestFeatures = dataSet.Tables[3].ToList<RequestFeature>();
            return request;
        }
    }
}
