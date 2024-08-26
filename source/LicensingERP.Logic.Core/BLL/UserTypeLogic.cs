using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.BLL
{
    public class UserTypeLogic: ConnectionString
    {
        public UserTypeLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(UserType userType)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_UserTypeName", userType.UserTypeName),
                new nameValuePair("p_UserTypeDetails", userType.UserTypeDetails),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };
            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserType, nvp, "Out_Param"));
        }


        public List<UserType> GetUserType()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();
            nameValuePairs.Add(new nameValuePair("p_UserTypeId", 0));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetUserType, nameValuePairs).ToList<UserType>();
        }
        public int Update(UserType userType)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id",userType.Id ),
                new nameValuePair("p_UserTypeName", userType.UserTypeName),
                new nameValuePair("p_UserTypeDetails", userType.UserTypeDetails),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "UPDATE")
            };
            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserType, nvp, "Out_Param"));
        }

        public UserType GetUserType(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                //new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_UserTypeId", UserTypeId),
                //new nameValuePair("p_UserName", null),
                new nameValuePair("p_QueryType", "USERTYPE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUserType, nameValuePairs).ToList<UserType>().FirstOrDefault();
        }

        public int Deactivate(int UserId)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", UserId),
                new nameValuePair("p_UserTypeName", null),
                new nameValuePair("p_UserTypeDetails", null),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserType, nvp, "Out_Param"));
        }
    }
}
