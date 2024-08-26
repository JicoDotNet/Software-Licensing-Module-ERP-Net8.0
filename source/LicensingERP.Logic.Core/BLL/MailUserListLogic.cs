using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL
{
   public class MailUserListLogic : ConnectionString
    {
        public MailUserListLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<User> MailUserRequisition(int UserType)
        {
            
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserType",UserType ),
                new nameValuePair("p_QueryString", "MAIL")
            };

            List<User> users =  mySqlDBAccess.GetData(StoreProcedure.GetUserMailList, nameValuePairs).ToList<User>();



            return users;
        }

    }
}
