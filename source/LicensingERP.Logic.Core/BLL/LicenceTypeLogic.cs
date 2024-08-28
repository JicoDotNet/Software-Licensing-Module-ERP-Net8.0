using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class LicenceTypeLogic: ConnectionString
    {
        public LicenceTypeLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(LicenceType licenceType)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_TypeName", licenceType.TypeName),
                new nameValuePair("p_LicenceTypeDetails",licenceType.LicenceTypeDetails),
                new nameValuePair("p_NumberOfLicence", 0),
                new nameValuePair("p_IsScalingEligible", 0),


                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceType, nvp, "Out_Param"));
        }

        public List<LicenceType> GetLicenceType()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();
            nameValuePairs.Add(new nameValuePair("p_licenceTypeId", 0));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceType, nameValuePairs).ToList<LicenceType>();
        }

        public LicenceType GetLicenceType(int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                //new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_licenceTypeId", LicenceTypeId),
                //new nameValuePair("p_UserName", null),
                new nameValuePair("p_QueryType", "LICENSETYPE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceType, nameValuePairs).ToList<LicenceType>().FirstOrDefault();
        }

        public int Update(LicenceType licenceType)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", licenceType.Id),
                new nameValuePair("p_TypeName", licenceType.TypeName),
                new nameValuePair("p_LicenceTypeDetails",licenceType.LicenceTypeDetails),
                new nameValuePair("p_NumberOfLicence", 0),
                new nameValuePair("p_IsScalingEligible", 0),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "UPDATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceType, nvp, "Out_Param"));
        }

        public int Deactivate(int LicenceTypeId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", LicenceTypeId),
                new nameValuePair("p_TypeName", null),
                new nameValuePair("p_LicenceTypeDetails", null),
                new nameValuePair("p_NumberOfLicence", 0),
                new nameValuePair("p_IsScalingEligible", 0),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceType, nvp, "Out_Param"));
        }        
    }
}
