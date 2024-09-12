using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
   public class WfProcessAssign: IWfProcessAssign, ISession, IActivity, IIdentity, IStatus
    {
        public int WFProcessId { get; set; }
        public int StateId { get; set; }
        public int FromUserTypeId { get; set; }
        public int ToUserTypeId { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// marker/checker
        /// </summary>
        
        public string WorkFlowName { get; set; }
        public string StateName { get; set; }
        public string FromUserTypeName { get; set; }
        public string ToUserTypeName { get; set; }
    }
}
