using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LicensingERP.Logic.BLL
{
  public class LicenceCompareLogic : ConnectionString
    {
        public LicenceCompareLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<LicenceCompare> CompareLicenceGet(int ClientId , int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_RequestNo", 0),
                new nameValuePair("p_ClientId", ClientId),
                new nameValuePair("p_LicenceTypeId", LicenceTypeId),
                new nameValuePair("p_QueryType", "AllREQUEST")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetlicenceCompare, nvp).ToList<LicenceCompare>();
        }
        public CompareLList CompareLicenceDisplay(string RequisitionId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_RequestNo", RequisitionId),
                new nameValuePair("p_ClientId", 0),
                new nameValuePair("p_LicenceTypeId", 0),
                new nameValuePair("p_QueryType", "ONEREQUEST")
            };
            nameValuePairs rest = new nameValuePairs
            {
                new nameValuePair("p_RequestNo", RequisitionId),
                new nameValuePair("p_ClientId", 0),
                new nameValuePair("p_LicenceTypeId", 0),
                new nameValuePair("p_QueryType", "ONLRESTRICT")
            };
            nameValuePairs feature = new nameValuePairs
            {
                new nameValuePair("p_RequestNo", RequisitionId),
                new nameValuePair("p_ClientId", 0),
                new nameValuePair("p_LicenceTypeId", 0),
                new nameValuePair("p_QueryType", "ONLFEATURE")
            };
            nameValuePairs parameter = new nameValuePairs
            {
                new nameValuePair("p_RequestNo", RequisitionId),
                new nameValuePair("p_ClientId", 0),
                new nameValuePair("p_LicenceTypeId", 0),
                new nameValuePair("p_QueryType", "ONLPARAMETER")
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
