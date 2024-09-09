using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    /// <summary>
    /// tbl_product_module
    /// </summary>
    public interface IProductModule
    {
        int ProductId { get; set; }
        string ModuleName { get; set; }
        string ModuleDetails { get; set; }
    }
}
