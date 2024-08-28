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
    public class ClientLogic: ConnectionString
    {
        public ClientLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(Client client)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_CategoryId", client.CategoryId),
                new NameValuePair("p_ClientName", client.ClientName),
                new NameValuePair("p_ClientNumber", client.ClientNumber),
                new NameValuePair("p_ClientEmail", client.ClientEmail),
                new NameValuePair("p_CompanyName", client.CompanyName),
                new NameValuePair("p_CompanyAddress", client.CompanyAddress),
                new NameValuePair("p_CompanyNumber", client.CompanyNumber),
                new NameValuePair("p_CompanyEmail", client.CompanyEmail),
                new NameValuePair("p_GSTIN", client.GSTIN),
                new NameValuePair("p_PANNo", client.PANNo),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClient, nvp, "Out_Param"));
        }

        public int Deactivate(int ClientId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", ClientId),
                new NameValuePair("p_CategoryId", null),
                new NameValuePair("p_ClientName", null),
                new NameValuePair("p_ClientNumber", null),
                new NameValuePair("p_ClientEmail", null),
                new NameValuePair("p_CompanyName", null),
                new NameValuePair("p_CompanyAddress", null),
                new NameValuePair("p_CompanyNumber",null),
                new NameValuePair("p_CompanyEmail",null),
                new NameValuePair("p_GSTIN",null),
                new NameValuePair("p_PANNo",null),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClient, nvp, "Out_Param"));
        }

        public List<Client> GetClients()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_ClientId", 0),
                new NameValuePair("p_QueryType", "ALL")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetClient, NameValuePairs).ToList<Client>();
        }

        public Client GetClient(int ClientId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_ClientId", ClientId),
                new NameValuePair("p_QueryType", "CLIENT")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetClient, NameValuePairs).ToList<Client>().FirstOrDefault();
        }

        /*public Client GetClientCategory(int ClientId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_ClientType", 0),
                new NameValuePair("p_ClientId", ClientId),
                new NameValuePair("p_ClientName", null),
                new NameValuePair("p_QueryType", "CLIENT")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetClient, NameValuePairs).ToList<Client>().FirstOrDefault();
        }*/

        public int Update(Client client)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", client.Id),
                new NameValuePair("p_CategoryId",client.CategoryId),
                new NameValuePair("p_ClientName", client.ClientName),
                new NameValuePair("p_ClientNumber",client.ClientNumber),
                new NameValuePair("p_ClientEmail", client.ClientEmail),
                new NameValuePair("p_CompanyName", client.CompanyName),
                new NameValuePair("p_CompanyAddress", client.CompanyAddress),
                new NameValuePair("p_CompanyNumber",client.CompanyNumber),
                new NameValuePair("p_CompanyEmail", client.CompanyEmail),
                new NameValuePair("p_GSTIN", client.GSTIN),
                new NameValuePair("p_PANNo", client.PANNo),


                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "UPDATE")
            };

           return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClient, nvp, "Out_Param"));
        }
    }
}
