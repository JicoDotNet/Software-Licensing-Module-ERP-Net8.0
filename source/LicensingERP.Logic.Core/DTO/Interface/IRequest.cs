using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IRequest
    {
        int ClientId { get; set; }
        int LicenceTypeId { get; set; }
        int ProductId { get; set; }
        string RequestNo { get; set; }
        DateTime RequestDate { get; set; }
        int UserId { get; set; }
        int UserTypeId { get; set; }
        string LicenceNo { get; set; }
    }
}
