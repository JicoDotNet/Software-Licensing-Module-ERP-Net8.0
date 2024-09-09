using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_request_status
    /// </summary>
    public interface IRequestStatus : IRequisitionRequest
    {
        bool? IsApproved { get; set; }
        DateTime ApproveRejectDate { get; set; }
        string Remarks { get; set; }
        TimeSpan TurnAroundTime { get; set; }
    }
}
