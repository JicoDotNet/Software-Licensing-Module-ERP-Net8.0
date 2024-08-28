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
    public class ClientCategoryLogic:ConnectionString
    {
        public ClientCategoryLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(ClientCategory clientcategory)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs();
            nvp.Add(new NameValuePair("p_Id", 0));
            nvp.Add(new NameValuePair("p_CategoryName", clientcategory.CategoryName));
            nvp.Add(new NameValuePair("p_CategoryDetails", clientcategory.CategoryDetails));
            nvp.Add(new NameValuePair("p_IsActive", true));
            nvp.Add(new NameValuePair("p_SessionId", CommonObj.SessionId));
            nvp.Add(new NameValuePair("p_QueryType", "INSERT"));

         return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClientCategory, nvp, "Out_Param"));
        }

        public List<ClientCategory> GetClientCategory()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs();

            NameValuePairs.Add(new NameValuePair("p_CategoryId", 0));
            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetClientCategory, NameValuePairs).ToList<ClientCategory>();
        }

        public int Update(ClientCategory clientcategory)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", clientcategory.Id),
                new NameValuePair("p_CategoryName", clientcategory.CategoryName),
                new NameValuePair("p_CategoryDetails", clientcategory.CategoryDetails),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "UPDATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClientCategory, nvp, "Out_Param"));
        }

        public ClientCategory GetClientCategory(int ClientCategoryId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_CategoryId", ClientCategoryId),
                new NameValuePair("p_QueryType", "CLIENTCATEGORY")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetClientCategory, NameValuePairs).ToList<ClientCategory>().FirstOrDefault();
        }
        public int Deactivate(int CategoryId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", CategoryId),
                new NameValuePair("p_CategoryName", null),
                new NameValuePair("p_CategoryDetails", null),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClientCategory, nvp, "Out_Param"));
        }


    }
}
