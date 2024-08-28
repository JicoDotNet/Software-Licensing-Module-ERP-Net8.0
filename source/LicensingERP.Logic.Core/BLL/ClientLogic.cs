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
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_CategoryId", client.CategoryId),
                new nameValuePair("p_ClientName", client.ClientName),
                new nameValuePair("p_ClientNumber", client.ClientNumber),
                new nameValuePair("p_ClientEmail", client.ClientEmail),
                new nameValuePair("p_CompanyName", client.CompanyName),
                new nameValuePair("p_CompanyAddress", client.CompanyAddress),
                new nameValuePair("p_CompanyNumber", client.CompanyNumber),
                new nameValuePair("p_CompanyEmail", client.CompanyEmail),
                new nameValuePair("p_GSTIN", client.GSTIN),
                new nameValuePair("p_PANNo", client.PANNo),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClient, nvp, "Out_Param"));
        }

        public int Deactivate(int ClientId)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", ClientId),
                new nameValuePair("p_CategoryId", null),
                new nameValuePair("p_ClientName", null),
                new nameValuePair("p_ClientNumber", null),
                new nameValuePair("p_ClientEmail", null),
                new nameValuePair("p_CompanyName", null),
                new nameValuePair("p_CompanyAddress", null),
                new nameValuePair("p_CompanyNumber",null),
                new nameValuePair("p_CompanyEmail",null),
                new nameValuePair("p_GSTIN",null),
                new nameValuePair("p_PANNo",null),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DEACTIVATE")
            };

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClient, nvp, "Out_Param"));
        }

        public List<Client> GetClients()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_ClientId", 0),
                new nameValuePair("p_QueryType", "ALL")
            };

            return mySqlDBAccess.GetData(StoreProcedure.GetClient, nameValuePairs).ToList<Client>();
        }

        public Client GetClient(int ClientId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_ClientId", ClientId),
                new nameValuePair("p_QueryType", "CLIENT")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetClient, nameValuePairs).ToList<Client>().FirstOrDefault();
        }

        /*public Client GetClientCategory(int ClientId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_ClientType", 0),
                new nameValuePair("p_ClientId", ClientId),
                new nameValuePair("p_ClientName", null),
                new nameValuePair("p_QueryType", "CLIENT")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetClient, nameValuePairs).ToList<Client>().FirstOrDefault();
        }*/

        public int Update(Client client)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", client.Id),
                new nameValuePair("p_CategoryId",client.CategoryId),
                new nameValuePair("p_ClientName", client.ClientName),
                new nameValuePair("p_ClientNumber",client.ClientNumber),
                new nameValuePair("p_ClientEmail", client.ClientEmail),
                new nameValuePair("p_CompanyName", client.CompanyName),
                new nameValuePair("p_CompanyAddress", client.CompanyAddress),
                new nameValuePair("p_CompanyNumber",client.CompanyNumber),
                new nameValuePair("p_CompanyEmail", client.CompanyEmail),
                new nameValuePair("p_GSTIN", client.GSTIN),
                new nameValuePair("p_PANNo", client.PANNo),


                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "UPDATE")
            };

           return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetClient, nvp, "Out_Param"));
        }
    }
}
