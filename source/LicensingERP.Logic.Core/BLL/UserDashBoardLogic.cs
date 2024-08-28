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
   public class UserDashBoardLogic : ConnectionString
    {
        public UserDashBoardLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(List<UserDashboard> userDashboards)
        {
            int i = 0;
           // Deactivate(UsertypeId);
            foreach (UserDashboard userDashboard  in userDashboards)
            {
                i++;
                if(i ==1)
                {
                    Deactivate(userDashboard.UserTypeId);
                }
                using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
                {
                    NameValuePairs nvp = new NameValuePairs
                    {
                        new NameValuePair("p_DashboardId",userDashboard.DashboardId),
                        new NameValuePair("p_UserTypeId", userDashboard.UserTypeId),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "ASSIGN")
                    };
                    try
                    {
                        DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserDashBoard, nvp, "Out_Param");
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return 1;
        }

        public int Deactivate(int UsertypeId)
        {
            using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
            {
                NameValuePairs nvp = new NameValuePairs
                {
                    new NameValuePair("p_DashboardId",0),
                    new NameValuePair("p_UserTypeId", UsertypeId),
                    new NameValuePair("p_SessionId", CommonObj.SessionId),
                    new NameValuePair("p_QueryType", "DEACTIVATE")
                };
                try
                {
                    return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetUserDashBoard, nvp, "Out_Param"));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<UserDashboard> GetAccessdashBoard(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "USERTYPE"),
                new NameValuePair("p_UserTypeId", UserTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetDashboardForUser, NameValuePairs).ToList<UserDashboard>();
        }





    }
}
