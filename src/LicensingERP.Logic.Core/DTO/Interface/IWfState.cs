using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    ///   tbl_s_action
    /// </summary>
    public interface IWfState
    {
         string Name { get; set; }
         bool IsPositive { get; set; }
         bool IsNegative { get; set; }
         bool IsInitial { get; set; }
         bool IsHold { get; set; }
    }
}
