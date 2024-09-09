using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Interface
{
    public interface IDashboard
    {
        string PartialViewName { get; set; }
        string Description { get; set; }
        string DivCssClass { get; set; }
    }
}
