using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_request_restrict
    /// </summary>
    public interface IRequestRestrict
    {       
        int RequestId { get; set; }
        string RequestNo { get; set; }
        string RestrictTo { get; set; }
        string RestrictVal { get; set; }
    }
}
