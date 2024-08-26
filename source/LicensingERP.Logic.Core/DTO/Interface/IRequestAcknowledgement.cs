using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_request_acknowledgement
    /// </summary>
    public interface IRequestAcknowledgement
    {
        int RequestId { get; set; }
        string RequestNo { get; set; }
        int UserId { get; set; }
        int UserTypeId { get; set; }
        string Remarks { get; set; }
        bool IsApproved { get; set; }
        int StateId { get; set; }
    }
}
