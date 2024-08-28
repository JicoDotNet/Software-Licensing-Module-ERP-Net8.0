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
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs();
            nvp.Add(new nameValuePair("p_Id", 0));
            nvp.Add(new nameValuePair("p_CategoryName", clientcategory.CategoryName));
            nvp.Add(new nameValuePair("p_CategoryDetails", clientcategory.CategoryDetails));
            nvp.Add(new nameValuePair("p_IsActive", true));
            nvp.Add(new nameValuePair("p_SessionId", CommonObj.SessionId));
            nvp.Add(new nameValuePair("p_QueryType", "INSERT"));

         return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClientCategory, nvp, "Out_Param"));
        }

        public List<ClientCategory> GetClientCategory()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_CategoryId", 0));
            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetClientCategory, nameValuePairs).ToList<ClientCategory>();
        }

        public int Update(ClientCategory clientcategory)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", clientcategory.Id),
                new nameValuePair("p_CategoryName", clientcategory.CategoryName),
                new nameValuePair("p_CategoryDetails", clientcategory.CategoryDetails),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "UPDATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClientCategory, nvp, "Out_Param"));
        }

        public ClientCategory GetClientCategory(int ClientCategoryId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_CategoryId", ClientCategoryId),
                new nameValuePair("p_QueryType", "CLIENTCATEGORY")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetClientCategory, nameValuePairs).ToList<ClientCategory>().FirstOrDefault();
        }
        public int Deactivate(int CategoryId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", CategoryId),
                new nameValuePair("p_CategoryName", null),
                new nameValuePair("p_CategoryDetails", null),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClientCategory, nvp, "Out_Param"));
        }


    }
}
