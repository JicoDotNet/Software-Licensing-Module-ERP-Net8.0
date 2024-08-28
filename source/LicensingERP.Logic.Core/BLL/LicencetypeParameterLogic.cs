using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class LicencetypeParameterLogic : ConnectionString
    {
        public LicencetypeParameterLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(List<ParameterOfLicence> parameterOfLicence)
        {
            //int paramid;
            //foreach (ParameterOfLicence parameter in parameterOfLicence)
            //{
            //    paramid = parameter.LicenseTypeId;
            //}
            //    Deactivate(paramid);
            int id = 0;
            foreach (ParameterOfLicence parameter in parameterOfLicence)
            {
                #region for maker and checker
                id++;
                if(id == 1)
                {
                    Deactivate(parameter.LicenseTypeId);
                }
                #endregion
                using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
                {
                    NameValuePairs nvp = new NameValuePairs
                    {
                        new NameValuePair("p_ParameterId", parameter.ParameterId),
                        new NameValuePair("p_LicenseTypeId", parameter.LicenseTypeId),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "INSERT")
                    };

                    try
                    {
                       DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceParameter, nvp, "Out_Param");

                       // return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceParameter, nvp, "Out_Param"));
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return 1;
        }

        public int Deactivate(int LicenseTypeId)
        {
            using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
            {
                NameValuePairs nvp = new NameValuePairs
                    {
                        new NameValuePair("p_ParameterId", null),
                        new NameValuePair("p_LicenseTypeId", LicenseTypeId),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "DEACTIVATE")
                    };

                try
                {
                    return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceParameter, nvp, "Out_Param"));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<ParameterOfLicence> GetLicenceofParameter()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("p_LicenseTypeId", 0));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceofParameter, NameValuePairs).ToList<ParameterOfLicence>();
        }
        public List<ParameterOfLicence> GetLicenceofParameter(int LicenseTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("p_LicenseTypeId", LicenseTypeId));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ASSIGNED"));

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceofParameter, NameValuePairs).ToList<ParameterOfLicence>();
        }
    }
}
