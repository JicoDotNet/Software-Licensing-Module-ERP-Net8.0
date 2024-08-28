using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class ProductFeaturesLogic : ProductLogic
    {
        public ProductFeaturesLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(ProductFeatures productFeatures)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_ProductId", productFeatures.ProductId),
                new nameValuePair("p_FeaturesName", productFeatures.FeaturesName),
                new nameValuePair("p_FeaturesDetails", productFeatures.FeaturesDetails),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProductFeatures, nvp, "Out_Param"));
        }

        public List<ProductFeatures> GetDatas(int ProductId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_ProductId", ProductId),
                new nameValuePair("p_QueryType", "FORPRODUCT")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetProductFeatures, nvp).ToList<ProductFeatures>();
        }
    }
}
