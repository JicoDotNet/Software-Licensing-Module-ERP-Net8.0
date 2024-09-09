using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Custom
{
    public class WfAssign: WfProcessAssign, IWfProcess, IWfState
    {
        public string ProcessName { get; set; }
        public int MyProperty { get; set; }
        public string ProcessCode { get; set; }
        public bool IsInitial { get; set; }
        public bool IsEnd { get; set; } //In database show as *bit*
        public string Description { get; set; }

        public  int LicenceTypeId { get; set; }
        public string TypeName { get; set; }

        public string Name { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }
        public bool IsHold { get; set; }

        public string FromUserTypeName { get; set; }
        public string ToUserTypeName { get; set; }
    }
}
