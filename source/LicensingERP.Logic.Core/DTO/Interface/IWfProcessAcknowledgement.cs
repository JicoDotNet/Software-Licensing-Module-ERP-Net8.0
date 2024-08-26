using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    ///   tbl_wf_process_acknowledgement
    /// </summary>
    public interface IWfProcessAcknowledgement
    {

        int FileId { get; set; }
        int ProcessAsignId { get; set; }
        int ProcessId { get; set; }
        DateTime? ActivityStartDate { get; set; }
        DateTime? ActivityEndDate { get; set; }
        string Comments { get; set; }
        string Description { get; set; }
    }
}
