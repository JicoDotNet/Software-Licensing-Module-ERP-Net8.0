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
                using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
                {
                    nameValuePairs nvp = new nameValuePairs
                    {
                        new nameValuePair("p_DashboardId",userDashboard.DashboardId),
                        new nameValuePair("p_UserTypeId", userDashboard.UserTypeId),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "ASSIGN")
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
            using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
            {
                nameValuePairs nvp = new nameValuePairs
                {
                    new nameValuePair("p_DashboardId",0),
                    new nameValuePair("p_UserTypeId", UsertypeId),
                    new nameValuePair("p_SessionId", CommonObj.SessionId),
                    new nameValuePair("p_QueryType", "DEACTIVATE")
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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "USERTYPE"),
                new nameValuePair("p_UserTypeId", UserTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetDashboardForUser, nameValuePairs).ToList<UserDashboard>();
        }





    }
}
