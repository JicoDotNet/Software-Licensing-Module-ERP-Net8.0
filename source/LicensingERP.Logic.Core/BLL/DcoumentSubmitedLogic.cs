using _3RDLife.Logic.Common;
using _3RDLife.Logic.DTO.Class;
using _3RDLife.Logic.DTO.SP;
using Agitech.DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3RDLife.Logic.BLL
{
    public class DcoumentSubmitedLogic:ConnectionString
    {
        public DcoumentSubmitedLogic(sCommonDto CommonObj) : base(CommonObj) { }
        public void Insert(DcoumentSubmited dcoumentSubmited)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs();
            nvp.Add(new nameValuePair("p_Id", 0));
            nvp.Add(new nameValuePair("p_FileId", dcoumentSubmited.FileId));
            nvp.Add(new nameValuePair("p_DocumentRequiredId", dcoumentSubmited.DocumentRequiredId));
            nvp.Add(new nameValuePair("p_DocumentValue", dcoumentSubmited.DocumentValue));
            nvp.Add(new nameValuePair("p_DocumentIssueDate", dcoumentSubmited.DocumentIssueDate));
            nvp.Add(new nameValuePair("p_DocumentExpiryDate", dcoumentSubmited.DocumentExpiryDate));
            nvp.Add(new nameValuePair("p_DocumentRequiredId", dcoumentSubmited.DocumentRequiredId));
            nvp.Add(new nameValuePair("p_IssuedBy", dcoumentSubmited.IssuedBy));
            nvp.Add(new nameValuePair("p_IsActive", true));
            nvp.Add(new nameValuePair("p_SessionId", CommonObj.SessionId));
            nvp.Add(new nameValuePair("p_QueryType", "INSERT"));

            DAobj.InsertUpdateDeleteReturnInt(StoreProcedure.SetDcoumentSubmited, nvp);
        }

        public List<DcoumentSubmited> GetDcoumentSubmited()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs();

            nameValuePairs.Add(new nameValuePair("p_QueryType", "ALL"));

            return mySqlDBAccess.GetData(StoreProcedure.GetDcoumentSubmited, nameValuePairs).ToList<DcoumentSubmited>();
        }
    }
}
