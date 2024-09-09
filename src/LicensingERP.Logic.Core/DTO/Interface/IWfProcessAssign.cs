using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{

    /// <summary>
    ///  tbl_wf_process_assign
    /// </summary>
    public interface IWfProcessAssign
    {
        int WFProcessId { get; set; }
        int StateId { get; set; }
        int FormUserTypeId { get; set; }
        int ToUserTypeId { get; set; }
        //int UserTypeId { get; set; }
        DateTime ActivityStartDate { get; set; }
        DateTime ActivityEndDate { get; set; }
    }
}
