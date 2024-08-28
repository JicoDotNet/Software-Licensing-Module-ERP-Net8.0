using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
   public class MailUserListLogic : ConnectionString
    {
        public MailUserListLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<User> MailUserRequisition(int UserType)
        {
            
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserType",UserType ),
                new NameValuePair("p_QueryString", "MAIL")
            };

            List<User> users =  mySqlDBAccess.GetData(StoreProcedure.GetUserMailList, NameValuePairs).ToList<User>();



            return users;
        }

    }
}
