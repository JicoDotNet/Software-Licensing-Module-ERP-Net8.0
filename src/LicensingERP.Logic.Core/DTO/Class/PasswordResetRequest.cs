using System;
using System.Collections.Generic;
using System.Text;
using LicensingERP.Logic.DTO.Interface;

namespace LicensingERP.Logic.DTO.Class
{
    public class PasswordResetRequest: IPasswordResetRequest, IUser, ISession, IActivity, IIdentity, IStatus
    {
        public int UserId { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CanceledDate { get; set; }

        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string UserTypeName { get; set; }
        public string UserTypeDetails { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
