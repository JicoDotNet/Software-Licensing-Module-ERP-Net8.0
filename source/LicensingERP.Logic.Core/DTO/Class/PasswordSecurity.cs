using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class PasswordSecurity :IPasswordSecurity, ISession, IActivity, IIdentity, IStatus
    {
        public int UserId { get; set; }
        public int QuestionEnumNo { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
