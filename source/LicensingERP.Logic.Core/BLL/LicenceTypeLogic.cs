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
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_TypeName", licenceType.TypeName),
                new NameValuePair("p_LicenceTypeDetails",licenceType.LicenceTypeDetails),
                new NameValuePair("p_NumberOfLicence", 0),
                new NameValuePair("p_IsScalingEligible", 0),


                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceType, nvp, "Out_Param"));
        }

        public List<LicenceType> GetLicenceType()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();
            NameValuePairs.Add(new NameValuePair("p_licenceTypeId", 0));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceType, NameValuePairs).ToList<LicenceType>();
        }

        public LicenceType GetLicenceType(int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                //new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_licenceTypeId", LicenceTypeId),
                //new NameValuePair("p_UserName", null),
                new NameValuePair("p_QueryType", "LICENSETYPE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetLicenceType, NameValuePairs).ToList<LicenceType>().FirstOrDefault();
        }

        public int Update(LicenceType licenceType)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", licenceType.Id),
                new NameValuePair("p_TypeName", licenceType.TypeName),
                new NameValuePair("p_LicenceTypeDetails",licenceType.LicenceTypeDetails),
                new NameValuePair("p_NumberOfLicence", 0),
                new NameValuePair("p_IsScalingEligible", 0),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "UPDATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceType, nvp, "Out_Param"));
        }

        public int Deactivate(int LicenceTypeId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", LicenceTypeId),
                new NameValuePair("p_TypeName", null),
                new NameValuePair("p_LicenceTypeDetails", null),
                new NameValuePair("p_NumberOfLicence", 0),
                new NameValuePair("p_IsScalingEligible", 0),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetLicenceType, nvp, "Out_Param"));
        }        
    }
}
