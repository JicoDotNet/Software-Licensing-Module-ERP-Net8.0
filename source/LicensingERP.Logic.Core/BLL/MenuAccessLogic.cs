using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class MenuAccessLogic : ConnectionString
    {
        public MenuAccessLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<MenuList> GetMenuList()
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_QueryType", "ASSIGN")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetMenuForAssign, NameValuePairs).ToList<MenuList>();
        }

        public int SetAccessPermission(List<UserMenu> userMenus)
        {
            int i = 0;
            //MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString);
           
            foreach (UserMenu userMenu in userMenus)
            {
                i++;
                if(i == 1)
                {
                    Deactivate(userMenu.UserTypeId);
                }
                using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
                {
                    NameValuePairs nvp = new NameValuePairs
                    {
                        new NameValuePair("p_MenuId", userMenu.MenuId),
                        new NameValuePair("p_UserTypeId", userMenu.UserTypeId),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "ASSIGN")
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
            using (MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString))
            {
                NameValuePairs nvp = new NameValuePairs
                    {
                    new NameValuePair("p_MenuId", 0),
                        new NameValuePair("p_UserTypeId", UserTypeId),
                        new NameValuePair("p_SessionId", CommonObj.SessionId),
                        new NameValuePair("p_QueryType", "DEACTIVATE")
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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "FORUSERTYPE"),
                new NameValuePair("p_UserId", UserTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetMenuForUser, NameValuePairs).ToList<UserMenu>();
        }

        public List<MenuGroup> GetMenuForUser(int UserTypeId)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "FORUSER"),
                new NameValuePair("p_UserId", UserTypeId)
            };

            DataSet dataSet = mySqlDBAccess.GetDataSet(StoreProcedure.GetMenuForUser, NameValuePairs);
            List<MenuList> AccessMenuList = dataSet.Tables[0].ToList<MenuList>();
            List<MenuGroup> AllmenuGroups = dataSet.Tables[1].ToList<MenuGroup>();

            foreach (MenuGroup mg in AllmenuGroups)
            {
                mg.menuLists = AccessMenuList.Where(a => a.MenuGroupId == mg.Id).ToList();
            }

            AllmenuGroups.RemoveAll(a => a.menuLists.Count < 1);
            //AccessMenuList = AccessMenuList.Where(a => a.MenuGroupId == 0).ToList();
            //foreach (MenuList mg in AccessMenuList)
            //{
            //    AllmenuGroups.Add(mg);
            //}

            return AllmenuGroups;
        }
    }
}
