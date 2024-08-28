using System;
using LicensingERP.Logic.DTO.Interface;

namespace LicensingERP.Logic.DTO.SP
{
    public class sCommonDto : ISession, IActivity, IStatus
    {
        public string SessionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

        public string ConnectionString { get; set; }
    }
}
