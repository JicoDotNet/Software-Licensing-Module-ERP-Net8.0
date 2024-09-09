using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
  public  class WfProcessAcknowledgement: IWfProcessAcknowledgement, ISession, IActivity, IIdentity, IStatus
    {
        public int FileId { get; set; }
        public int ProcessAsignId { get; set; }
        public int ProcessId { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public DateTime? ActivityEndDate { get; set; }
        public string Comments { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
