using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.ReportClass
{
    public class ReportOfMakerChecker : IDataOnHold, IUser,IActivity, ISession, IStatus,IUserType
    {
        public string UserName { get; set; }


        public int UserId { get; set; }
        public string CaseType { get; set; }
        public string Purpose { get; set; }
        public string EffectedData { get; set; }

       public string EffectedDataDisplay { get; set; }
       public string OldDataDisplay { get; set; }


        public int EffectedRowId { get; set; }
        public int CreatedUserId { get; set; }
        public int CreatedUserTypeId { get; set; }
        public bool? IsApproved { get; set; }
        public int ApproveRejectUserId { get; set; }
        public int ApproveRejectUserTypeId { get; set; }
        public string ApproveRejectRemarks { get; set; }
        public DateTime? ApproveRejectDate { get; set; }

        public string CreatedUserVal { get; set; }
        public string ApproveRejectUserVal { get; set; }

        public int UserTypeId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }

        public string UserTypeName { get; set; }
        public string UserTypeDetails { get; set; }

        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }

        public string SessionId { get; set; }

        public bool IsActive { get; set; }
    }
}
