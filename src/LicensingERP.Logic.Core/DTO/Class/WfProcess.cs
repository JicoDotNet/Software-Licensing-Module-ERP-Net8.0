using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
    public class WfProcess : LicenceType, IWfProcess, ISession, IActivity, IIdentity, IStatus
    {
        public string ProcessName { get; set; }
        public string ProcessCode { get; set; }
        public bool IsInitial { get; set; }
        public bool IsEnd { get; set; } //In database show as *bit*
        public string Description { get; set; }
        public int LicenceTypeId { get; set; }

        /*Change on 29-06-2020 for marker and checker updation (its inherited from LicenceType class)  */
        //public int Id { get; set; }
        //public DateTime TransactionDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string SessionId { get; set; }
        //public bool IsActive { get; set; }
    }
}
