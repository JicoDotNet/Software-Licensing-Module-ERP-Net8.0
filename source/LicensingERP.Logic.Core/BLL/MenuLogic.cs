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
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_Id", 0));
            nameValuePairs.Add(new nameValuePair("p_Icon", menuGroup.Icon));
            nameValuePairs.Add(new nameValuePair("p_DisplayText", menuGroup.DisplayText));
            nameValuePairs.Add(new nameValuePair("p_IsActive", menuGroup.IsActive));
            nameValuePairs.Add(new nameValuePair("p_IsDisplayable", menuGroup.IsDisplayable));
            nameValuePairs.Add(new nameValuePair("p_SessionId", SessionId));
            nameValuePairs.Add(new nameValuePair("p_CreatedBy", "DEVELOPER"));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "INSERT"));

            mySqlDBAccess.InsertUpdateDeleteReturnInt("sp_set_menu_group", nameValuePairs);
        }

        public List<MenuGroup> GetMenuGroup()
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));
            nameValuePairs.Add(new nameValuePair("p_Id", 0));

            return mySqlDBAccess.GetData("sp_Get_menu_group", nameValuePairs).ToList<MenuGroup>();
        }

        public void InsertMenuList(MenuList menuList, string SessionId)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("P_Id", 0));
            nameValuePairs.Add(new nameValuePair("p_MenuGroupId", menuList.MenuGroupId));
            nameValuePairs.Add(new nameValuePair("p_Icon", menuList.Icon));
            nameValuePairs.Add(new nameValuePair("p_DisplayText", menuList.DisplayText));
            nameValuePairs.Add(new nameValuePair("p_Controller", menuList.Controller));
            nameValuePairs.Add(new nameValuePair("p_ActionResult", menuList.ActionResult));
            nameValuePairs.Add(new nameValuePair("p_RouteId", menuList.RouteId));
            nameValuePairs.Add(new nameValuePair("p_QueryString", menuList.QueryString));
            nameValuePairs.Add(new nameValuePair("p_HttpType", menuList.HttpType));
            nameValuePairs.Add(new nameValuePair("p_IsActive", menuList.IsActive));
            nameValuePairs.Add(new nameValuePair("p_IsDisplayable", menuList.IsDisplayable));
            nameValuePairs.Add(new nameValuePair("p_IsForAdmin", menuList.IsForAdmin));
            nameValuePairs.Add(new nameValuePair("p_Description", menuList.Description));
            nameValuePairs.Add(new nameValuePair("p_SessionId", SessionId));
            nameValuePairs.Add(new nameValuePair("p_IsForWorkflow", menuList.IsForWorkflow));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "INSERT"));

            mySqlDBAccess.InsertUpdateDeleteReturnInt("sp_set_menu_list", nameValuePairs);
        }

        public List<MenuList> GetMenuList()
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));
            nameValuePairs.Add(new nameValuePair("p_Id", 0));

            return mySqlDBAccess.GetData("sp_Get_menu_list", nameValuePairs).ToList<MenuList>();
        }
        public MenuList GetMenuList(int id)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs()
            {
                new nameValuePair("p_QueryType", "ONE"),
                new nameValuePair("p_Id", id)
            };
            return mySqlDBAccess.GetData("sp_Get_menu_list", nameValuePairs).ToList<MenuList>().FirstOrDefault();
        }
    }
}
