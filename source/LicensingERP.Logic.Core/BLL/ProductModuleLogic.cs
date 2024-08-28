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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_ProductId", productModule.ProductId),
                new nameValuePair("p_ModuleName", productModule.ModuleName),
                new nameValuePair("p_ModuleDetails", productModule.ModuleDetails),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProductModule, nvp, "Out_Param"));
        }

        public List<ProductModule> GetDatas(int ProductId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_ProductId", ProductId),
                new nameValuePair("p_QueryType", "FORPRODUCT")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetProductModule, nvp).ToList<ProductModule>();
        }
    }
}
