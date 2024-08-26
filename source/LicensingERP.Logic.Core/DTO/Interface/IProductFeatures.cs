using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_product_features
    /// </summary>
    public interface IProductFeatures
    {
       int ProductId { get; set; }
        string FeaturesName { get; set; }
        string FeaturesDetails { get; set; }
    }
}
