using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using LicensingERP.Logic.Encryption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class UserLogic : ConnectionString
    {
        public UserLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(User user, Password password)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_UserTypeId", user.UserTypeId),
                new nameValuePair("p_FullName", user.FullName),
                new nameValuePair("p_UserName", user.UserName),
                new nameValuePair("p_Email", user.Email),
                new nameValuePair("p_Mobile", user.Mobile),
                new nameValuePair("p_Address", user.Address),
                new nameValuePair("p_Designation", user.Designation),
                //new nameValuePair("p_Password", password.PasswordText),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            int UserId = Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
            if(UserId > 0)
            {
                password.UserId = UserId;
                return new PasswordLogic(CommonObj).SetPassword(password, true);
            }
            else if(UserId == -1)
            {
                return UserId;
            }
            return 0;
        }

        public int Update(User user)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", user.Id),
                new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_FullName", user.FullName),
                new nameValuePair("p_UserName", null),
                new nameValuePair("p_Email", user.Email),
                new nameValuePair("p_Mobile", user.Mobile),
                new nameValuePair("p_Address", user.Address),
                new nameValuePair("p_Designation", user.Designation),
                //new nameValuePair("p_Password", null),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "UPDATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
        }

        public int Deactivate(int UserId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", UserId),
                new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_FullName", null),
                new nameValuePair("p_UserName", null),
                new nameValuePair("p_Email", null),
                new nameValuePair("p_Mobile", null),
                new nameValuePair("p_Address", null),
                new nameValuePair("p_Designation", null),
                //new nameValuePair("p_Password", null),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DEACTIVE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
        }

        public List<User> GetUsers()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_UserId", 0),
                new nameValuePair("p_UserName", null),
                new nameValuePair("p_QueryType", "ALL")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, nameValuePairs).ToList<User>();
        }

        public List<User> GetUsers(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserTypeId", UserTypeId),
                new nameValuePair("p_UserId", 0),
                new nameValuePair("p_UserName", null),
                new nameValuePair("p_QueryType", "BYUSERTYPE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, nameValuePairs).ToList<User>();
        }

        public User GetUser(int UserId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_UserName", null),
                new nameValuePair("p_QueryType", "USER")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, nameValuePairs).ToList<User>().FirstOrDefault();
        }
        
        public User GetUser(string UserName)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_UserId", 0),
                new nameValuePair("p_UserName", UserName),
                new nameValuePair("p_QueryType", "USERNAME")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, nameValuePairs).ToList<User>().FirstOrDefault();
        }

        public int Delete(int UserId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", UserId),
                new nameValuePair("p_UserTypeId", null),
                new nameValuePair("p_FullName", null),
                new nameValuePair("p_UserName", null),
                new nameValuePair("p_Email", null),
                new nameValuePair("p_Mobile", null),
                new nameValuePair("p_Address", null),
                new nameValuePair("p_Designation", null),
                //new nameValuePair("p_Password", password.PasswordText),
                new nameValuePair("p_IsActive", false),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DELETE")
            };

            UserId = Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
            return UserId;
        }
    }
}