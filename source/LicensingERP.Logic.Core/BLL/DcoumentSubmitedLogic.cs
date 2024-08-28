//using LicensingERP.Logic.Common;
//using LicensingERP.Logic.DTO.Class;
//using LicensingERP.Logic.DTO.SP;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DataAccess.MySql;

//namespace LicensingERP.Logic.BLL
//{
//    public class DcoumentSubmitedLogic:ConnectionString
//    {
//        public DcoumentSubmitedLogic(sCommonDto CommonObj) : base(CommonObj) { }
//        public void Insert(DcoumentSubmited dcoumentSubmited)
//        {
//            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString);

//            NameValuePairs nvp = new NameValuePairs();
//            nvp.Add(new NameValuePair("p_Id", 0));
//            nvp.Add(new NameValuePair("p_FileId", dcoumentSubmited.FileId));
//            nvp.Add(new NameValuePair("p_DocumentRequiredId", dcoumentSubmited.DocumentRequiredId));
//            nvp.Add(new NameValuePair("p_DocumentValue", dcoumentSubmited.DocumentValue));
//            nvp.Add(new NameValuePair("p_DocumentIssueDate", dcoumentSubmited.DocumentIssueDate));
//            nvp.Add(new NameValuePair("p_DocumentExpiryDate", dcoumentSubmited.DocumentExpiryDate));
//            nvp.Add(new NameValuePair("p_DocumentRequiredId", dcoumentSubmited.DocumentRequiredId));
//            nvp.Add(new NameValuePair("p_IssuedBy", dcoumentSubmited.IssuedBy));
//            nvp.Add(new NameValuePair("p_IsActive", true));
//            nvp.Add(new NameValuePair("p_SessionId", CommonObj.SessionId));
//            nvp.Add(new NameValuePair("p_QueryType", "INSERT"));

//            DAobj.InsertUpdateDeleteReturnInt(StoreProcedure.SetDcoumentSubmited, nvp);
//        }

//        public List<DcoumentSubmited> GetDcoumentSubmited()
//        {
//            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString);

//            NameValuePairs NameValuePairs = new NameValuePairs();

//            NameValuePairs.Add(new NameValuePair("p_QueryType", "ALL"));

//            return mySqlDBAccess.GetData(StoreProcedure.GetDcoumentSubmited, NameValuePairs).ToList<DcoumentSubmited>();
//        }
//    }
//}
