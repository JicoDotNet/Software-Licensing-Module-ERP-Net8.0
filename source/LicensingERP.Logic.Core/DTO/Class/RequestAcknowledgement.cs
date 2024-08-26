using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class RequestAcknowledgement: IRequestAcknowledgement, IAcknowledgementDocs,
        IUserType, IUser, IWfState,
        ISession, IActivity, IIdentity, IStatus
    {
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string Remarks { get; set; }
        public bool IsApproved { get; set; }
        public int StateId { get; set; }

        public int AcknowledgementId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] FileData { get; set; }
        public string Description { get; set; }

        public string UserTypeName { get; set; }
        public string UserTypeDetails { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }

        public string Name { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }
        public bool IsInitial { get; set; }
        public bool IsHold { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }

        public string BUserGroupName { get; set; }
        public string BUserName { get; set; }
        public int BUserId { get; set; }
        public int BNextUserTypeId { get; set; }
    }
}
