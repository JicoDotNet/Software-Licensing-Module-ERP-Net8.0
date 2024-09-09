using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
    public class Client : IClient, IClientCategory, ISession, IActivity, IIdentity, IStatus
    {
        public int CategoryId { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public string ClientEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string GSTIN { get; set; }
        public string PANNo { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDetails { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
