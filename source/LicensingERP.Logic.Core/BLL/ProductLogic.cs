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
    public class ProductLogic : ConnectionString
    {
        public ProductLogic(sCommonDto CommonObj): base(CommonObj) { }

        public int Insert(Product product)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                //new NameValuePair("p_LicenceTypeId", product.LicenceTypeId),
                new NameValuePair("p_ProductName", product.ProductName),
                new NameValuePair("p_ProductDetails", product.ProductDetails),
                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

           return Convert.ToInt32( mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProduct, nvp, "Out_Param"));
        }

        public List<Product> GetProuct()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_ProductId", 0),
                new NameValuePair("p_QueryType", "ALL")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetProduct, NameValuePairs).ToList<Product>();
        }

        public int Update(Product product)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", product.Id),
                new NameValuePair("p_ProductName",product.ProductName),
                new NameValuePair("p_ProductDetails", product.ProductDetails),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "UPDATE")
            };

          return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetProduct, nvp, "Out_Param"));
        }

        public Product GetProductType(int ProductId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                //new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_ProductId", ProductId),
                //new NameValuePair("p_UserName", null),
                new NameValuePair("p_QueryType", "PRODUCT")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetProduct, NameValuePairs).ToList<Product>().FirstOrDefault();

        }

        public int Deactivate(int ProductId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", ProductId),
                new NameValuePair("p_ProductName", null),
                new NameValuePair("p_ProductDetails", null),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetProduct, nvp, "Out_Param"));
        }
    }
}
