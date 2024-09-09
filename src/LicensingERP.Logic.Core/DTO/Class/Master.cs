using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class Master: IMaster
    {
        public long UserType { get; set; }
        public long User { get; set; }
        public long LicenceType { get; set; }
        public long Client { get; set; }
        public long Product { get; set; }
        public long FormManage { get; set; }
        public long ClientCategory { get; set; }
        public long Process { get; set; }
    }
}
