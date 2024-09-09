using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IPasswordResetRequest
    {
        int UserId { get; set; }
        bool IsCanceled { get; set; }
        DateTime CanceledDate { get; set; }
    }
}
