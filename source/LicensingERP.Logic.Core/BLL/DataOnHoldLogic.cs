using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", null),
                new nameValuePair("p_CaseType", dataOnHold.CaseType),
                new nameValuePair("p_Purpose", dataOnHold.Purpose),
                new nameValuePair("p_EffectedData", dataOnHold.EffectedData),
                new nameValuePair("p_EffectedRowId", dataOnHold.EffectedRowId),
                new nameValuePair("p_EffectedDataDisplay", dataOnHold.EffectedDataDisplay),
                new nameValuePair("p_OldDataDisplay",dataOnHold.OldDataDisplay),
                new nameValuePair("p_CreatedUserId", dataOnHold.CreatedUserId),
                new nameValuePair("p_CreatedUserTypeId", dataOnHold.CreatedUserTypeId),
                new nameValuePair("p_ApproveRejectUserId", null),
                new nameValuePair("p_ApproveRejectUserTypeId", null),
                new nameValuePair("p_ApproveRejectRemarks", null),
                new nameValuePair("p_ApproveRejectDate", null),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetMCDataOnHold, nvp, "Out_Param"));
        }

        public int Approve(DataOnHold<T> dataOnHold)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", dataOnHold.Id),
                new nameValuePair("p_CaseType", null),
                new nameValuePair("p_Purpose", null),
                new nameValuePair("p_EffectedData", null),
                new nameValuePair("p_EffectedDataDisplay", dataOnHold.EffectedDataDisplay),
                new nameValuePair("p_OldDataDisplay",dataOnHold.OldDataDisplay),
                new nameValuePair("p_EffectedRowId", null),
                new nameValuePair("p_CreatedUserId", null),
                new nameValuePair("p_CreatedUserTypeId", null),
                new nameValuePair("p_ApproveRejectUserId", dataOnHold.ApproveRejectUserId),
                new nameValuePair("p_ApproveRejectUserTypeId", dataOnHold.ApproveRejectUserTypeId),
                new nameValuePair("p_ApproveRejectRemarks", dataOnHold.ApproveRejectRemarks),
                new nameValuePair("p_ApproveRejectDate", dataOnHold.ApproveRejectDate),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "APPROVE")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetMCDataOnHold, nvp, "Out_Param"));
        }

        public int Decline(DataOnHold<T> dataOnHold)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", dataOnHold.Id),
                new nameValuePair("p_CaseType", null),
                new nameValuePair("p_Purpose", null),
                new nameValuePair("p_EffectedData", null),
                new nameValuePair("p_EffectedDataDisplay", dataOnHold.EffectedDataDisplay),
                new nameValuePair("p_OldDataDisplay",dataOnHold.OldDataDisplay),
                new nameValuePair("p_EffectedRowId", null),
                new nameValuePair("p_CreatedUserId", null),
                new nameValuePair("p_CreatedUserTypeId", null),
                new nameValuePair("p_ApproveRejectUserId", dataOnHold.ApproveRejectUserId),
                new nameValuePair("p_ApproveRejectUserTypeId", dataOnHold.ApproveRejectUserTypeId),
                new nameValuePair("p_ApproveRejectRemarks", dataOnHold.ApproveRejectRemarks),
                new nameValuePair("p_ApproveRejectDate", dataOnHold.ApproveRejectDate),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "DECLINE")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetMCDataOnHold, nvp, "Out_Param"));
        }

        public List<DataOnHold<T>> GetPendingDatas(int UserId, int UserTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_UserTypeId", UserTypeId),
                new nameValuePair("p_QueryType", "FORUSER")
            };
            List<DataOnHold<T>> dataOnHolds = mySqlDBAccess.GetData(StoreProcedure.GetMCDataOnHold, nameValuePairs).ToList<DataOnHold<T>>();
            foreach(DataOnHold<T> dataOnHold in dataOnHolds)
            {
                dataOnHold.ToObject();
            }
            return dataOnHolds;
        }
        public DataOnHold<T> GetPendingData(int UserId, int UserTypeId, int Id)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_Id", Id),
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_UserTypeId", UserTypeId),
                new nameValuePair("p_QueryType", "SINGLE")
            };
            List<DataOnHold<T>> dataOnHolds = mySqlDBAccess.GetData(StoreProcedure.GetMCDataOnHold, nameValuePairs).ToList<DataOnHold<T>>();
            foreach (DataOnHold<T> dataOnHold in dataOnHolds)
            {
                dataOnHold.ToObject();
            }
            return dataOnHolds.FirstOrDefault();
        }
    }
}
