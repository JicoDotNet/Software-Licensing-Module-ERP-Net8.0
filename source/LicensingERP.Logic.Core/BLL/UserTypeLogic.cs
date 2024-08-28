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
    public class UserTypeLogic: ConnectionString
    {
        public UserTypeLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(UserType userType)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_UserTypeName", userType.UserTypeName),
                new NameValuePair("p_UserTypeDetails", userType.UserTypeDetails),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };
            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserType, nvp, "Out_Param"));
        }


        public List<UserType> GetUserType()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();
            NameValuePairs.Add(new NameValuePair("p_UserTypeId", 0));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetUserType, NameValuePairs).ToList<UserType>();
        }
        public int Update(UserType userType)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id",userType.Id ),
                new NameValuePair("p_UserTypeName", userType.UserTypeName),
                new NameValuePair("p_UserTypeDetails", userType.UserTypeDetails),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "UPDATE")
            };
            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserType, nvp, "Out_Param"));
        }

        public UserType GetUserType(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                //new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_UserTypeId", UserTypeId),
                //new NameValuePair("p_UserName", null),
                new NameValuePair("p_QueryType", "USERTYPE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUserType, NameValuePairs).ToList<UserType>().FirstOrDefault();
        }

        public int Deactivate(int UserId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", UserId),
                new NameValuePair("p_UserTypeName", null),
                new NameValuePair("p_UserTypeDetails", null),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserType, nvp, "Out_Param"));
        }
    }
}
