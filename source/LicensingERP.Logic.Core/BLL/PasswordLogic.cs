using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LicensingERP.Logic.BLL
{
    public class PasswordLogic : ConnectionString
    {
        public PasswordLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int InsertNewPassword(Password password, PasswordSecurity passwordSecurity)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_UserId", passwordSecurity.UserId),
                new nameValuePair("p_QuestionEnumNo", passwordSecurity.QuestionEnumNo),
                new nameValuePair("p_Question", passwordSecurity.Question),
                new nameValuePair("p_Answer", passwordSecurity.Answer),
                //new nameValuePair("p_Password", password.PasswordText),

                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
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
            #region Crypto Password
            password.Encrypt();
            #endregion

            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_UserId", password.UserId),
                new nameValuePair("p_PasswordHash", password.PasswordHash),
                new nameValuePair("p_ActivationDate", GenericLogic.IstNow),
                new nameValuePair("p_PasswordSalt", password.PasswordSalt),
                //new nameValuePair("p_PasswordText", password.PasswordText),
                new nameValuePair("p_IsChangeable", IsChangeable),

                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetPassword, nvp, "Out_Param"));
        }

        public Password GetPassword(int UserId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_UserId", UserId)
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
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_QueryType", "ACTIVE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetePasswordSecurityQuestions, nameValuePairs).ToList<PasswordSecurity>().FirstOrDefault();
        }

        public int InsertPasswordResetRequest(string UserName)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_UserName", UserName),

                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetPasswordResetRequest, nvp, "Out_Param"));
        }

        public List<PasswordResetRequest> GetResetRequests()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "ACTIVE")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetPasswordResetRequest, nameValuePairs).ToList<PasswordResetRequest>();
        }
    }
}
