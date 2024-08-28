using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class RequestLogic : ConnectionString
    {
        public RequestLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(Request request)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_Id", 0),
                new NameValuePair("p_ClientId", request.ClientId),
                new NameValuePair("p_LicenceTypeId", request.LicenceTypeId),
                new NameValuePair("p_ProductId", request.ProductId),
                new NameValuePair("p_LicenceNo", request.LicenceNo),
                new NameValuePair("p_RequestNo", request.RequestNo),
                new NameValuePair("p_RequestDate", GenericLogic.IstNow),
                new NameValuePair("p_UserTypeId", request.UserTypeId),
                new NameValuePair("p_UserId", request.UserId),
                new NameValuePair("p_ExpiryDate", request.ExpiryDate),

                new NameValuePair("p_IsActive", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_RequestId", 0),
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_QueryType", "ALL")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetRequest, NameValuePairs).ToList<Request>();
        }

        public Request GetRequest(int RequestId, int UserId, int UserTypeId, bool idAdmin = false)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_RequestId", RequestId),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_QueryType", "SINGLE")
            };
            DataSet dataSet = mySqlDBAccess.GetDataSet(StoreProcedure.GetRequest, NameValuePairs);
            Request request = dataSet.Tables[0].ToList<Request>().FirstOrDefault();
            request.RequestParameters = dataSet.Tables[1].ToList<RequestParameter>();
            request.RequestRestricts = dataSet.Tables[2].ToList<RequestRestrict>();
            request.RequestFeatures = dataSet.Tables[3].ToList<RequestFeature>();

            if(idAdmin)
            {
                //request.byPassRequisitionClaims
                if(request.IsClaimed)
                {
                    NameValuePairs NameValuePairs1 = new NameValuePairs
                        {
                            new NameValuePair("p_RequestId",RequestId),
                            new NameValuePair("p_QueryType", "CLAIMEDSTATUSLIST")
                        };
                    request.byPassRequisition = mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, NameValuePairs1).ToList<ByPassRequisitionClaim>().FirstOrDefault();
                }
                else
                {
                    NameValuePairs NameValuePairs1 = new NameValuePairs
                        {
                            new NameValuePair("p_RequestId",RequestId),
                            new NameValuePair("p_QueryType", "GETCLAIMLIST")
                        };
                    request.byPassRequisitionClaims = mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, NameValuePairs1).ToList<ByPassRequisitionClaim>();
                }
                
            }
            return request;
        }

        public int Claim(int RequestId, int UserId, int UserTypeId,bool IsAdmin = false )
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            if (IsAdmin) {
                NameValuePairs NameValuePairs = new NameValuePairs
                {
                    new NameValuePair("p_RequestId", RequestId),
                    new NameValuePair("p_UserId", UserId),
                    new NameValuePair("p_UserTypeId", UserTypeId),
                    new NameValuePair("p_QueryType", "CLAIMBYADMIN")
                };
                return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.ClaimbyAdmin, NameValuePairs, "Out_Param"));
            }
            else
            {
                NameValuePairs NameValuePairs = new NameValuePairs
                {
                    new NameValuePair("p_RequestId", RequestId),
                    new NameValuePair("p_UserId", UserId),
                    new NameValuePair("p_UserTypeId", UserTypeId),
                    new NameValuePair("p_QueryType", "CLAIM")
                };
                return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetRequestClaim, NameValuePairs, "Out_Param"));
            }
            

            
        }

        public bool ClaimUserExits(int RequestId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs1 = new NameValuePairs
                        {
                            new NameValuePair("p_RequestId",RequestId),
                            new NameValuePair("p_QueryType", "CLAIMUSEREXIST")
                        };
            RequisitionClaim byPassRequisition = mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, NameValuePairs1).ToList<RequisitionClaim>().FirstOrDefault();

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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_RequestId", 0),
                new NameValuePair("p_UserTypeId", 0),
                new NameValuePair("p_UserId", UserId),
                new NameValuePair("p_QueryType", "OWN")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetRequest, NameValuePairs).ToList<RequestStatus>();
        }

        public List<FollowUp> GetFollowUpList()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "All")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetFollowUpList, NameValuePairs).ToList<FollowUp>();
        }

        public int InsertFollowUp(FollowUp followUp)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "INSERT"),
                new NameValuePair("p_RequestNo", followUp.RequestNo),
                new NameValuePair("p_IsFollowUp", true),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_FollowUpDoneBy", followUp.FollowUpDoneBy)
            };
            return mySqlDBAccess.InsertUpdateDeleteReturnInt(StoreProcedure.SetFollowUp, NameValuePairs);
        }

        public List<Request> AdminRequisitionList()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {      
                new NameValuePair("p_RequestId",0),
                new NameValuePair("p_QueryType", "ONLYADMIN")
            };
            return mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, NameValuePairs).ToList<Request>();
        }

        public RequisitionClaim GetRequisitionClaimDetails(int RequisitionId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_RequestId",RequisitionId),
                new NameValuePair("p_QueryType", "GETNEXTUSERTYPE")
            };
            return mySqlDBAccess.GetData(StoreProcedure.AdminRequisitionList, NameValuePairs).ToList<RequisitionClaim>().FirstOrDefault();
        }
    }
}
