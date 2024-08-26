using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
    public class LicenceType : ILicenceType, ISession, IActivity, IIdentity, IStatus
    {
        public string TypeName { get; set; }
        public string LicenceTypeDetails { get; set; }
        //public int NumberOfLicence { get; set; }
        //public bool IsScalingEligible { get; set; }


        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
