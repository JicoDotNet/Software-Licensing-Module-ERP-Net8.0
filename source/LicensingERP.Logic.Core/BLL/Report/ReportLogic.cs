using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.ReportClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL.Report
{
  public  class ReportLogic : ConnectionString
    {
        private string str;

        public ReportLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<ReportOfUser> GetUsertype(ReportOfUser userdata)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            // to do here
            if(userdata.UserTypeId != 0)
            {
                str = " tu.UserTypeId like '%"+ userdata.UserTypeId + "%' ";

                if (userdata.FullName != null)
                {
                    str = str + "AND tu.FullName like '%" + userdata.FullName + "%'";
                }
                else if (userdata.UserName != null)
                {
                    str = str + "AND tu.UserName like '%" + userdata.UserName + "%'";
                }
                else if (userdata.Email != null)
                {
                    str = str + "AND tu.Email like '%" + userdata.Email + "%'";
                }
                else if (userdata.Mobile != null)
                {
                    str = str + "AND tu.Mobile like '%" + userdata.Mobile + "%'";
                }
                else if (userdata.Designation != null)
                {
                    str = str + "AND tu.Designation like '%" + userdata.Designation + "%'";
                }

                if (userdata.IsActive != null)
                {
                    str = str + "AND tu.IsActive = " + userdata.IsActive;
                }
            }
            else
            {
                if(userdata.FullName != null)
                {
                    str = " tu.FullName like '%" + userdata.FullName + "%'";
                }
                else if(userdata.UserName != null)
                {
                    str = " tu.UserName like '%" + userdata.UserName + "%'";
                }
                else if (userdata.Email != null)
                {
                    str = " tu.Email like '%" + userdata.Email + "%'";
                }
                else if (userdata.Mobile != null)
                {
                    str = " tu.Mobile like '%" + userdata.Mobile + "%'";
                }
                else if (userdata.Designation != null)
                {
                    str = " tu.Designation like '%" + userdata.Designation + "%'";
                }

                if (userdata.IsActive != null)
                {
                    str = str + "AND tu.IsActive = " + userdata.IsActive;
                }
            }

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpUserList, nameValuePairs).ToList<ReportOfUser>();
        }


        public List<ReportOfRequest> GetLicenseInfo(ReportOfRequest request)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (request.UserTypeId != 0)
            {
                str = str + " tr.UserTypeId like '%" + request.UserTypeId + "%' AND ";
            }
            if (request.RequestNo != null)
            {
                str = str + " tr.RequestNo like '%" + request.RequestNo + "%' AND ";
            }
            if (request.ClientId != 0)
            {
                str = str + " tr.ClientId like '%" + request.ClientId + "%' AND ";
            }
            if (request.LicenceTypeId != 0)
            {
                str = str + " tr.LicenceTypeId like '%" + request.LicenceTypeId + "%' AND ";
            }
            if (request.ProductId != 0)
            {
                str = str + " tr.ProductId like '%" + request.ProductId + "%' AND ";
            }
            if (request.FromDate != null || request.ToDate != null)
            {
                str = str + " (tr.TransactionDate between " +
                    " STR_TO_DATE('" + request.FromDateFormat + "','" + request.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + request.ToDateFormat + "','" + request.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpRequestList, nameValuePairs).ToList<ReportOfRequest>();
        }

        public List<ReportOfUserLogin> GetLoginInfo(ReportOfUserLogin userLogin)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (userLogin.UserName != null)
            {
                str = str + " UserName like '%" + userLogin.UserName + "%' AND ";
            }
            if (userLogin.FromDate != null || userLogin.ToDate != null)
            {
                str = str + " (TransactionDate between " +
                    " STR_TO_DATE('" + userLogin.FromDateFormat + "','" + userLogin.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + userLogin.ToDateFormat + "','" + userLogin.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpUserLoginList, nameValuePairs).ToList<ReportOfUserLogin>();
        }

        public List<ReportOfActivity> GetActivityInfo(ReportOfActivity reportOfActivity)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserVal",reportOfActivity.User),
                new nameValuePair("p_FromDate", reportOfActivity.FromDate ),
                new nameValuePair("p_ToDate",reportOfActivity.ToDate)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpActivityList, nameValuePairs).ToList<ReportOfActivity>();
        }

        public List<ReportOfRequestMovement> GetRequestMovementInfo(ReportOfRequestMovement reqMov)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (reqMov.UserTypeId != 0)
            {
                str = str + " tra.UserTypeId = " + reqMov.UserTypeId + " AND ";
            }
            if (reqMov.StateId != 0)
            {
                str = str + " tra.StateId = " + reqMov.StateId + " AND ";
            }
            if (reqMov.RequestNo != null)
            {
                str = str + " tra.RequestNo = '" + reqMov.RequestNo + "' AND ";
            }
            if (reqMov.User != null)
            {
                str = str + " tra.UserId in (select Id " +
                    "from tbl_user " +
                    "where FullName LIKE '%" + reqMov.User + "%' " +
                        "or Email LIKE '%" + reqMov.User + "%' " +
                        "or UserName like '%" + reqMov.User + "%') AND ";
            }
            if (reqMov.FromDate != null || reqMov.ToDate != null)
            {
                str = str + " ( tra.TransactionDate between " +
                    " STR_TO_DATE('" + reqMov.FromDateFormat + "','" + reqMov.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + reqMov.ToDateFormat + "','" + reqMov.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpRequestMovementList, nameValuePairs).ToList<ReportOfRequestMovement>();
        }


        public List<ReportOfMakerChecker> GetMakerCheckerInfo(ReportOfMakerChecker reportOfMakerChecker)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (reportOfMakerChecker.CaseType != null)
            {
                str = str + " tmdoh.CaseType = '" + reportOfMakerChecker.CaseType + "' AND ";
            }
            if (reportOfMakerChecker.Purpose != null)
            {
                str = str + " tmdoh.Purpose = '" + reportOfMakerChecker.Purpose + "' AND ";
            }
            if (reportOfMakerChecker.CreatedUserVal != null)
            {
                str = str + " tmdoh.CreatedUserId in (select Id " +
                    "from tbl_user " +
                    "where FullName LIKE '%" + reportOfMakerChecker.CreatedUserVal + "%' " +
                        "or Email LIKE '%" + reportOfMakerChecker.CreatedUserVal + "%' " +
                        "or UserName like '%" + reportOfMakerChecker.CreatedUserVal + "%') AND ";
            }
            if (reportOfMakerChecker.ApproveRejectUserVal != null)
            {
                str = str + " tmdoh.ApproveRejectUserId in (select Id " +
                    "from tbl_user " +
                    "where FullName LIKE '%" + reportOfMakerChecker.ApproveRejectUserVal + "%' " +
                        "or Email LIKE '%" + reportOfMakerChecker.ApproveRejectUserVal + "%' " +
                        "or UserName like '%" + reportOfMakerChecker.ApproveRejectUserVal + "%') AND ";
            }

            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpMakerCheckerList, nameValuePairs).ToList<ReportOfMakerChecker>();
        }

        public List<ReportOfStatus> GetStatusInfo(ReportOfStatus reportOfStatus)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (reportOfStatus.IsApproved != null)
            {
                str = str + " IsApproved = " + reportOfStatus.IsApproved + " AND ";
            }
            if (reportOfStatus.RequestNo != null)
            {
                str = str + " RequestNo = '" + reportOfStatus.RequestNo + "' AND ";
            }
            
            if (reportOfStatus.FromDate != null || reportOfStatus.ToDate != null)
            {
                str = str + " (TransactionDate between " +
                    " STR_TO_DATE('" + reportOfStatus.FromDateFormat + "','" + reportOfStatus.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + reportOfStatus.ToDateFormat + "','" + reportOfStatus.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpStatus, nameValuePairs).ToList<ReportOfStatus>();
        }

        public List<ReportOfRequestOnHold> GetRequestOnHold(ReportOfRequestOnHold reportOfRequestOnHold)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (reportOfRequestOnHold.User != null)
            {
                str = str + " tr.UserId in (select Id " +
                    "from tbl_user " +
                    "where FullName LIKE '%" + reportOfRequestOnHold.User + "%' " +
                        "or Email LIKE '%" + reportOfRequestOnHold.User + "%' " +
                        "or UserName like '%" + reportOfRequestOnHold.User + "%') AND ";
            }
            if (reportOfRequestOnHold.UserTypeId != 0)
            {
                str = str + " tr.CreatedUserTypeId = '" + reportOfRequestOnHold.UserTypeId + "' AND ";
            }
            if (reportOfRequestOnHold.LicenceTypeId != 0)
            {
                str = str + " tr.LicenceTypeId = '" + reportOfRequestOnHold.LicenceTypeId + "' AND ";
            }
            if (reportOfRequestOnHold.FromDate != null || reportOfRequestOnHold.ToDate != null)
            {
                str = str + " ( tr.RequestDate between " +
                    " STR_TO_DATE('" + reportOfRequestOnHold.FromDateFormat + "','" + reportOfRequestOnHold.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + reportOfRequestOnHold.ToDateFormat + "','" + reportOfRequestOnHold.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpRequestOnHold, nameValuePairs).ToList<ReportOfRequestOnHold>();
        }

        public List<ReportOfXmlDownload> GetXmlDownloadInfo(ReportOfXmlDownload reportOfXmlDownload)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (reportOfXmlDownload.User != null)
            {
                str = str + " txd.UserId in (select Id " +
                    "from tbl_user " +
                    "where FullName LIKE '%" + reportOfXmlDownload.User + "%' " +
                        "or Email LIKE '%" + reportOfXmlDownload.User + "%' " +
                        "or UserName like '%" + reportOfXmlDownload.User + "%') AND ";
            }            
            if (reportOfXmlDownload.RequestNo != null)
            {
                str = str + " txd.RequestNo = '" + reportOfXmlDownload.RequestNo + "' AND ";
            }
            if (reportOfXmlDownload.FromDate != null || reportOfXmlDownload.ToDate != null)
            {
                str = str + " ( txd.TransactionDate between " +
                    " STR_TO_DATE('" + reportOfXmlDownload.FromDateFormat + "','" + reportOfXmlDownload.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + reportOfXmlDownload.ToDateFormat + "','" + reportOfXmlDownload.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpXmlDownload, nameValuePairs).ToList<ReportOfXmlDownload>();
        }

        public List<ReportOfRequest> GetPendingInfo(ReportOfRequest request)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);

            if (request.UserTypeId != 0)
            {
                str = str + " tr.UserTypeId like '%" + request.UserTypeId + "%' AND ";
            }
            if (request.RequestNo != null)
            {
                str = str + " tr.RequestNo like '%" + request.RequestNo + "%' AND ";
            }
            if (request.ClientId != 0)
            {
                str = str + " tr.ClientId like '%" + request.ClientId + "%' AND ";
            }
            if (request.LicenceTypeId != 0)
            {
                str = str + " tr.LicenceTypeId like '%" + request.LicenceTypeId + "%' AND ";
            }
            if (request.ProductId != 0)
            {
                str = str + " tr.ProductId like '%" + request.ProductId + "%' AND ";
            }
            if (request.FromDate != null || request.ToDate != null)
            {
                str = str + " (tr.RequestDate between " +
                    " STR_TO_DATE('" + request.FromDateFormat + "','" + request.DateFormat + "') " +
                    " and " +
                    " STR_TO_DATE('" + request.ToDateFormat + "','" + request.DateFormat + "')) AND ";
            }
            str = str.Remove(str.Length - 4, 3);

            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_WhereClouse",str)
            };

            return mySqlDBAccess.GetData(StoreProcedure.RpRequestPendingList, nameValuePairs).ToList<ReportOfRequest>();
        }
    }
}
