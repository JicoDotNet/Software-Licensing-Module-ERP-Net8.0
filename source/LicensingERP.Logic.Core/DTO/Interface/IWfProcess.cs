using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    ///   tbl_wf_process
    /// </summary>
    public interface IWfProcess
    {
         string ProcessName { get; set; }
         string ProcessCode { get; set; }
         bool IsInitial { get; set; }
         bool IsEnd { get; set; } //In database show as *bit*
         string Description { get; set; }
         int LicenceTypeId { get; set; }

    }
}
