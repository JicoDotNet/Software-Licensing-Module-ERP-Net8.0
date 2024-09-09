using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// 
    /// </summary>
 public   interface IRequestParameter
    {
        int RequestId { get; set; }
        string RequestNo { get; set; }
        int ParamId { get; set; }
        string ParamValue { get; set; }

    }
}
