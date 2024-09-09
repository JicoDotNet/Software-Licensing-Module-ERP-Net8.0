using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IMaster
    {
        long UserType { get; set; }
        long User { get; set; }
        long LicenceType { get; set; }
        long Client { get; set; }
        long Product { get; set; }
        long FormManage { get; set; }
        long ClientCategory { get; set; }
        long Process { get; set; }
    }
}
