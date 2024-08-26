using LicensingERP.Logic.DTO.Interface;
using System;

namespace LicensingERP.Logic.DTO.Class
{
    public  class TypeOfClient: ITypeOfClient, ISession, IActivity, IIdentity, IStatus
    {
        public string ClientType { get; set; }
        public string Detalis { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
