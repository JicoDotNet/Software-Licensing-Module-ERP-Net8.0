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
            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("p_Id", 0));
            NameValuePairs.Add(new NameValuePair("p_Icon", menuGroup.Icon));
            NameValuePairs.Add(new NameValuePair("p_DisplayText", menuGroup.DisplayText));
            NameValuePairs.Add(new NameValuePair("p_IsActive", menuGroup.IsActive));
            NameValuePairs.Add(new NameValuePair("p_IsDisplayable", menuGroup.IsDisplayable));
            NameValuePairs.Add(new NameValuePair("p_SessionId", SessionId));
            NameValuePairs.Add(new NameValuePair("p_CreatedBy", "DEVELOPER"));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "INSERT"));

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
            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("P_Id", 0));
            NameValuePairs.Add(new NameValuePair("p_MenuGroupId", menuList.MenuGroupId));
            NameValuePairs.Add(new NameValuePair("p_Icon", menuList.Icon));
            NameValuePairs.Add(new NameValuePair("p_DisplayText", menuList.DisplayText));
            NameValuePairs.Add(new NameValuePair("p_Controller", menuList.Controller));
            NameValuePairs.Add(new NameValuePair("p_ActionResult", menuList.ActionResult));
            NameValuePairs.Add(new NameValuePair("p_RouteId", menuList.RouteId));
            NameValuePairs.Add(new NameValuePair("p_QueryString", menuList.QueryString));
            NameValuePairs.Add(new NameValuePair("p_HttpType", menuList.HttpType));
            NameValuePairs.Add(new NameValuePair("p_IsActive", menuList.IsActive));
            NameValuePairs.Add(new NameValuePair("p_IsDisplayable", menuList.IsDisplayable));
            NameValuePairs.Add(new NameValuePair("p_IsForAdmin", menuList.IsForAdmin));
            NameValuePairs.Add(new NameValuePair("p_Description", menuList.Description));
            NameValuePairs.Add(new NameValuePair("p_SessionId", SessionId));
            NameValuePairs.Add(new NameValuePair("p_IsForWorkflow", menuList.IsForWorkflow));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "INSERT"));

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
