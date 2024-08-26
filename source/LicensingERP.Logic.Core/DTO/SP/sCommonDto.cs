using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Class
{
    public class sCommonDto : ISession, IActivity, IStatus
    {
        public string SessionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

        public object ConnectionString { get; set; }
    }
}
