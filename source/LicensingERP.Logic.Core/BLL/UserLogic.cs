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
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_UserTypeId", user.UserTypeId),
                new NameValuePair("p_FullName", user.FullName),
                new NameValuePair("p_UserName", user.UserName),
                new NameValuePair("p_Email", user.Email),
                new NameValuePair("p_Mobile", user.Mobile),
                new NameValuePair("p_Address", user.Address),
                new NameValuePair("p_Designation", user.Designation),
                //new NameValuePair("p_Password", password.PasswordText),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
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
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", user.Id),
                new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_FullName", user.FullName),
                new NameValuePair("p_UserName", null),
                new NameValuePair("p_Email", user.Email),
                new NameValuePair("p_Mobile", user.Mobile),
                new NameValuePair("p_Address", user.Address),
                new NameValuePair("p_Designation", user.Designation),
                //new NameValuePair("p_Password", null),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "UPDATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
        }

        public int Deactivate(int UserId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", UserId),
                new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_FullName", null),
                new NameValuePair("p_UserName", null),
                new NameValuePair("p_Email", null),
                new NameValuePair("p_Mobile", null),
                new NameValuePair("p_Address", null),
                new NameValuePair("p_Designation", null),
                //new NameValuePair("p_Password", null),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DEACTIVE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
        }

        public List<User> GetUsers()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_UserId", 0),
                new NameValuePair("p_UserName", null),
                new NameValuePair("p_QueryType", "ALL")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, NameValuePairs).ToList<User>();
        }

        public List<User> GetUsers(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_UserId", 0),
                new NameValuePair("p_UserName", null),
                new NameValuePair("p_QueryType", "BYUSERTYPE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, NameValuePairs).ToList<User>();
        }

        public User GetUser(int UserId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_UserName", null),
                new NameValuePair("p_QueryType", "USER")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, NameValuePairs).ToList<User>().FirstOrDefault();
        }
        
        public User GetUser(string UserName)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_UserId", 0),
                new NameValuePair("p_UserName", UserName),
                new NameValuePair("p_QueryType", "USERNAME")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetUser, NameValuePairs).ToList<User>().FirstOrDefault();
        }

        public int Delete(int UserId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", UserId),
                new NameValuePair("p_UserTypeId", null),
                new NameValuePair("p_FullName", null),
                new NameValuePair("p_UserName", null),
                new NameValuePair("p_Email", null),
                new NameValuePair("p_Mobile", null),
                new NameValuePair("p_Address", null),
                new NameValuePair("p_Designation", null),
                //new NameValuePair("p_Password", password.PasswordText),
                new NameValuePair("p_IsActive", false),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DELETE")
            };

            UserId = Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUser, nvp, "Out_Param"));
            return UserId;
        }
    }
}