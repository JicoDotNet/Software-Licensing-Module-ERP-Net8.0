using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class MenuLogic : ConnectionString
    {
        public MenuLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public void InsertMenuGroup(MenuGroup menuGroup, string SessionId)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs =
            [
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_Icon", menuGroup.Icon),
                new NameValuePair("p_DisplayText", menuGroup.DisplayText),
                new NameValuePair("p_SessionId", SessionId),
                new NameValuePair("p_CreatedBy", "DEVELOPER"),
                new NameValuePair("p_QueryType", "INSERT"),
            ];

            mySqlDBAccess.InsertUpdateDeleteReturnInt("sp_set_menu_group", NameValuePairs);
        }

        public List<MenuGroup> GetMenuGroup()
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));
            NameValuePairs.Add(new NameValuePair("p_Id", 0));

            return mySqlDBAccess.GetData("sp_Get_menu_group", NameValuePairs).ToList<MenuGroup>();
        }

        public void InsertMenuList(MenuList menuList, string SessionId)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs =
            [
                new NameValuePair("P_Id", 0),
                new NameValuePair("p_MenuGroupId", menuList.MenuGroupId),
                new NameValuePair("p_Icon", menuList.Icon),
                new NameValuePair("p_DisplayText", menuList.DisplayText),
                new NameValuePair("p_Controller", menuList.Controller),
                new NameValuePair("p_ActionResult", menuList.ActionResult),
                new NameValuePair("p_IsForAdmin", menuList.IsForAdmin),
                new NameValuePair("p_Description", menuList.Description),
                new NameValuePair("p_SessionId", SessionId),
                new NameValuePair("p_IsForWorkflow", menuList.IsForWorkflow),
                new NameValuePair("p_QueryType", "INSERT"),
            ];

            mySqlDBAccess.InsertUpdateDeleteReturnInt("sp_set_menu_list", NameValuePairs);
        }

        public List<MenuList> GetMenuList()
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));
            NameValuePairs.Add(new NameValuePair("p_Id", 0));

            return mySqlDBAccess.GetData("sp_Get_menu_list", NameValuePairs).ToList<MenuList>();
        }
        public MenuList GetMenuList(int id)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs()
            {
                new NameValuePair("p_QueryType", "ONE"),
                new NameValuePair("p_Id", id)
            };
            return mySqlDBAccess.GetData("sp_Get_menu_list", NameValuePairs).ToList<MenuList>().FirstOrDefault();
        }
    }
}
