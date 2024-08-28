using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class DataOnHoldLogic<T> : ConnectionString
    {
        T DataOnHoldDynamicObj;

        public DataOnHoldLogic(sCommonDto CommonObj) : base(CommonObj)
        {
            DataOnHoldDynamicObj = default(T);
        }

        public int Insert(DataOnHold<T> dataOnHold)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", null),
                new NameValuePair("p_CaseType", dataOnHold.CaseType),
                new NameValuePair("p_Purpose", dataOnHold.Purpose),
                new NameValuePair("p_EffectedData", dataOnHold.EffectedData),
                new NameValuePair("p_EffectedRowId", dataOnHold.EffectedRowId),
                new NameValuePair("p_EffectedDataDisplay", dataOnHold.EffectedDataDisplay),
                new NameValuePair("p_OldDataDisplay",dataOnHold.OldDataDisplay),
                new NameValuePair("p_CreatedUserId", dataOnHold.CreatedUserId),
                new NameValuePair("p_CreatedUserTypeId", dataOnHold.CreatedUserTypeId),
                new NameValuePair("p_ApproveRejectUserId", null),
                new NameValuePair("p_ApproveRejectUserTypeId", null),
                new NameValuePair("p_ApproveRejectRemarks", null),
                new NameValuePair("p_ApproveRejectDate", null),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetMCDataOnHold, nvp, "Out_Param"));
        }

        public int Approve(DataOnHold<T> dataOnHold)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", dataOnHold.Id),
                new NameValuePair("p_CaseType", null),
                new NameValuePair("p_Purpose", null),
                new NameValuePair("p_EffectedData", null),
                new NameValuePair("p_EffectedDataDisplay", dataOnHold.EffectedDataDisplay),
                new NameValuePair("p_OldDataDisplay",dataOnHold.OldDataDisplay),
                new NameValuePair("p_EffectedRowId", null),
                new NameValuePair("p_CreatedUserId", null),
                new NameValuePair("p_CreatedUserTypeId", null),
                new NameValuePair("p_ApproveRejectUserId", dataOnHold.ApproveRejectUserId),
                new NameValuePair("p_ApproveRejectUserTypeId", dataOnHold.ApproveRejectUserTypeId),
                new NameValuePair("p_ApproveRejectRemarks", dataOnHold.ApproveRejectRemarks),
                new NameValuePair("p_ApproveRejectDate", dataOnHold.ApproveRejectDate),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "APPROVE")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetMCDataOnHold, nvp, "Out_Param"));
        }

        public int Decline(DataOnHold<T> dataOnHold)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", dataOnHold.Id),
                new NameValuePair("p_CaseType", null),
                new NameValuePair("p_Purpose", null),
                new NameValuePair("p_EffectedData", null),
                new NameValuePair("p_EffectedDataDisplay", dataOnHold.EffectedDataDisplay),
                new NameValuePair("p_OldDataDisplay",dataOnHold.OldDataDisplay),
                new NameValuePair("p_EffectedRowId", null),
                new NameValuePair("p_CreatedUserId", null),
                new NameValuePair("p_CreatedUserTypeId", null),
                new NameValuePair("p_ApproveRejectUserId", dataOnHold.ApproveRejectUserId),
                new NameValuePair("p_ApproveRejectUserTypeId", dataOnHold.ApproveRejectUserTypeId),
                new NameValuePair("p_ApproveRejectRemarks", dataOnHold.ApproveRejectRemarks),
                new NameValuePair("p_ApproveRejectDate", dataOnHold.ApproveRejectDate),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "DECLINE")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetMCDataOnHold, nvp, "Out_Param"));
        }

        public List<DataOnHold<T>> GetPendingDatas(int UserId, int UserTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_QueryType", "FORUSER")
            };
            List<DataOnHold<T>> dataOnHolds = mySqlDBAccess.GetData(StoreProcedure.GetMCDataOnHold, NameValuePairs).ToList<DataOnHold<T>>();
            foreach(DataOnHold<T> dataOnHold in dataOnHolds)
            {
                dataOnHold.ToObject();
            }
            return dataOnHolds;
        }
        public DataOnHold<T> GetPendingData(int UserId, int UserTypeId, int Id)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_Id", Id),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_QueryType", "SINGLE")
            };
            List<DataOnHold<T>> dataOnHolds = mySqlDBAccess.GetData(StoreProcedure.GetMCDataOnHold, NameValuePairs).ToList<DataOnHold<T>>();
            foreach (DataOnHold<T> dataOnHold in dataOnHolds)
            {
                dataOnHold.ToObject();
            }
            return dataOnHolds.FirstOrDefault();
        }
    }
}
