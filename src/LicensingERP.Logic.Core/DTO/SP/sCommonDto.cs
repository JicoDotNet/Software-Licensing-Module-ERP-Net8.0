using System;
using LicensingERP.Logic.DTO.Interface;

namespace LicensingERP.Logic.DTO.SP
{
    public class sCommonDto : ISession, IActivity
    {
        public string SessionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }

        public string ConnectionString { get; set; }

        public string DefaultEncryptionKey { get; set; }
    }
}
