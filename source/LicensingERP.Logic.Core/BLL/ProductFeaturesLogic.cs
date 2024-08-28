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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_ProductId", productFeatures.ProductId),
                new NameValuePair("p_FeaturesName", productFeatures.FeaturesName),
                new NameValuePair("p_FeaturesDetails", productFeatures.FeaturesDetails),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProductFeatures, nvp, "Out_Param"));
        }

        public List<ProductFeatures> GetDatas(int ProductId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_ProductId", ProductId),
                new NameValuePair("p_QueryType", "FORPRODUCT")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetProductFeatures, nvp).ToList<ProductFeatures>();
        }
    }
}
