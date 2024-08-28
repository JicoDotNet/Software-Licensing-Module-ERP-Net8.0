using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using LicensingERP.Logic.Model.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class LoginManagment : ConnectionString
    {
        public LoginManagment(sCommonDto CommonObj) : base(CommonObj) { }

        public LoginCredentials Authenticate(LoginCredentials loginCredentials)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_UserName", loginCredentials.UserName),
                new NameValuePair("p_Password", loginCredentials.PasswordText),
                new NameValuePair("p_SessionId", CommonObj.SessionId)
            };

            List<User> UsersObj = mySqlDBAccess.GetData(StoreProcedure.LoginAuthenticate, nvp).ToList<User>();
            
            if (UsersObj.Count == 1)
            {
                Password password = new PasswordLogic(CommonObj).GetPassword(UsersObj[0].Id);

                if (password != null && password.PasswordText == loginCredentials.PasswordText)
                {
                    return new LoginCredentials()
                    {
                        UserId = UsersObj[0].Id,
                        UserTypeId = UsersObj[0].UserTypeId,
                        UserName = loginCredentials.UserName,
                        FullName = UsersObj[0].FullName,
                        IsChangeable = password.IsChangeable,
                        UserTypeName = UsersObj[0].UserTypeName,
                        UserTypeDetails = UsersObj[0].UserTypeDetails,
                        Email = UsersObj[0].Email
                    };
                }                
            }
            return null;
        }
    }
}
