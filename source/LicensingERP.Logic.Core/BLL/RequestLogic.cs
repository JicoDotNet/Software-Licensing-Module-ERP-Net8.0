using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LicensingERP.Logic.BLL
{
    public class RequestLogic : ConnectionString
    {
        public RequestLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(Request request)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_Id", 0),
                new nameValuePair("p_ClientId", request.ClientId),
                new nameValuePair("p_LicenceTypeId", request.LicenceTypeId),
                new nameValuePair("p_ProductId", request.ProductId),
                new nameValuePair("p_LicenceNo", request.LicenceNo),
                new nameValuePair("p_RequestNo", request.RequestNo),
                new nameValuePair("p_RequestDate", GenericLogic.IstNow),
                new nameValuePair("p_UserTypeId", request.UserTypeId),
                new nameValuePair("p_UserId", request.UserId),
                new nameValuePair("p_ExpiryDate", request.ExpiryDate),

                new nameValuePair("p_IsActive", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            int RequestId = Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequest, nvp, "Out_Param"));
            if (RequestId > 0)
            {
                // Add Child Table Here 
                new RequestRestrictLogic(CommonObj).Insert(request.RequestRestricts, request.RequestNo, RequestId);
                new RequestParameterLogic(CommonObj).Insert(request.RequestParameters, request.RequestNo, RequestId);
                new RequestFearuresLogic(CommonObj).Insert(request.RequestFeatures, request.RequestNo, RequestId);

            }
            return RequestId;
        }

        public List<Request> GetRequests(int UserId, int UserTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_RequestId", 0),
                new nameValuePair("p_UserTypeId", UserTypeId),
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_QueryType", "ALL")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetRequest, nameValuePairs).ToList<Request>();
        }

        public Request GetRequest(int RequestId, int UserId, int UserTypeId, bool idAdmin = false)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_RequestId", RequestId),
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_UserTypeId", UserTypeId),
                new nameValuePair("p_QueryType", "SINGLE")
            };
            DataSet dataSet = mySqlDBAccess.GetDataSet(StoreProcedure.GetRequest, nameValuePairs);
            Request request = dataSet.Tables[0].ToList<Request>().FirstOrDefault();
            request.RequestParameters = dataSet.Tables[1].ToList<RequestParameter>();
            request.RequestRestricts = dataSet.Tables[2].ToList<RequestRestrict>();
            request.RequestFeatures = dataSet.Tables[3].ToList<RequestFeature>();

            if(idAdmin)
            {
                //request.byPassRequisitionClaims
                if(request.IsClaimed)
                {
                    nameValuePairs nameValuePairs1 = new nameValuePairs
                        {
                            new nameValuePair("p_RequestId",RequestId),
                            new nameValuePair("p_QueryType", "CLAIMEDSTATUSLIST")
                        };
                    request.byPassRequisition = mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, nameValuePairs1).ToList<ByPassRequisitionClaim>().FirstOrDefault();
                }
                else
                {
                    nameValuePairs nameValuePairs1 = new nameValuePairs
                        {
                            new nameValuePair("p_RequestId",RequestId),
                            new nameValuePair("p_QueryType", "GETCLAIMLIST")
                        };
                    request.byPassRequisitionClaims = mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, nameValuePairs1).ToList<ByPassRequisitionClaim>();
                }
                
            }
            return request;
        }

        public int Claim(int RequestId, int UserId, int UserTypeId,bool IsAdmin = false )
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (IsAdmin) {
                nameValuePairs nameValuePairs = new nameValuePairs
                {
                    new nameValuePair("p_RequestId", RequestId),
                    new nameValuePair("p_UserId", UserId),
                    new nameValuePair("p_UserTypeId", UserTypeId),
                    new nameValuePair("p_QueryType", "CLAIMBYADMIN")
                };
                return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.ClaimbyAdmin, nameValuePairs, "Out_Param"));
            }
            else
            {
                nameValuePairs nameValuePairs = new nameValuePairs
                {
                    new nameValuePair("p_RequestId", RequestId),
                    new nameValuePair("p_UserId", UserId),
                    new nameValuePair("p_UserTypeId", UserTypeId),
                    new nameValuePair("p_QueryType", "CLAIM")
                };
                return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequestClaim, nameValuePairs, "Out_Param"));
            }
            

            
        }

        public bool ClaimUserExits(int RequestId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs1 = new nameValuePairs
                        {
                            new nameValuePair("p_RequestId",RequestId),
                            new nameValuePair("p_QueryType", "CLAIMUSEREXIST")
                        };
            RequisitionClaim byPassRequisition = mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, nameValuePairs1).ToList<RequisitionClaim>().FirstOrDefault();

            if(byPassRequisition.ClaimUserId == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<RequestStatus> GetRequests(int UserId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_RequestId", 0),
                new nameValuePair("p_UserTypeId", 0),
                new nameValuePair("p_UserId", UserId),
                new nameValuePair("p_QueryType", "OWN")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetRequest, nameValuePairs).ToList<RequestStatus>();
        }

        public List<FollowUp> GetFollowUpList()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "All")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetFollowUpList, nameValuePairs).ToList<FollowUp>();
        }

        public int InsertFollowUp(FollowUp followUp)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "INSERT"),
                new nameValuePair("p_RequestNo", followUp.RequestNo),
                new nameValuePair("p_IsFollowUp", true),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_FollowUpDoneBy", followUp.FollowUpDoneBy)
            };
            return mySqlDBAccess.InsertUpdateDeleteReturnInt(StoreProcedure.SetFollowUp, nameValuePairs);
        }

        public List<Request> AdminRequisitionList()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {      
                new nameValuePair("p_RequestId",0),
                new nameValuePair("p_QueryType", "ONLYADMIN")
            };
            return mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, nameValuePairs).ToList<Request>();
        }

        public RequisitionClaim GetRequisitionClaimDetails(int RequisitionId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_RequestId",RequisitionId),
                new nameValuePair("p_QueryType", "GETNEXTUSERTYPE")
            };
            return mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, nameValuePairs).ToList<RequisitionClaim>().FirstOrDefault();
        }
    }
}
