using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.BLL
{
    public class MenuAccessLogic : ConnectionString
    {
        public MenuAccessLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<MenuList> GetMenuList()
        {
            MySqlDBAccess mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_QueryType", "ASSIGN")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetMenuForAssign, nameValuePairs).ToList<MenuList>();
        }

        public int SetAccessPermission(List<UserMenu> userMenus)
        {
            int i = 0;
            //MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
           
            foreach (UserMenu userMenu in userMenus)
            {
                i++;
                if(i == 1)
                {
                    Deactivate(userMenu.UserTypeId);
                }
                using (MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
                {
                    nameValuePairs nvp = new nameValuePairs
                    {
                        new nameValuePair("p_MenuId", userMenu.MenuId),
                        new nameValuePair("p_UserTypeId", userMenu.UserTypeId),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "ASSIGN")
                    };

                    try
                    {
                        DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetMenuForUser, nvp, "Out_Param");
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return 1;
        }

        public int Deactivate(int UserTypeId)
        {
            using (MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure))
            {
                nameValuePairs nvp = new nameValuePairs
                    {
                    new nameValuePair("p_MenuId", 0),
                        new nameValuePair("p_UserTypeId", UserTypeId),
                        new nameValuePair("p_SessionId", CommonObj.SessionId),
                        new nameValuePair("p_QueryType", "DEACTIVATE")
                    };
                try
                {
                    return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetMenuForUser, nvp, "Out_Param"));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<UserMenu> GetAccessPermission(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "FORUSERTYPE"),
                new nameValuePair("p_UserId", UserTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetMenuForUser, nameValuePairs).ToList<UserMenu>();
        }

        public List<MenuGroup> GetMenuForUser(int UserTypeId)
        {
            MySqlDBAccess mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "FORUSER"),
                new nameValuePair("p_UserId", UserTypeId)
            };

            DataSet dataSet = mySqlDBAccess.GetDataSet(StoreProcedure.GetMenuForUser, nameValuePairs);
            List<MenuGroup> AccessMenuList = dataSet.Tables[0].ToList<MenuGroup>();
            List<MenuGroup> AllmenuGroups = dataSet.Tables[1].ToList<MenuGroup>();

            foreach (MenuGroup mg in AllmenuGroups)
            {
                mg.menuLists = AccessMenuList.Where(a => a.MenuGroupId == mg.Id).ToList<MenuList>();
            }

            AllmenuGroups.RemoveAll(a => a.menuLists.Count < 1 && string.IsNullOrEmpty(a.Controller));
            AccessMenuList = AccessMenuList.Where(a => a.MenuGroupId == 0).ToList();
            foreach (MenuGroup mg in AccessMenuList)
            {
                AllmenuGroups.Add(mg);
            }

            return AllmenuGroups;
        }
    }
}
