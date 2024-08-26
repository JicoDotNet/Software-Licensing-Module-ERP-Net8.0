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
                using (MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
                {
                    nameValuePairs nvp = new nameValuePairs
                    {
                        new nameValuePair("p_ParameterId", parameter.ParameterId),
                        new nameValuePair("p_LicenseTypeId", parameter.LicenseTypeId),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "INSERT")
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
            using (MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
            {
                nameValuePairs nvp = new nameValuePairs
                    {
                        new nameValuePair("p_ParameterId", null),
                        new nameValuePair("p_LicenseTypeId", LicenseTypeId),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "DEACTIVATE")
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
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_LicenseTypeId", 0));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceofParameter, nameValuePairs).ToList<ParameterOfLicence>();
        }
        public List<ParameterOfLicence> GetLicenceofParameter(int LicenseTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_LicenseTypeId", LicenseTypeId));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ASSIGNED"));

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceofParameter, nameValuePairs).ToList<ParameterOfLicence>();
        }
    }
}
