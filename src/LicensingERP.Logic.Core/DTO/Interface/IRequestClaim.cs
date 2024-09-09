using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IRequestClaim
    {
        DateTime ClaimDate { get; set; }
        DateTime AssignDate { get; set; }



    }
}
