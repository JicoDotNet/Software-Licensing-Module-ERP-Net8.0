using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.BLL
{
    public class ProductLogic : ConnectionString
    {
        public ProductLogic(sCommonDto CommonObj): base(CommonObj) { }

        public int Insert(Product product)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                //new nameValuePair("p_LicenceTypeId", product.LicenceTypeId),
                new nameValuePair("p_ProductName", product.ProductName),
                new nameValuePair("p_ProductDetails", product.ProductDetails),
                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

           return Convert.ToInt32( mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetProduct, nvp, "Out_Param"));
        }

        public List<Product> GetProuct()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_ProductId", 0),
                new nameValuePair("p_QueryType", "ALL")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetProduct, nameValuePairs).ToList<Product>();
        }

        public int Update(Product product)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", product.Id),
                new nameValuePair("p_ProductName",product.ProductName),
                new nameValuePair("p_ProductDetails", product.ProductDetails),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "UPDATE")
            };

          return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetProduct, nvp, "Out_Param"));
        }

        public Product GetProductType(int ProductId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                //new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_ProductId", ProductId),
                //new nameValuePair("p_UserName", null),
                new nameValuePair("p_QueryType", "PRODUCT")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetProduct, nameValuePairs).ToList<Product>().FirstOrDefault();

        }

        public int Deactivate(int ProductId)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", ProductId),
                new nameValuePair("p_ProductName", null),
                new nameValuePair("p_ProductDetails", null),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetProduct, nvp, "Out_Param"));
        }
    }
}
