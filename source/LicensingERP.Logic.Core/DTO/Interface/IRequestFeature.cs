using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_request_features
    /// </summary>
    public interface IRequestFeature
    {
        int RequestId { get; set; }
        string RequestNo { get; set; }
        int FeaturesId { get; set; }
        int ProductId { get; set; }
    }
}
