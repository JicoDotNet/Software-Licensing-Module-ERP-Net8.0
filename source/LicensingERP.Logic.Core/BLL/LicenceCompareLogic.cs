using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
  public class LicenceCompareLogic : ConnectionString
    {
        public LicenceCompareLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<LicenceCompare> CompareLicenceGet(int ClientId , int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_RequestNo", 0),
                new NameValuePair("p_ClientId", ClientId),
                new NameValuePair("p_LicenceTypeId", LicenceTypeId),
                new NameValuePair("p_QueryType", "AllREQUEST")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetlicenceCompare, nvp).ToList<LicenceCompare>();
        }
        public CompareLList CompareLicenceDisplay(string RequisitionId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_RequestNo", RequisitionId),
                new NameValuePair("p_ClientId", 0),
                new NameValuePair("p_LicenceTypeId", 0),
                new NameValuePair("p_QueryType", "ONEREQUEST")
            };
            NameValuePairs rest = new NameValuePairs
            {
                new NameValuePair("p_RequestNo", RequisitionId),
                new NameValuePair("p_ClientId", 0),
                new NameValuePair("p_LicenceTypeId", 0),
                new NameValuePair("p_QueryType", "ONLRESTRICT")
            };
            NameValuePairs feature = new NameValuePairs
            {
                new NameValuePair("p_RequestNo", RequisitionId),
                new NameValuePair("p_ClientId", 0),
                new NameValuePair("p_LicenceTypeId", 0),
                new NameValuePair("p_QueryType", "ONLFEATURE")
            };
            NameValuePairs parameter = new NameValuePairs
            {
                new NameValuePair("p_RequestNo", RequisitionId),
                new NameValuePair("p_ClientId", 0),
                new NameValuePair("p_LicenceTypeId", 0),
                new NameValuePair("p_QueryType", "ONLPARAMETER")
            };
            CompareLList compareLList = new CompareLList();
            compareLList.licenceCompare =  mySqlDBAccess.GetData(StoreProcedure.GetlicenceCompare, nvp).ToList<LicenceCompare>().FirstOrDefault();
            if(compareLList.licenceCompare != null)
            {
               
                compareLList.requestRestricts = mySqlDBAccess.GetData(StoreProcedure.GetlicenceCompare, rest).ToList<RequestRestrict>();
                compareLList.requestFeatures = mySqlDBAccess.GetData(StoreProcedure.GetlicenceCompare, feature).ToList<RequestFeature>();
                compareLList.requestParameters = mySqlDBAccess.GetData(StoreProcedure.GetlicenceCompare, parameter).ToList<RequestParameter>();
            }

            return compareLList;
        }
    }
}
