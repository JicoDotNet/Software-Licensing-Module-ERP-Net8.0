using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class PasswordLogic : ConnectionString
    {
        public PasswordLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int InsertNewPassword(Password password, PasswordSecurity passwordSecurity)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_UserId", passwordSecurity.UserId),
                new NameValuePair("p_QuestionEnumNo", passwordSecurity.QuestionEnumNo),
                new NameValuePair("p_Question", passwordSecurity.Question),
                new NameValuePair("p_Answer", passwordSecurity.Answer),
                //new NameValuePair("p_Password", password.PasswordText),

                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            int Id = Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetePasswordSecurityQuestions, nvp, "Out_Param"));
            if (Id > 0)
            {
                password.UserId = passwordSecurity.UserId;
                return SetPassword(password, false);
            }            
            return 0;
        }

        public int SetPassword(Password password, bool IsChangeable = false)
        {
            #region Encrypt Password
            password.Encrypt();
            #endregion

            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_UserId", password.UserId),
                new NameValuePair("p_PasswordHash", password.PasswordHash),
                new NameValuePair("p_ActivationDate", GenericLogic.IstNow),
                new NameValuePair("p_PasswordSalt", password.PasswordSalt),
                new NameValuePair("p_IsChangeable", IsChangeable),

                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetPassword, nvp, "Out_Param"));
        }

        public Password GetPassword(int UserId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_UserId", UserId)
            };
            Password password = mySqlDBAccess.GetData("sp_Get_Password", nvp).ToList<Password>().FirstOrDefault();

            if (password != null)
            {
                #region Decrypt Password
                password.Decrypt();
                #endregion

                return password;
            }
            else
            {
                return null;
            }
        }

        public PasswordSecurity GetePasswordSecurityQuestions(int UserId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_QueryType", "ACTIVE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetePasswordSecurityQuestions, NameValuePairs).ToList<PasswordSecurity>().FirstOrDefault();
        }

        public int InsertPasswordResetRequest(string UserName)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_UserName", UserName),

                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetPasswordResetRequest, nvp, "Out_Param"));
        }

        public List<PasswordResetRequest> GetResetRequests()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "ACTIVE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetPasswordResetRequest, NameValuePairs).ToList<PasswordResetRequest>();
        }
    }
}
