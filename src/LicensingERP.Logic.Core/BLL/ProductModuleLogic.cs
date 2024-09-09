using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
   public class ProductModuleLogic : ProductLogic
    {
        public ProductModuleLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(ProductModule productModule)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_ProductId", productModule.ProductId),
                new NameValuePair("p_ModuleName", productModule.ModuleName),
                new NameValuePair("p_ModuleDetails", productModule.ModuleDetails),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProductModule, nvp, "Out_Param"));
        }

        public List<ProductModule> GetDatas(int ProductId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_ProductId", ProductId),
                new NameValuePair("p_QueryType", "FORPRODUCT")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetProductModule, nvp).ToList<ProductModule>();
        }
    }
}
